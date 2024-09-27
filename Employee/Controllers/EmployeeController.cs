using Employee.Domain.Models;
using Employee.Infrastructure.Comman;
using Empolyee.Application.ApplicationConstant;
using Empolyee.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
   
namespace Employee.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitofwork;

        public EmployeeController(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork; 
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var employee = await unitofwork.EmployeeRepository.Get();

            return View(employee);
        }
        [Authorize(Roles = Roles.admin)]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = Roles.admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                await unitofwork.EmployeeRepository.Add(emp);
                await unitofwork.SaveAsync(); 
            }

            TempData["Created"] = CommonMessages.Create;

            return RedirectToAction("List", "Employee");
        }
        [Authorize(Roles = Roles.admin)]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await unitofwork.EmployeeRepository.GetByid(id);

            return View(employee);
        }

        [Authorize(Roles = Roles.admin)]
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel viewmodel)
        {
            //var employee = await unitofwork.EmployeeRepository.GetByid(viewmodel.EmployeeId);

            if (viewmodel is not null)
            {
                await unitofwork.EmployeeRepository.Update(viewmodel); 
                await unitofwork.SaveAsync();  
            }
            TempData["Edited"] = CommonMessages.update;
            return RedirectToAction("List", "Employee"); //(action,controller)
        }

        [Authorize(Roles = Roles.admin)]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await unitofwork.EmployeeRepository.GetByid(id);

            if (employee is not null)
            {
                await unitofwork.EmployeeRepository.Delete(id);
                await unitofwork.SaveAsync();

                TempData["Deleted"] = CommonMessages.delete;
            }

            return RedirectToAction("List", "Employee");
        }
    }
}
