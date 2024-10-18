using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_information_system_2.Data;
using Student_information_system_2.Models;

namespace Student_information_system_2.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbcontext dbContext;

        public CourseController(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCourse() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseViewModel viewModel)
        {
            var course = new Course
            {
                Name = viewModel.Name,

                CreditHours = viewModel.CreditHours,
            };

            await dbContext.Course.AddAsync(course);
            await dbContext.SaveChangesAsync();
            //return RedirectToAction("ListCourses", "Course");
            return View();
        }
    }
}
