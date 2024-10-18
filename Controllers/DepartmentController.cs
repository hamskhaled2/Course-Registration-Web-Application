using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_information_system_2.Data;
using Student_information_system_2.Models;

namespace Student_information_system_2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbcontext dbContext;

        public DepartmentController(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentViewModel DepartmentViewModel)
        {
            var department = new Department
            {
                Id = DepartmentViewModel.Id,

                Name = DepartmentViewModel.Name,

                Description = DepartmentViewModel.Description,
            };

            await dbContext.Department.AddAsync(department);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListDepartments", "Department");

        }

        [HttpGet]
        public async Task<IActionResult> ListDepartments()
        {
            var department = await dbContext.Department.ToListAsync();

            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> EditDepartment(int id)
        {
            var department = await dbContext.Department.FindAsync(id);

            return View(department);
        }

        [HttpPost]

        public async Task<IActionResult> EditDepartment(Department viewModel)
        {
            var department = await dbContext.Department.FindAsync(viewModel.Id);

            if (department is not null)
            { 
                department.Name = viewModel.Name;
                department.Description = viewModel.Description;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListDepartments", "Department");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(Department viewModel)
        {
            var department = await dbContext.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if(department is not null)
            {
                dbContext.Department.Remove(department);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ListDepartments", "Department");
        }
    }
}
