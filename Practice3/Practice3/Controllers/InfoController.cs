using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Practice3.Controllers
{
    [ApiController]
    [Route("/api/info")]
    public class InfoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public InfoController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]

        public string GetInfo()
        {
            string projectTitle = _config.GetSection("ProjectTitle").Value;
            string enviromentName = _config.GetSection("EnvironmentName").Value;
            string dbConnection = _config.GetConnectionString("Database");
            Console.Out.WriteLine($"Connection string to ... {dbConnection}");
            return $"ProjectTitle: {projectTitle} \n" +
                $"EnvironmentName: {enviromentName}"; ;
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
