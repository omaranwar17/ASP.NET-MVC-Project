using APP_BUS_L_10.DTO;
using APP_BUS_L_10.DTO.Depatments;
using APP_BUS_L_10.Services.Departments;
using App_User_10.ViewModels.Depatments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace App_User_10.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _idepartmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentServices idepartmentServices ,
            ILogger<DepartmentController> logger , IWebHostEnvironment environment)
        {
            _idepartmentServices = idepartmentServices;
            this._logger = logger;
            this._environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var department = _idepartmentServices.GetDepartments();

            return View(department);
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddDepartmentDbo dbo)
        {
            if (!ModelState.IsValid)
                return View(dbo);

            try
            {
                var result = _idepartmentServices.addDepart(dbo);

                if (result > 0)
                {
                    TempData["Success"] = "تم إضافة القسم بنجاح ✅";   // ← غيّرها
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "فشل إضافة القسم ❌";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData["Error"] = _environment.IsDevelopment()
                    ? ex.Message
                    : "حدث خطأ غير متوقع، حاول لاحقًا";

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [ActionName("Details")]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
              var departId =  _idepartmentServices.getDepatId(id.Value);
                if (departId != null)
                {
                    return View(departId);
                }
                else
                {
                 return NotFound();
                }
               
            }
            else
            {
                return BadRequest();
            }
          
           
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var dId = _idepartmentServices.getDepatId(id.Value);
                if (dId != null)
                {
                    return View(new AddDepartmentDbo()
                    {
                        //Id = id.Value,
                        Code = dId.Code,
                        Name = dId.Name,
                        Description = dId.Description,
                        DataOfCreation = dId.DataOfCreation,
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
         
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id , AddDepartmentDbo depatmentView)
        {
            string message = string.Empty;
            if (!ModelState.IsValid)
            {
                return View(depatmentView);
            }
         try
            {
            var result =  _idepartmentServices.updateDepart(new UpdateDepartment()
                {
                  Id = id,
                  Name = depatmentView.Name,
                  Code = depatmentView.Code,
                  DataOfCreation = depatmentView.DataOfCreation,
                  Description = depatmentView.Description,
                });
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Error is not found";
                    ModelState.AddModelError(string.Empty, message);
                    return View(depatmentView);
                }

            }
            catch (Exception ex)

            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(depatmentView);
                }
                else
                {
                    message = "Department not is error ";
                    return View("Error", message);
                }
            }
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {

                var deleteId = _idepartmentServices.getDepatId(id.Value);
                if (deleteId != null)
                {
                    return View(deleteId);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        public IActionResult Delete(int id)
        {
            string message = string.Empty;


            if (!ModelState.IsValid)
            {

                return View(id);
            }
            try
            {
                var result = _idepartmentServices.deleteDepart(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Error is not found";
                    ModelState.AddModelError(string.Empty, message);
                    return View(id);
                }
            }
            catch (Exception ex)

            {
                _logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(id);
                }
                else
                {
                    message = "Department not is error ";
                    return View("Error", message);
                }
            }

        }



    }
}
