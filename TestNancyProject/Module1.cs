using Nancy;
using System.Data.SQLite;
using System.Data;


namespace TestNancyProject
{
    public class Module1 : NancyModule
    {
        public Module1()
        {
            Get["/"] = _ => "Hello!";
        }

        //public static void CreateDB()
        //{
        //    SQLiteConnection.CreateFile("MyDatabase.sqlite");

        //    SQLiteConnection m_dbConnection;

        //    m_dbConnection =
        //    new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        //    m_dbConnection.Open();
        //}
    }
}