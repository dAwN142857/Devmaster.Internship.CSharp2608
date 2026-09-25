using Microsoft.AspNetCore.Mvc;
using NguyenDuyAn_Lesson06_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using NguyenDuyAn_Lesson06_Model; // Thay Tên_Project_Của_Bạn bằng tên Project thực tế của bạn

namespace NguyenDuyAn_Lesson06_Model.Controllers
{
    public class NguyenDuyAn_MemberController : Controller
    {
        // 1. Khởi tạo danh sách dữ liệu tĩnh (Mock Data) gồm 5 bản ghi mẫu
        private static readonly List<NguyenDuyAn_Member> memberList = new List<NguyenDuyAn_Member>()
        {
            new NguyenDuyAn_Member
            {
                NguyenDuyAn_MemberID = Guid.NewGuid().ToString(),
                NguyenDuyAn_Username = "nguyenduyan",
                NguyenDuyAn_Password = "123",
                NguyenDuyAn_FullName = "Nguyễn Duy An",
                NguyenDuyAn_Email = "duyan@gmail.com"
            },
            new NguyenDuyAn_Member
            {
                NguyenDuyAn_MemberID = Guid.NewGuid().ToString(),
                NguyenDuyAn_Username = "van_a",
                NguyenDuyAn_Password = "123",
                NguyenDuyAn_FullName = "Trần Văn A",
                NguyenDuyAn_Email = "vana@gmail.com"
            },
            new NguyenDuyAn_Member
            {
                NguyenDuyAn_MemberID = Guid.NewGuid().ToString(),
                NguyenDuyAn_Username = "thi_b",
                NguyenDuyAn_Password = "123",
                NguyenDuyAn_FullName = "Lê Thị B",
                NguyenDuyAn_Email = "thib@gmail.com"
            },
            new NguyenDuyAn_Member
            {
                NguyenDuyAn_MemberID = Guid.NewGuid().ToString(),
                NguyenDuyAn_Username = "van_c",
                NguyenDuyAn_Password = "123",
                NguyenDuyAn_FullName = "Phạm Văn C",
                NguyenDuyAn_Email = "vanc@gmail.com"
            },
            new NguyenDuyAn_Member
            {
                NguyenDuyAn_MemberID = Guid.NewGuid().ToString(),
                NguyenDuyAn_Username = "thi_d",
                NguyenDuyAn_Password = "123",
                NguyenDuyAn_FullName = "Hoàng Thị D",
                NguyenDuyAn_Email = "thid@gmail.com"
            }
        };

        // 2. Action lấy chi tiết 1 đối tượng truyền ra View
        public IActionResult GetDetail()
        {
            var member = memberList.FirstOrDefault(); // Lấy bản ghi đầu tiên (thông tin của bạn)
            return View(member);
        }
        public IActionResult Index()
        {
            return View(memberList);
        }
        // [GET] Hiển thị Form thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost] Nhận dữ liệu submit từ Form và lưu vào danh sách
        [HttpPost]
        public IActionResult Create(NguyenDuyAn_Member member)
        {
            member.NguyenDuyAn_MemberID = Guid.NewGuid().ToString(); // Sinh mã ID tự động
            memberList.Add(member); // Thêm thành viên mới vào danh sách
            return RedirectToAction("Index"); // Chuyển hướng quay về trang Danh sách
        }
        // [GET] Lấy thông tin thành viên theo ID và hiển thị lên Form Edit
        public IActionResult Edit(string id)
        {
            var member = memberList.FirstOrDefault(x => x.NguyenDuyAn_MemberID.Equals(id));
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // [HttpPost] Nhận dữ liệu đã chỉnh sửa và cập nhật vào danh sách
        [HttpPost]
        public IActionResult Edit(NguyenDuyAn_Member member)
        {
            var item = memberList.FirstOrDefault(x => x.NguyenDuyAn_MemberID.Equals(member.NguyenDuyAn_MemberID));
            if (item != null)
            {
                item.NguyenDuyAn_Username = member.NguyenDuyAn_Username;
                item.NguyenDuyAn_Password = member.NguyenDuyAn_Password;
                item.NguyenDuyAn_FullName = member.NguyenDuyAn_FullName;
                item.NguyenDuyAn_Email = member.NguyenDuyAn_Email;
            }
            return RedirectToAction("Index"); // Quay về trang danh sách
        }
    }
}