
using System.Data.SqlClient;


namespace Student_Project.Repository.ConnectionData
{
    public class BaseRepository
    {
        private readonly string _connectionData = "Data Source=DESKTOP-Q1HMHTB\\SQLEXPRESS;Initial Catalog=CONTACTAPPDATA;Integrated Security=true;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionData);
        }

    }
}
