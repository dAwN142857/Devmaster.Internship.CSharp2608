
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 101,
                    Name = "Hải Nam",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "nam@gmail.com",
                    Mark = 8.0
                },
                new Student()
                {
                    Id = 102,
                    Name = "Minh Tú",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2019",
                    Email = "tu@gmail.com",
                    Mark = 7.5
                },
                new Student()
                {
                    Id = 103,
                    Name = "Hoàng Phong",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "A1-2020",
                    Email = "phong@gmail.com",
                    Mark = 9.0
                },
                new Student()
                {
                    Id = 104,
                    Name = "Xuân Mai",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A1-2021",
                    Email = "mai@gmail.com",
                    Mark = 8.5
                }
            };
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewData();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last().Id + 1;
                listStudents.Add(s);

                return View("Index", listStudents);
            }

            LoadViewData();
            return View(s);
        }

        public IActionResult List()
        {
            return View("Index", listStudents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            LoadViewData();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Add(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last().Id + 1;
                listStudents.Add(s);

                return View("Index", listStudents);
            }

            LoadViewData();
            return View("Create", s);
        }

        private void LoadViewData()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };
        }
    }
}