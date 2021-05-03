using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Practice3.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentsController : ControllerBase
    {
        public StudentsController()
        {
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            List<Student> listStudents = new List<Student>();
            listStudents.Add(new Student { Name = "Mayra Oropeza" });
            listStudents.Add(new Student { Name = "Rafaela Gumiel" });
            listStudents.Add(new Student { Name = "Mauricio Angulo" });
            listStudents.Add(new Student { Name = "Fabricio Fernandez" });
            listStudents.Add(new Student { Name = "Camila Medina" });
            return listStudents;
        }

        [HttpPost]
        public Student CreateStudent([FromBody] string studentName)
        {
            return new Student()
            {
                Name = studentName
            };
        }

        [HttpPut]
        public Student UpdateStudent([FromBody] Student student)
        {
            Console.WriteLine("Updated");
            student.Name = "UPDATED";
            return student;
        }

        [HttpDelete]
        public Student DeleteStudent([FromBody] Student student)
        {
            Console.WriteLine("Deleted");
            return student;
        }
    }
}
