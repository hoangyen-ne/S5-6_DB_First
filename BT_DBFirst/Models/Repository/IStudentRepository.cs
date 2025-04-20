using BT_DBFirst.Models.Domain;
using BT_DBFirst.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BT_DBFirst.Models.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll(string? searchString, string? type);
        VMStudent GetStudentsById(int id);
        void UpdateStudentById(int id, VMStudent model);
        void AddStudent(VMStudent model);
        void DeleteStudentById(int id);
    }
}