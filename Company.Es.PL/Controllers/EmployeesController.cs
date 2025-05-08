using AutoMapper;
using Company.Es.BLL.Interfaces;
using Company.Es.DAL.Models;
using Company.Es.DAL.Specifications;
using Company.Es.DAL.Specifications.Departments;
using Company.Es.DAL.Specifications.Employees;
using Company.Es.PL.Helper;
using Company.Es.PL.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Company.Es.PL.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        //private readonly IEmployeeRepo employeeRepo;
        //private readonly IDepartmentRepo departmentRepo;

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public EmployeesController(
            //IEmployeeRepo employeeRepo, 
            //IDepartmentRepo departmentRepo,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            //this.employeeRepo = employeeRepo;
            //this.departmentRepo = departmentRepo;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index(string name)
        {
            var emps = Enumerable.Empty<Employee>();
            if (!string.IsNullOrEmpty(name))
            {
                emps = await unitOfWork.EmployeeRepo.SearchByNameAsync(name);
            }
            else
            {
                var spec = new EmployeeSpecifications();
                emps = await unitOfWork.EmployeeRepo.GetAllWithSpecAsync(spec);
            }
            var empsVM = mapper.Map<IEnumerable<EmployeeViewModel>>(emps);
            
            return View(empsVM);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var spec = new DepartmentSpecifications();

            var depts = await unitOfWork.DepartmentRepo.GetAllWithSpecAsync(spec);
            ViewData["departments"] = depts;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Image is not null)
                {
                    var fileName = DocumentSettings.Upload(model.Image, "Images");
                    model.ImageName = fileName;
                }
                Employee emp = mapper.Map<Employee>(model);
                await unitOfWork.EmployeeRepo.AddAsync(emp);
                int count = await unitOfWork.SaveAsync();

                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest();
            var spec = new EmployeeSpecifications(id.Value);
            var emp = await unitOfWork.EmployeeRepo.GetWithSpecAsync(spec);
            if (emp is null) return NotFound();
            var empVM = mapper.Map<EmployeeViewModel> (emp);
            return View(empVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

                var emp = mapper.Map<Employee>(model);
                unitOfWork.EmployeeRepo.Delete(emp);
                int count = await unitOfWork.SaveAsync();
                if (count > 0)
                {
                    if (model.ImageName is not null)
                    {
                        DocumentSettings.Delete(model.ImageName, "images");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var spec = new DepartmentSpecifications();
            var departments = await unitOfWork.DepartmentRepo.GetAllWithSpecAsync(spec);
            ViewData["departments"] = departments;
            return await Details(id, "Update");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.ImageName is not null)
                {
                    DocumentSettings.Delete(model.ImageName, "images");
                }
                if(model.Image is not null)
                {
                    model.ImageName = DocumentSettings.Upload(model.Image, "images");
                }
                var emp = mapper.Map<Employee>(model);
                unitOfWork.EmployeeRepo.Update(emp);
                int count = await unitOfWork.SaveAsync();
                
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

    }
}
