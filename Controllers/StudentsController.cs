using DotnetMongoDB.Interfaces;
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
        private readonly ICourseService? _courseService;

        public StudentsController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Student>> Get(string id)
        {
            var student = await _studentService.Get(id);
            if(student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            if(student.Courses.Count > 0)
            {
                var tempList = new List<Course>();
                foreach (var courseId in student.Courses)
                {
                    var course = await _courseService.Get(courseId);
                    if (course != null)
                        tempList.Add(course);
                }
                student.CourseList = tempList;
            }
            return Ok(student);

        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Student student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _studentService.Create(student);
            return Ok(student);
        }

        [HttpPut]
        public async Task<ActionResult> Put(string id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingStudent = _studentService.Get(id);
            if(existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            await _studentService.Update(id, student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var student = await _studentService.Get(id);
            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            await _studentService.Remove(id);
            return Ok($"Student with Id = {id} deleted");
        }

    }
}
