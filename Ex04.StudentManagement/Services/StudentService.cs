using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Models;

namespace Ex04.StudentManagement.Services
{
    public class StudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public List<Student> GetAll() => _students;

        public bool Add(Student student)
        {
            if (_students.Any(s => s.studentId.Equals(student.studentId, StringComparison.OrdinalIgnoreCase)))
                return false;
            _students.Add(student);
            return true;
        }

        public Student? FindById(string id)
        {
            return _students.FirstOrDefault(s => s.studentId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Student> SearchByName(string keyword)
        {
            return _students.Where(s => s.fullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool Update(string id, Student updated)
        {
            var st = FindById(id);
            if (st == null) return false;
            st.fullName = updated.fullName;
            st.dateOfBirth = updated.dateOfBirth;
            st.gender = updated.gender;
            st.email = updated.email;
            st.phoneNumber = updated.phoneNumber;
            st.major = updated.major;
            st.gpa = updated.gpa;
            st.status = updated.status;
            return true;
        }

        public bool Delete(string id)
        {
            var st = FindById(id);
            if (st == null) return false;
            _students.Remove(st);
            return true;
        }

        public List<Student> SortByName() => _students.OrderBy(s => s.fullName).ToList();

        public List<Student> SortByGpa() => _students.OrderByDescending(s => s.gpa).ToList();

        public List<Student> GetHighGpaStudents() => _students.Where(s => s.gpa >= 8.0).ToList();

        public List<Student> GetTopStudents()
        {
            if (!_students.Any()) return new List<Student>();
            double maxGpa = _students.Max(s => s.gpa);
            return _students.Where(s => s.gpa == maxGpa).ToList();
        }

        public double GetAverageGpa() => _students.Any() ? _students.Average(s => s.gpa) : 0;

        public Dictionary<string, int> CountByMajor() =>
            _students.GroupBy(s => s.major).ToDictionary(g => g.Key, g => g.Count());

        public Dictionary<StudentStatus, int> CountByStatus() =>
            _students.GroupBy(s => s.status).ToDictionary(g => g.Key, g => g.Count());
    }
}