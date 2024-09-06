using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentViewTemplatesApp.Models;

namespace StudentViewTemplatesApp.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : Controller
    {
        // GET: Student
        static List<Student> students = new List<Student>()
        {
            new Student{ Id = 1 , Name = "Samuel" , Age = 21 , Address = new Address{Id = 101 ,Country = "India" , State = "Maharashtra" , City = "Mumbai"}},
            new Student{ Id = 2 , Name = "Nimith" , Age = 22 , Address = new Address{Id = 102 , Country = "Australia", State = "New South Wales", City = "Sydney"} },
            new Student{ Id = 3 , Name = "Sreerag" , Age = 24 , Address = new Address{Id = 103 ,Country = "Canada", State = "Ontario", City = "Toronto"}},
            new Student{ Id = 4 , Name = "Swamini" , Age = 21 , Address = new Address{Id = 104 ,Country = "Germany", State = "Bavaria", City = "Munich"}},
            new Student{ Id = 5 , Name = "Swati" , Age = 23 , Address = new Address{Id = 105 , Country = "USA", State = "California", City = "San Francisco"}}
        };

        [Route("")]
        public ActionResult GetAllStudents()
        {
            return View(students);
        }
        [Route("{id:int}")]
        public ActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(st => st.Id == id);
            return View(student);
        }
        [Route("address/{id}")]
        public ActionResult GetAddressOfStudentById(int id)
        {
            var studentAddress = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();
            return View(studentAddress);
        }

        [HttpGet]
        public ActionResult Edit(int id )
        {
            var item = students.Where(stu => stu.Id == id).FirstOrDefault();
            return View(item);

        }
        [HttpPost]
        public ActionResult Edit(int id , Student updatedStudent)
        {
            var item = students.Where(stu => stu.Id == id).FirstOrDefault();
            item.Name = updatedStudent.Name;
            item.Age = updatedStudent.Age;
            return RedirectToAction("");

        }
        public ActionResult Delete(int id)
        {
            
            var item = students.Where(stu => stu.Id == id).FirstOrDefault();
            students.Remove(item);
            return RedirectToAction("");
        }


        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(Student updatedStudent)
        {
            if (ModelState.IsValid)
            {
                students.Add(updatedStudent);
                return RedirectToAction("");
            }
            return View("Create" , updatedStudent);

        }

        public ActionResult Details(int id)
        {
            var item = students.Where(stu => stu.Id == id).FirstOrDefault();
            return Content("<h1> Student Id : " +  item.Id + "</br>" + "Student Name : "+item.Name + "</br>" + "Student Age : "+item.Age + "</h1>");
        }

   
        public ActionResult AddAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Id == id);
            if (student == null)
            {
                return HttpNotFound("Student not found");
            }
            ViewBag.StudentId = id; 
            return View(new Address { Id = student.Id });
        }

        [HttpPost]
        public ActionResult AddAddress(int id, Address address)
        {
            var student = students.FirstOrDefault(st => st.Id == id);
            if (student == null)
            {
                return HttpNotFound("Student not found");
            }
            if (ModelState.IsValid)
            {
                student.Address = address;
                return RedirectToAction("GetAllStudents");
            }
            return View("AddAddress", address);
            
        }
        public ActionResult Address(int id)
        {
            var item = students.Where(stu => stu.Id == id).FirstOrDefault();
            if(item.Address == null)
            {
                return RedirectToAction("AddAddress", new { id = item.Id });
            }
            return View(item.Address);
        }

        public ActionResult DeleteAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Address.Id == id);

            if (student == null)
            {
                return HttpNotFound("Address not found");
            }

            student.Address = null;

            return RedirectToAction("");
        }

        public ActionResult EditAddress(int id)
        {
            var item = students.Where(stu => stu.Id == id).FirstOrDefault();
            return View(item);

        }
        [HttpPost]
        public ActionResult EditAddress(int id, Address updatedAddress)
        {
            var student = students.FirstOrDefault(st => st.Address.Id == id);

            if (student == null || student.Address == null)
            {
                return HttpNotFound("Address not found");
            }
            if (ModelState.IsValid)
            {

                student.Address.Country = updatedAddress.Country;
            student.Address.State = updatedAddress.State;
            student.Address.City = updatedAddress.City;


            return RedirectToAction("GetAllStudents");
            }
            return View("EditAddress", updatedAddress);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}