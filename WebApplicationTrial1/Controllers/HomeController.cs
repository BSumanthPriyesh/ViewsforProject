using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrial1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationTrial1.Data;

namespace WebApplicationTrial1.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        WebApplicationTrial1Context dbContext;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ImportByValue()
        {
            //Basic Select
            //Get all the records from Enrollments table.
            // List<Enrollment> allrecords = new List<Enrollment>();
            //allrecords = dbContext.Enrollments.ToList();
            //List<Enrollment> allrecords = dbContext.Enrollments.ToList();
            //Console.WriteLine("Feteched all Records"); 
           /* ViewData["title"] = "ImportByValue";
            ViewData["data"] = allrecords;
            return View("allrecords");*/
            return View();
        }

        public async Task<IActionResult> ImportByQuantity()
        {
            // Query 3: Select Query to get all the records from Enrollments table.
            /*List<Enrollment> allrecords = dbContext.Enrollments.Include(s => s.Student).Include(s => s.Course).Include(s => s.Course.College).ToList();
            Console.WriteLine("Feteched Records");
            ViewData["title"] = "All Records";
            ViewData["data"] = allrecords;
            return View("data");*/
            return View();
        }

        public IActionResult Learnmorewithjs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        void populateData()
        {
            Random rnd = new Random();

            string[] Colleges = {
                                 "Muma College of Business, MCOB",
                                 "College of Engineering, CoE",
                                 "College of Arts and Sciences, CAS",
                                 "College of Nursing, CON",
                                 "Morsani College of Medicine,MCOM",
                                 "College of Public Health,COPH"
            };
            string[] Courses = {
                "ISM 6225, Distributed Information Systems",
                "ISM 6218, Advanced Database Management Systems",
                "ISM 6137, Statistical Data Mining",
                "ISM 6419, Data Visualization",
                "ISM 6930, Blockchain Fundamentals",
                "ISM 6562, Big Data for Business",
                "ISM 6328, Information Security and IT Risk Management",
                "QMB 6304, Analytical Methods For Business",
                "ISM 6136, Data Mining",
                "NUR 3125, Pathophysiology for Nursing Practice",
                "NUR 3145, Pharmacology in Nursing Practice",
                "NUR 4165, Nursing Inquiry",
                "NUR 3078, Information Technology Skills for Nurses",
                "NUR 4169, Evidence-Based Practice for Baccalaureate Prepared Nurse",
                "NUR 4634, Population Health",
                "NSP 3147, Web-Based Education for Staff Development"

            };

            string[] Students = {
                "Monica", "Sara","Adam","Jude","Callie","Ross","Stark",
                "Chandler","Phoebe","Carrie","Tristan","sally","Robert",
                "Sid","Warner","Joey","Andy","Conner","Ruby","Kate"
            };
            string[] Grades = { "A", "A-", "B+", "B", "B-" };
            int[] scores = { 95, 91, 87, 82, 75, 66, 55, 80, 63, 90, 45, 60 };

            College[] colleges = new College[Colleges.Length];
            Course[] courses = new Course[Courses.Length];
            Student[] students = new Student[Students.Length];

            for (int i = 0; i < Colleges.Length; i++)
            {
                College college = new College
                {
                    Name = Colleges[i].Split(",")[0],
                    Abbreviation = Colleges[i].Split(",")[1]
                };

                dbContext.Colleges.Add(college);
                colleges[i] = college;
            }

            for (int i = 0; i < Courses.Length; i++)
            {
                Course course = new Course
                {

                    Number = Courses[i].Split(",")[0],
                    Name = Courses[i].Split(",")[1],
                    College = colleges[rnd.Next(colleges.Length)]
                };

                dbContext.Courses.Add(course);
                courses[i] = course;
            }

            for (int i = 0; i < Students.Length; i++)
            {
                Student student = new Student
                {
                    Name = Students[i]
                };

                dbContext.Student.Add(student);
                students[i] = student;
            }

            foreach (Student student in students)
            {
                foreach (Course course in courses)
                {
                    Enrollment enrollment = new Enrollment
                    {
                        Course = course,
                        Student = student,
                        Grade = Grades[rnd.Next(Grades.Length)],
                        score = scores[rnd.Next(scores.Length)]
                    };

                    dbContext.Enrollments.Add(enrollment);
                }
            }

            dbContext.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}