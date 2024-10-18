using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_information_system_2.Data;
using Student_information_system_2.Models;

namespace Student_information_system_2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbcontext dbContext;

        public StudentController(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,

                dob = viewModel.dob,

                phone = viewModel.phone,

                email = viewModel.email,

                password = viewModel.password,

                major = viewModel.major,
            };

            await dbContext.Student.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var student = await dbContext.Student.ToListAsync();

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Student.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Student.FindAsync(viewModel.Id);

            if(student is not null)
            {
                student.Name = viewModel.Name;
                student.dob = viewModel.dob;
                student.phone = viewModel.phone;
                student.email = viewModel.email;
                student.password = viewModel.password;
                student.major = viewModel.major;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Student.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if(student is not null)
            {
                dbContext.Student.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }
    }
}
