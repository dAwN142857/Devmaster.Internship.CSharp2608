using Ex04.StudentManagement.Services;
using Ex04.StudentManagement.Views;
using Ex04.StudentManagement.Validators;

namespace Ex04.StudentManagement.Managers
{
    public class MenuManager
    {
        private readonly StudentService _service = new StudentService();
        private readonly StudentConsoleView _view;

        public MenuManager()
        {
            _view = new StudentConsoleView(_service);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n================ QUAN LY SINH VIEN ================");
                Console.WriteLine("1. Them sinh vien            8. Sap xep theo diem TB");
                Console.WriteLine("2. Hien thi danh sach       9. Sinh vien diem >= 8");
                Console.WriteLine("3. Tim theo ma               10. Sinh vien diem cao nhat");
                Console.WriteLine("4. Tim kiem theo ten        11. Tinh diem TB toan bo SV");
                Console.WriteLine("5. Cap nhat sinh vien       12. Thong ke theo nganh");
                Console.WriteLine("6. Xoa sinh vien            13. Thong ke theo trang thai");
                Console.WriteLine("7. Sap xep theo ho ten       0. Thoat");

                int choice = InputHelper.ReadInt("Lua chon (0-13): ", 0, 13);
                switch (choice)
                {
                    case 1: _view.InputNewStudent(); break;
                    case 2: _view.DisplayList(_service.GetAll()); break;
                    case 3:
                        string id = InputHelper.ReadString("Nhap ma SV: ");
                        var st = _service.FindById(id);
                        Console.WriteLine(st != null ? st.ToString() : "Khong tim thay!");
                        break;
                    case 4:
                        string kw = InputHelper.ReadString("Nhap tu khoa ten: ");
                        _view.DisplayList(_service.SearchByName(kw));
                        break;
                    case 5:
                        string upId = InputHelper.ReadString("Nhap ma SV can cap nhat: ");
                        if (_service.FindById(upId) == null) Console.WriteLine("Khong tim thay!");
                        else
                        {
                            _service.Delete(upId);
                            _view.InputNewStudent();
                        }
                        break;
                    case 6:
                        string delId = InputHelper.ReadString("Nhap ma SV can xoa: ");
                        Console.WriteLine(_service.Delete(delId) ? "Xoa thanh cong!" : "Khong tim thay!");
                        break;
                    case 7: _view.DisplayList(_service.SortByName()); break;
                    case 8: _view.DisplayList(_service.SortByGpa()); break;
                    case 9: _view.DisplayList(_service.GetHighGpaStudents()); break;
                    case 10: _view.DisplayList(_service.GetTopStudents()); break;
                    case 11: Console.WriteLine($"Diem TB toàn truong: {_service.GetAverageGpa():F2}"); break;
                    case 12:
                        foreach (var kv in _service.CountByMajor())
                            Console.WriteLine($"Nganh {kv.Key}: {kv.Value} sinh vien");
                        break;
                    case 13:
                        foreach (var kv in _service.CountByStatus())
                            Console.WriteLine($"Trang thai {kv.Key}: {kv.Value} sinh vien");
                        break;
                    case 0: return;
                }
            }
        }
    }
}