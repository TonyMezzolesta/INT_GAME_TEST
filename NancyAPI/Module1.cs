using Nancy;
using Newtonsoft.Json;
using System.Data;
using System.Data.SQLite;

namespace NancyAPI
{
    public class Module1 : NancyModule
    {
        public Module1()
        {
            Get["/taco"] = p =>
            {
                DataSet ds = new DataSet();
                string connectionString = @"Data Source=C:\Workspace\TestDBs\INT_GAME_TEST.db; 
                                            Version=3; FailIfMissing=True; Foreign Keys=True;";
                string json = string.Empty;

                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "SELECT * FROM GAME_STORIES ";
                        string sqlAnswers = "SELECT * FROM GAME_STORIES_ANSWERS ";

                        SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                        da.Fill(ds, "GAME_STORIES");

                        SQLiteDataAdapter daAnswers = new SQLiteDataAdapter(sqlAnswers, conn);
                        daAnswers.Fill(ds, "GAME_STORIES_ANSWERS");

                        conn.Close();
                    }

                    json = JsonConvert.SerializeObject(ds, Formatting.Indented);
                }
                catch (SQLiteException e)
                {
                    return "FAILED TO RETRIEVE DATA: " + e.Message.ToString();
                }

                return json;
            };

        }
    }
}