using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace The_Wheel_Query_Tool
{
    public partial class frm_WheelQueryTool : Form
    {
        private List<WheelSubmission> submissions = new();
        private List<(string Name, string Query)> savedQueries = new();

        public frm_WheelQueryTool()
        {
            InitializeComponent();

            LoadSavedQueries();
            PopulateQueryComboBox();

            btn_CustomQuery_Click(null, EventArgs.Empty);
        }


        #region Database

        private string GetDatabasePath()
        {
            string exeFolder = AppContext.BaseDirectory;

            string root = Path.GetFullPath(
                Path.Combine(exeFolder, "..", "..", "..", "..", "..")
            );

            return Path.Combine(root, "The Wheel.db");
        }


        private List<WheelSubmission> LoadSubmissions(SqliteDataReader reader)
        {
            List<WheelSubmission> results = new();

            while (reader.Read())
            {
                WheelSubmission submission = new();


                submission.MovieName = reader["movie_name"]?.ToString() ?? "";


                if (reader["release_year"] != DBNull.Value)
                {
                    submission.ReleaseYear = Convert.ToInt32(reader["release_year"]);
                }

                submission.LetterboxdLink = reader["letterboxd_link"]?.ToString() ?? "";

                string datesJson = reader["dates_won"]?.ToString() ?? "[]";

                try
                {
                    List<string>? dates = JsonSerializer.Deserialize<List<string>>(datesJson);

                    if (dates != null)
                    {
                        foreach (string date in dates)
                        {
                            submission.DatesWon.Add(
                                DateTime.ParseExact(
                                    date,
                                    "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture
                                )
                            );
                        }
                    }
                }
                catch
                {
                    // Ignore Invalid Dates
                }

                results.Add(submission);
            }

            return results;
        }

        #endregion


        #region Query

        private void btn_CustomQuery_Click(object sender, EventArgs e)
        {
            ltb_QueryDisplay.Items.Clear();

            try
            {
                string dbPath = GetDatabasePath();

                var builder = new SqliteConnectionStringBuilder
                {
                    DataSource = dbPath,
                    Mode = SqliteOpenMode.ReadOnly
                };

                using var connection = new SqliteConnection(builder.ToString());
                connection.Open();

                string query = txb_QueryInput.Text;

                using var command = connection.CreateCommand();
                command.CommandText = query;

                using var reader = command.ExecuteReader();

                submissions = LoadSubmissions(reader);

                DisplaySubmissions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "SQL Error");
            }
        }

        #endregion


        #region Saved Queries

        private void LoadSavedQueries()
        {
            savedQueries.Clear();

            savedQueries.Add(
                ("All Movies", "SELECT * FROM wheel_submissions")
            );

            string filePath = Path.Combine(
                AppContext.BaseDirectory,
                "CustomQuerys.json"
            );

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    $"Could not find:\n{filePath}",
                    "Missing Query File"
                );

                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);

                List<List<string>>? queries = JsonSerializer.Deserialize<List<List<string>>>(json);

                if (queries == null)
                {
                    return;
                }

                foreach (List<string> query in queries)
                {
                    if (query.Count >= 2)
                    {
                        savedQueries.Add((query[0], query[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Query Load Error"
                );
            }
        }

        private void PopulateQueryComboBox()
        {
            cmb_CustomQuerys.Items.Clear();

            foreach (var query in savedQueries)
            {
                cmb_CustomQuerys.Items.Add(query.Name);
            }

            cmb_CustomQuerys.SelectedIndex = 0;
        }

        private void cmb_CustomQuerys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_CustomQuerys.SelectedIndex < 0)
            {
                return;
            }

            string selectedName = cmb_CustomQuerys.SelectedItem.ToString() ?? "";
            var selectedQuery = savedQueries.FirstOrDefault(x => x.Name == selectedName);

            txb_QueryInput.Text = selectedQuery.Query
                .Replace("\n", Environment.NewLine)
                .Replace("\t", "    ");
        }

        #endregion


        #region Display

        private void DisplaySubmissions()
        {
            ltb_QueryDisplay.Items.Clear();

            List<string[]> rows = new();

            rows.Add(new[]
            {
                "#:",
                "Movie Name:",
                "Year:  ",
                "Dates Won:"
            });


            int rowNumber = 1;

            foreach (WheelSubmission movie in submissions)
            {
                rows.Add(new[]
                {
                    rowNumber.ToString(),
                    movie.MovieName,
                    movie.ReleaseYear.ToString(),
                    movie.DatesWonDisplay()
                });

                rowNumber++;
            }


            int[] widths = new int[rows[0].Length];

            foreach (string[] row in rows)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    widths[i] = Math.Max(widths[i], row[i].Length);
                }
            }


            foreach (string[] row in rows)
            {
                ltb_QueryDisplay.Items.Add(
                    FormatColumns(row, widths)
                );
            }

            AdjustListBoxFontSize(ltb_QueryDisplay);
        }


        private string FormatColumns(string[] values, int[] widths)
        {
            StringBuilder sb = new();

            for (int i = 0; i < values.Length; i++)
            {
                sb.Append(values[i].PadRight(widths[i] + 1));
            }

            return sb.ToString().TrimEnd();
        }

        private void AdjustListBoxFontSize(ListBox listBox)
        {
            int maxSize = 100;
            int minSize = 1;
            int padding = 5;

            string longestText = "";

            foreach (var item in listBox.Items)
            {
                string itemText = item?.ToString() ?? "";

                if (itemText.Length > longestText.Length)
                {
                    longestText = itemText;
                }
            }


            if (string.IsNullOrEmpty(longestText))
            {
                return;
            }


            float fontSize = maxSize;

            using (Graphics g = listBox.CreateGraphics())
            {
                while (fontSize > minSize)
                {
                    using Font testFont = new Font("Consolas", fontSize);

                    if (g.MeasureString(longestText, testFont).Width <= listBox.Width - padding)
                    {
                        break;
                    }

                    fontSize--;
                }
            }


            listBox.Font = new Font("Consolas", fontSize);
        }

        #endregion


        #region Links

        private void ltb_QueryDisplay_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = ltb_QueryDisplay.SelectedIndex;

            if (selectedIndex <= 0)
            {
                return;
            }

            int movieIndex = selectedIndex - 1;

            if (movieIndex >= submissions.Count)
            {
                return;
            }

            WheelSubmission movie = submissions[movieIndex];

            if (!string.IsNullOrWhiteSpace(movie.LetterboxdLink))
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = movie.LetterboxdLink,
                        UseShellExecute = true
                    }
                );
            }
        }

        #endregion


        #region Sorting

        private void RefreshDisplay()
        {
            DisplaySubmissions();
        }


        private void btn_NameAtoZ_Click(object sender, EventArgs e)
        {
            submissions = submissions
                .OrderBy(x => x.MovieName)
                .ToList();

            RefreshDisplay();
        }


        private void btn_NameZtoA_Click(object sender, EventArgs e)
        {
            submissions = submissions
                .OrderByDescending(x => x.MovieName)
                .ToList();

            RefreshDisplay();
        }


        private void btn_YearOldtoNew_Click(object sender, EventArgs e)
        {
            submissions = submissions
                .OrderBy(x => x.ReleaseYear)
                .ToList();

            RefreshDisplay();
        }


        private void btn_YearNewtoOld_Click(object sender, EventArgs e)
        {
            submissions = submissions
                .OrderByDescending(x => x.ReleaseYear)
                .ToList();

            RefreshDisplay();
        }


        private void btn_WinsOldtoNew_Click(object sender, EventArgs e)
        {
            submissions = submissions
                .OrderBy(x =>
                    x.DatesWon.Count > 0
                    ? x.DatesWon.Min()
                    : DateTime.MaxValue)
                .ToList();

            RefreshDisplay();
        }


        private void btn_WinsNewtoOld_Click(object sender, EventArgs e)
        {
            submissions = submissions
                .OrderByDescending(x =>
                    x.DatesWon.Count > 0
                    ? x.DatesWon.Max()
                    : DateTime.MinValue)
                .ToList();

            RefreshDisplay();
        }

        #endregion


        #region Add Records

        private void btn_AddRecordFormDisplay_Click(object sender, EventArgs e)
        {
            using frm_AddRecord form = new frm_AddRecord();

            form.ShowDialog();

            cmb_CustomQuerys.SelectedIndex = 0;
            btn_CustomQuery_Click(null, EventArgs.Empty);
        }

        #endregion

    }
}