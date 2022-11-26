using EmployeeDatabase.Data;
using EmployeeDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDatabaseDbContext dbContext; //this dbContext is used to talk to inmemory databse
        //creating constructor to inject DbContext
        public EmployeeController(EmployeeDatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //creating methods to see all employees
        [HttpGet]
        public async Task<IActionResult> GetEmplyees()
        {
            return Ok(await dbContext.Employees.ToListAsync());
        }

        //adding a method to get a single employee based on ID
        [HttpGet]
        [Route("{EMPID:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid EMPID)
        {
            var employee = await dbContext.Employees.FindAsync(EMPID);

            if(employee==null)
            {
                return NotFound();
            }return Ok(employee);
        }

        //adding a method to add employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee()
            {
                EMPID = Guid.NewGuid(),
                FIRSTNAME = addEmployeeRequest.FIRSTNAME,
                MIDDLENAME = addEmployeeRequest.MIDDLENAME,
                LASTNAME = addEmployeeRequest.LASTNAME,
                DEPT = addEmployeeRequest.DEPT,
                CONTACT = addEmployeeRequest.CONTACT,
                DEGREE = addEmployeeRequest.DEGREE,
                GENDER = addEmployeeRequest.GENDER,
                SALARY = addEmployeeRequest.SALARY
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync(); //made changes and added resourse to the database

            return Ok(employee);

        }


        //upadating
        [HttpPut]
        [Route("{EMPID:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid EMPID, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await dbContext.Employees.FindAsync(EMPID);
            if (employee != null)
            {
                employee.FIRSTNAME= updateEmployeeRequest.FIRSTNAME;
                employee.MIDDLENAME = updateEmployeeRequest.MIDDLENAME;
                employee.LASTNAME= updateEmployeeRequest.LASTNAME;
                employee.DEPT= updateEmployeeRequest.DEPT;
                employee.CONTACT= updateEmployeeRequest.CONTACT;
                employee.DEGREE=updateEmployeeRequest.DEGREE;
                employee.GENDER= updateEmployeeRequest.GENDER;
                employee.SALARY= updateEmployeeRequest.SALARY;

                await dbContext.SaveChangesAsync();

                return Ok(employee);
            }
            return NotFound();
        }
        
        //deleting
        [HttpDelete]
        [Route("{EMPID:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid EMPID)
        {
            var employee = await dbContext.Employees.FindAsync(EMPID);
            if (employee != null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(employee);

            }
            return NotFound();
        }
    }
}
