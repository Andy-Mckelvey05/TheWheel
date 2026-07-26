using Microsoft.Data.Sqlite;
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
    }
}