using APP_BUS_L_10.Services.Departments;
using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Services.Employees;
using APP_DATA_A_10.Services.Employees.Dtos;
using App_User_10.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_User_10.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
        {
            private readonly IEmployeeService _employeeService;
            private readonly ILogger<EmployeeController> _logger;
            private readonly IWebHostEnvironment _environment;
       


        public EmployeeController(
                IEmployeeService employeeService,
                ILogger<EmployeeController> logger,
                IWebHostEnvironment environment
               )
            {
            _employeeService = employeeService;
          
            this._logger = logger;
                this._environment = environment;
            }


        // ==========================================================
        // GET: Employee/Index
        // ==========================================================
        [HttpGet]
        public IActionResult Index(string? EmployeeSearchName)
        {

            var employees = _employeeService.GetAll(EmployeeSearchName);
            return View(employees);
        }

        // ==========================================================
        // GET: Employee/Details/5
        // ==========================================================
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _employeeService.GetById(id.Value);

            if (employee is null)
                return NotFound();

            return View(employee);
        }

        // ==========================================================
        // GET: Employee/Create
        // ==========================================================
        //[HttpGet]
        //public IActionResult Create()
        //{


        //    return View();
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateEmployeeDto());   // ✅
        }



        [HttpPost]
        public IActionResult Create(CreateEmployeeDto dbo)
        {
            string message = string.Empty;

            if (!ModelState.IsValid)
            {
              
                return View(dbo);
            }

            try
            {
                var result = _employeeService.Add(dbo);
                if (result > 0)
                    return RedirectToAction(nameof(Index));

                message = "Error is not found";
                ModelState.AddModelError(string.Empty, message);
              
                return View(dbo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    ModelState.AddModelError(string.Empty, message);
                   
                    return View(dbo);
                }

                return View("Error", "Employee not is error");
            }
        }

        // ==========================================================
        // GET: Employee/Edit/5
        // ==========================================================
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

          
            var employee = _employeeService.GetById(id.Value);

            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,   // ✅
                //Image = employee.Image,
                Image = employee.ImageName

            });
        }

        // ==========================================================
        // POST: Employee/Edit/5
        // ==========================================================
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeView)
        {
            string message = string.Empty;

            if (!ModelState.IsValid)
                return View(employeeView);

            try
            {
                var result = _employeeService.Update(new UpdateEmployeeDto()
                {
                    Id = id,
                    Name = employeeView.Name,
                    Age = employeeView.Age,
                    Address = employeeView.Address,
                    Email = employeeView.Email,
                    PhoneNumber = employeeView.PhoneNumber,
                    Salary = employeeView.Salary,
                    HiringDate = employeeView.HiringDate,
                    Gender = employeeView.Gender,
                    EmployeeType = employeeView.EmployeeType,
                    IsActive = employeeView.IsActive,
                    LastModifiedBy = employeeView.LastModifiedBy ?? 0,
                    DepartmentId = employeeView.DepartmentId,
                   Image = employeeView.Image
                });

                if (result > 0)
                {
            
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Error is not found";
                    ModelState.AddModelError(string.Empty, message);
                   
                    return View(employeeView);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(employeeView);
                }
                else
                {
                    message = "Employee not is error";
                    return View("Error", message);
                }
            }
        }

        // ==========================================================
        // GET: Employee/Delete/5  (تأكيد الحذف)
        // ==========================================================
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _employeeService.GetById(id.Value);

            if (employee is null)
                return NotFound();

            return View(employee);
        }

        // ==========================================================
        // POST: Employee/Delete/5  (تنفيذ الحذف)
        // ==========================================================
        // ==========================================================
        // POST: Employee/Delete/5  (تنفيذ الحذف)
        // ==========================================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var result = _employeeService.Delete(id);

                if (result > 0)
                {
                    TempData["Message"] = "Employee deleted successfully";
                    return RedirectToAction(nameof(Index));
                }

                TempData["Error"] = "Error: employee not found";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    TempData["Error"] = ex.Message;
                }
                else
                {
                    TempData["Error"] = "An error occurred while deleting the employee";
                }

                return RedirectToAction(nameof(Index));
            }
        }

    }
}
