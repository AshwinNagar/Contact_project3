using Dapper;
using NuGet.Protocol.Plugins;
using Student_Project.Models;
using Student_Project.Repository.ConnectionData;

namespace Student_Project.Repository.Implementation
{

    public class StudentRepository : BaseRepository, IStudetnRepository
    {
        public int AddContact(Student student)
        {
            var contacts = new List<Student>();
            using (var connetion = GetConnection())
            {
                connetion.Open();
                string sql = "INSERT INTO ContactApp (FirstName, LastName , Email , Phone) VALUES (@FirstName , @LastName,@Email,@Phone)";
                return connetion.Execute(sql, student);
            }
        }

        public void DeleteContact(int studentId)
        {
            using (var connetion = GetConnection())
            {
                connetion.Open();
                var sql = "DELETE FROM ContactApp WHERE Id = @StudentId";
                connetion.Execute(sql, new { studentId });
            }
        }

        public Student GetStudent(int studentId)
        {

            using (var connetion = GetConnection())
            {
                connetion.Open();
                string sql = "SELECT * FROM ContactApp WHERE Id = @StudentId";
                return connetion.QueryFirstOrDefault<Student>(sql, new { studentId });
            }
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>();
            using (var connetion = GetConnection())
            {
                connetion.Open();
                var sql = "SELECT * FROM ContactApp";
                return connetion.Query<Student>(sql).ToList();
            }
        }


        public List<Student> GetSearch(string searching)
        {
            var students = new List<Student>();
            using (var connetion = GetConnection())
            {
                connetion.Open();
                var sql = "SELECT * FROM ContactApp WHERE FirstName like '%' +@searching+'%' " +
                          "OR LastName like '%'+@searching+'%'" +
                          " OR Email like '%'+@searching+'%' " +
                          "OR Phone like '%' + @searching + '%'"; ;
                return connetion.Query<Student>(sql, new { searching }).ToList();
            }
        }

        public void UpdateContact(Student student)
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                var sql = "UPDATE ContactApp SET FirstName = @FirstName , LastName = @LastName, Email = @Email, Phone = @Phone WHERE Id = @Id";
                connection.Execute(sql, student);
            }
        }
    }
}
