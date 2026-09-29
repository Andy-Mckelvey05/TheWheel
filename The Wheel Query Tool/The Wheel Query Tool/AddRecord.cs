using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace The_Wheel_Query_Tool
{
    public partial class frm_AddRecord : Form
    {
        public frm_AddRecord()
        {
            InitializeComponent();

            dtp_DateWonInput.Format = DateTimePickerFormat.Custom;
            dtp_DateWonInput.CustomFormat = "yyyy-MM-dd";
        }


        private void btn_AddRecord_Click(object sender, EventArgs e)
        {
            string movieName = txb_MovieNameInput.Text.Trim();
            string letterboxdLink = txb_LetterboxdLinkInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(movieName))
            {
                MessageBox.Show(
                    "Movie name is required.",
                    "Invalid Input"
                );

                return;
            }

            if (!int.TryParse(
                txb_MovieReleaseInput.Text,
                out int releaseYear))
            {
                MessageBox.Show(
                    "Release year must be a number.",
                    "Invalid Input"
                );

                return;
            }

            if (releaseYear < 1800 ||
                releaseYear > DateTime.Now.Year)
            {
                MessageBox.Show(
                    "Invalid release year.",
                    "Invalid Input"
                );

                return;
            }

            DateTime winDate = dtp_DateWonInput.Value.Date;

            SaveSubmission(
                movieName,
                releaseYear,
                letterboxdLink,
                winDate
            );
        }

        private void SaveSubmission(
            string movieName,
            int releaseYear,
            string letterboxdLink,
            DateTime winDate)
        {
            try
            {
                using var connection = new SqliteConnection($"Data Source={GetDatabasePath()}");

                connection.Open();
                using var checkCommand = connection.CreateCommand();

                checkCommand.CommandText =
                """
                SELECT dates_won
                FROM wheel_submissions
                WHERE movie_name = $movie
                AND release_year = $year
                """;

                checkCommand.Parameters.AddWithValue(
                    "$movie",
                    movieName
                );

                checkCommand.Parameters.AddWithValue(
                    "$year",
                    releaseYear
                );

                object? existing = checkCommand.ExecuteScalar();

                string formattedDate = winDate.ToString("yyyy-MM-dd");

                if (existing != null)
                {
                    List<string> dates =
                        JsonSerializer.Deserialize<List<string>>(
                            existing.ToString() ?? "[]"
                        )
                        ?? new List<string>();


                    bool alreadyWonThisYear =
                        dates.Any(date =>
                            date.StartsWith(
                                winDate.Year.ToString()
                            )
                        );


                    if (alreadyWonThisYear)
                    {
                        MessageBox.Show(
                            "This movie has already won this year.",
                            "Duplicate Win"
                        );

                        return;
                    }


                    dates.Add(formattedDate);


                    using var updateCommand =
                        connection.CreateCommand();


                    updateCommand.CommandText =
                    """
                    UPDATE wheel_submissions
                    SET dates_won = $dates
                    WHERE movie_name = $movie
                    AND release_year = $year
                    """;


                    updateCommand.Parameters.AddWithValue(
                        "$dates",
                        JsonSerializer.Serialize(dates)
                    );

                    updateCommand.Parameters.AddWithValue(
                        "$movie",
                        movieName
                    );

                    updateCommand.Parameters.AddWithValue(
                        "$year",
                        releaseYear
                    );


                    updateCommand.ExecuteNonQuery();


                    MessageBox.Show(
                        "Added additional win date.",
                        "Success"
                    );
                }
                else
                {
                    using var insertCommand =
                        connection.CreateCommand();


                    insertCommand.CommandText =
                    """
                    INSERT INTO wheel_submissions
                    (
                        movie_name,
                        release_year,
                        letterboxd_link,
                        dates_won
                    )
                    VALUES
                    (
                        $movie,
                        $year,
                        $link,
                        $dates
                    )
                    """;


                    insertCommand.Parameters.AddWithValue(
                        "$movie",
                        movieName
                    );

                    insertCommand.Parameters.AddWithValue(
                        "$year",
                        releaseYear
                    );

                    insertCommand.Parameters.AddWithValue(
                        "$link",
                        letterboxdLink
                    );

                    insertCommand.Parameters.AddWithValue(
                        "$dates",
                        JsonSerializer.Serialize(
                            new List<string>
                            {
                                formattedDate
                            }
                        )
                    );


                    insertCommand.ExecuteNonQuery();


                    MessageBox.Show(
                        "Added new movie.",
                        "Success"
                    );
                }

                UpdateBannedMoviesFile();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Database Error"
                );
            }
        }


        private string GetDatabasePath()
        {
            string exeFolder = AppContext.BaseDirectory;

            string root = Path.GetFullPath(
                Path.Combine(
                    exeFolder,
                    "..",
                    "..",
                    "..",
                    "..",
                    ".."
                )
            );

            return Path.Combine(
                root,
                "The Wheel.db"
            );
        }

        private void UpdateBannedMoviesFile()
        {
            try
            {
                string dbPath = GetDatabasePath();

                string directory = Path.GetDirectoryName(dbPath)
                    ?? AppContext.BaseDirectory;

                string outputPath = Path.Combine(
                    directory,
                    "Banned Movies.txt"
                );

                int currentYear = DateTime.Now.Year;

                using var connection = new SqliteConnection(
                    $"Data Source={dbPath}"
                );

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText =
                """
        SELECT movie_name, release_year, dates_won
        FROM wheel_submissions
        """;

                using var reader = command.ExecuteReader();

                List<(string Name, int Year, DateTime WinDate)> movies = new();

                while (reader.Read())
                {
                    string movieName =
                        reader["movie_name"]?.ToString() ?? "";

                    int releaseYear =
                        Convert.ToInt32(reader["release_year"]);

                    string datesJson =
                        reader["dates_won"]?.ToString() ?? "[]";

                    List<string> dates =
                        JsonSerializer.Deserialize<List<string>>(datesJson)
                        ?? new List<string>();

                    DateTime? currentYearWin = null;

                    foreach (string date in dates)
                    {
                        if (DateTime.TryParseExact(
                            date,
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime winDate))
                        {
                            if (winDate.Year == currentYear)
                            {
                                currentYearWin = winDate;
                                break;
                            }
                        }
                    }

                    if (currentYearWin.HasValue)
                    {
                        movies.Add(
                            (
                                movieName,
                                releaseYear,
                                currentYearWin.Value
                            )
                        );
                    }
                }

                StringBuilder output = new();

                output.AppendLine("Banned Movies:");
                output.AppendLine();

                for (int month = 1; month <= 12; month++)
                {
                    List<(string Name, int Year, DateTime WinDate)> monthMovies =
                        movies
                            .Where(movie => movie.WinDate.Month == month)
                            .OrderBy(movie => movie.Name)
                            .ThenBy(movie => movie.Year)
                            .ToList();

                    // Don't display months with no banned movies.
                    if (monthMovies.Count == 0)
                    {
                        continue;
                    }

                    string monthName =
                        CultureInfo.CurrentCulture
                            .DateTimeFormat
                            .GetAbbreviatedMonthName(month);

                    output.AppendLine(
                        $"{month:00} ({monthName})"
                    );

                    foreach (var movie in monthMovies)
                    {
                        output.AppendLine(
                            $" - {movie.Name} ({movie.Year})"
                        );
                    }

                    output.AppendLine();
                }

                File.WriteAllText(
                    outputPath,
                    output.ToString(),
                    Encoding.UTF8
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Banned Movies File Error"
                );
            }
        }
    }
}