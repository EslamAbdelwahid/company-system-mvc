using Company.Es.BLL.Interfaces;
using Company.Es.DAL.Models;
using Company.Es.DAL.Specifications.Departments;
using Company.Es.DAL.Specifications.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Es.PL.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var spec = new DepartmentSpecifications();
            var departments = await unitOfWork.DepartmentRepo.GetAllWithSpecAsync(spec);
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department model)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.DepartmentRepo.AddAsync(model);
                int count = await unitOfWork.SaveAsync();
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var spec = new DepartmentSpecifications(id.Value);

            var dept = await unitOfWork.DepartmentRepo.GetWithSpecAsync(spec);
            return View(dept);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var spec = new DepartmentSpecifications(id.Value);

            var dept = await unitOfWork.DepartmentRepo.GetWithSpecAsync(spec);
            return View(dept);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id, Department model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                // Get the tracked department instance
                var spec = new DepartmentSpecifications(id.Value);

                var department = await unitOfWork.DepartmentRepo.GetWithSpecAsync(spec);

                if (department == null) return NotFound();

                // Update employees
                var nwSpec = new EmployeeSpecifications();
                var emps = (await unitOfWork.EmployeeRepo.GetAllWithSpecAsync(nwSpec))
                          .Where(e => e.WorkForId == id);

                foreach (var e in emps)
                {
                    e.WorkForId = null;
                    e.WorkFor = null;
                }

                // Delete the tracked instance
                unitOfWork.DepartmentRepo.Delete(department);

                int count = await unitOfWork.SaveAsync();
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var spec = new DepartmentSpecifications(id.Value);

            var dept = await unitOfWork.DepartmentRepo.GetWithSpecAsync(spec);
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Department model)
        {
            if (ModelState.IsValid)
            {
                 unitOfWork.DepartmentRepo.Update(model);
                int count = await unitOfWork.SaveAsync();
                if(count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }


    }
}
