using LiquidExample.Models;
using LiquidExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LiquidExample.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeRepository repository;

        public EmployeeController() => repository = new EmployeeRepository();

        public IActionResult Index()
        {
            var employees = repository.GetAll();

            return View(employees);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create([FromForm] Employee employee)
        {
            repository.Add(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}