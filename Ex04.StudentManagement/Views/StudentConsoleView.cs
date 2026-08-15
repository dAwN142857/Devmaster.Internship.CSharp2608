using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Models;
using Ex04.StudentManagement.Services;
using Ex04.StudentManagement.Validators;

namespace Ex04.StudentManagement.Views
{
    public class StudentConsoleView
    {
        private readonly StudentService _service;

        public StudentConsoleView(StudentService service)
        {
            _service = service;
        }

        public void InputNewStudent()
        {
            Console.WriteLine("\n--- THEM SINH VIEN MOI ---");
            string id;
            while (true)
            {
                id = InputHelper.ReadString("Ma sinh vien: ");
                if (string.IsNullOrWhiteSpace(id)) Console.WriteLine("Ma SV khong duoc de rong!");
                else if (_service.FindById(id) != null) Console.WriteLine("Ma SV da ton tai!");
                else break;
            }

            string name = InputHelper.ReadString("Ho ten: ");
            DateTime dob = InputHelper.ReadDateTime("Ngay sinh (dd/MM/yyyy): ");
            Gender gender = (Gender)InputHelper.ReadInt("Gioi tinh (1: Male, 2: Female, 3: Other): ", 1, 3);

            string email;
            while (true)
            {
                email = InputHelper.ReadString("Email: ");
                if (StudentValidator.IsValidEmail(email)) break;
                Console.WriteLine("Email khong hop le!");
            }

            string phone = InputHelper.ReadString("So dien thoại: ");
            string major = InputHelper.ReadString("Nganh hoc: ");
            double gpa = InputHelper.ReadDouble("Diem trung binh (0.0 - 10.0): ", 0.0, 10.0);
            StudentStatus status = (StudentStatus)InputHelper.ReadInt("Trang thai (1: Active, 2: Inactive, 3: Graduated, 4: Suspended): ", 1, 4);

            var st = new Student
            {
                studentId = id,
                fullName = name,
                dateOfBirth = dob,
                gender = gender,
                email = email,
                phoneNumber = phone,
                major = major,
                gpa = gpa,
                status = status
            };

            _service.Add(st);
            Console.WriteLine("=> Them sinh vien thanh cong!");
        }

        public void DisplayList(List<Student> list)
        {
            if (!list.Any())
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }
            Console.WriteLine(new string('-', 100));
            foreach (var st in list)
            {
                Console.WriteLine(st.ToString());
            }
            Console.WriteLine(new string('-', 100));
        }
    }
}