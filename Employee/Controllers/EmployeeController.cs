using Employee.Domain.Models;
using Employee.Infrastructure.Comman;
using Empolyee.Application.ApplicationConstant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public EmployeeController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var employee = await dbcontext.Employee.ToListAsync();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeModel emp)
        {
            var employee = new EmployeeModel
            {
                EmployeeName = emp.EmployeeName,
                EmployeeEmail = emp.EmployeeEmail,
                EmployeePhone = emp.EmployeePhone,
                EmployeePosition = emp.EmployeePosition
            };

            await dbcontext.Employee.AddAsync(employee);
            await dbcontext.SaveChangesAsync();

            TempData["Created"] = CommonMessages.Create;

            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbcontext.Employee.FindAsync(id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel viewmodel)
        {
            var employee = await dbcontext.Employee.FindAsync(viewmodel.EmployeeId);

            if (employee is not null)
            {
                employee.EmployeeName = viewmodel.EmployeeName;
                employee.EmployeeEmail = viewmodel.EmployeeEmail;
                employee.EmployeePhone = viewmodel.EmployeePhone;
                employee.EmployeePosition = viewmodel.EmployeePosition;

                await dbcontext.SaveChangesAsync();

                TempData["Edited"] = CommonMessages.update;

            }
            return RedirectToAction("List", "Employee"); //(action,controller)
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await dbcontext.Employee.FindAsync(id);

            if (employee is not null)
            {
                dbcontext.Employee.Remove(employee);
                await dbcontext.SaveChangesAsync();

                TempData["Deleted"] = CommonMessages.delete;
            }

            return RedirectToAction("List", "Employee");
        }
    }
}
