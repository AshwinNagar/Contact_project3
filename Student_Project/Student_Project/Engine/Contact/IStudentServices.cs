using Student_Project.Models;

namespace Student_Project.Engine.Contact
{
    public interface IStudentServices
    {
        List<Student> GetAll();
        void SaveContact(Student student);
        void DeleteContact(int id);
        Student GetStudent(int id);
        List<Student> GetSearch(string searching);
    }
}
