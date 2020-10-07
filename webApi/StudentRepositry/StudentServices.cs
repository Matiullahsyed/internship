using StudentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepositry
{
    public class StudentServices
    {

        public IEnumerable<Student> GetStudents()
        {
            using ( var _context = new SchoolContext())
            {
                var students = _context.Students.ToList();
                return students;

            }
        }
          
        public Student GetStudent(int id)
        {
            using (var _context= new SchoolContext())
            {
                

                return _context.Students.SingleOrDefault(c => c.Id == id);
                
            }
        }
        public void AddStudent(Student student)
        {
            
            using (var _context = new SchoolContext())
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
        }
        public void DeleteStudent(int id)
        {
            using (var _context = new SchoolContext())
            {
                var studentToDelete = _context.Students.FirstOrDefault(s => s.Id == id);
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }

        }
        public void UpdateStudent(Student student)
        {
            using (var _context = new SchoolContext())
            {
                var students = _context.Students.ToList();
                var studentToUpdate = students.FirstOrDefault(s => s.Id == student.Id);
                studentToUpdate.Name = student.Name;
                studentToUpdate.Email = student.Email;
                studentToUpdate.Contact = student.Contact;
                studentToUpdate.Password = student.Password;
                studentToUpdate.ConfirmPassword = student.ConfirmPassword;

                _context.SaveChanges();
            }

        }
    }

}
