
using System.Data.SQLite;

namespace SnapshotsOfLifeEx02
{
    class DB
    {

        private string connectionString = "Data Source=settings.db;Version=3;";


        public DB()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Settings (Key TEXT PRIMARY KEY, Value INTEGER)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createTableQuery2 = "CREATE TABLE IF NOT EXISTS Frames (Key TEXT PRIMARY KEY, Value TEXT)";
                using (var command = new SQLiteCommand(createTableQuery2, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveSetting(string key, int value)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT OR REPLACE INTO Settings (Key, Value) VALUES (@Key, @Value)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveSettingString(string key, string value)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT OR REPLACE INTO Frames (Key, Value) VALUES (@Key, @Value)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int GetSetting(string key)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Value FROM Settings WHERE Key = @Key";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    var result = command.ExecuteScalar();
                    return result != null ? int.Parse(result.ToString()) : 0;
                }
            }
        }

        public string GetStringSetting(string key)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Value FROM Frames WHERE Key = @Key";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

    }
}
