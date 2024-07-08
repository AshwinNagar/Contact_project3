using Student_Project.Models;

namespace Student_Project.Repository
{
    public interface IStudetnRepository
    {
        List<Student> GetStudents();
        Student GetStudent(int studentId);
        int AddContact(Student student);
        void UpdateContact(Student student);

        void DeleteContact(int studentId);
        List<Student> GetSearch(string searching);

    }
}
