using System.Text.RegularExpressions;

namespace Ex04.StudentManagement.Validators
{
    public static class StudentValidator
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return Regex.IsMatch(phone, @"^[0-9]{10,11}$");
        }

        public static bool IsValidGpa(double gpa)
        {
            return gpa >= 0.0 && gpa <= 10.0;
        }
    }
}