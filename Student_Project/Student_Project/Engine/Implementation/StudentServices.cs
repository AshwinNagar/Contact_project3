using Student_Project.Engine.Contact;
using Student_Project.Models;
using Student_Project.Repository;
using Student_Project.Repository.Implementation;

namespace Student_Project.Engine.Implementation
{
    public class StudentServices: IStudentServices
    {
        private readonly IStudetnRepository _repositry;
        public StudentServices(IStudetnRepository repositry)
        {
            _repositry = repositry;
        }

        public void DeleteContact(int id)
        {
            _repositry.DeleteContact(id);
        }

        public List<Student> GetAll()
        {
            return _repositry.GetStudents();
        }

        public Student GetStudent(int id)
        {
            return _repositry.GetStudent(id);
        }

        public List<Student> GetSearch(string searching)
        {

            return _repositry.GetSearch(searching);
        }

        public void SaveContact(Student student)
        {
            if (student.Id != 0)
            {
                _repositry.UpdateContact(student);
            }
            else
            {
                _repositry.AddContact(student);
            }
        }
    }
}
