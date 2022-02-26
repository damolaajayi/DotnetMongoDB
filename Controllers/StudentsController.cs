using DotnetMongoDB.Models;
using DotnetMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService? _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return _studentService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);
            if(student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return student;

        }

        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            _studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id });
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = _studentService.Get(id);
            if(existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            _studentService.Update(id, student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            _studentService.Remove(student.Id);
            return Ok($"Student with Id = {id} deleted");
        }

    }
}
