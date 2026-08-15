using System.Globalization;

namespace Ex04.StudentManagement.Validators
{
    public static class InputHelper
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val) && val >= min && val <= max)
                    return val;
                Console.WriteLine($"Vui long nhap so nguyen tu {min} den {max}.");
            }
        }

        public static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double val)
                    && val >= min && val <= max)
                    return val;
                Console.WriteLine($"Vui long nhap so thuc tu {min} den {max}.");
            }
        }

        public static DateTime ReadDateTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                    return dt;
                Console.WriteLine("Dinh dang ngay khong hop le (dd/MM/yyyy).");
            }
        }
    }
}