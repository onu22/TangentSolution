using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Tangent.Core;
using Tangent.Core.Domain.Employees;
using Tangent.Services.Employees;
using TangentSolution.Models.DashBoard;

namespace TangentSolution.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class DashBoardController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHelper _webHelper;

        public DashBoardController(IEmployeeService employeeService, IWebHelper webHelper)
        {
            _employeeService = employeeService;
            _webHelper = webHelper;
        }
        public IActionResult Index()
        {

            List<Employee> employees = _employeeService.SearchEmployees();

            DashBoardModel model = new DashBoardModel();
            PrepareDashBoardModel(model, employees);
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(DashBoardModel model)
        {
            string apiUri = "/api/employee/";
            if (!string.IsNullOrEmpty(model.GenderValue))
            {
                apiUri = _webHelper.ModifyUrl(apiUri, "gender=" + model.GenderValue);
            }
            if (!string.IsNullOrEmpty(model.RaceValue))
            {
                apiUri = _webHelper.ModifyUrl(apiUri, "race=" + model.RaceValue);
            }

            List<Employee> employees = _employeeService.SearchEmployees(apiUri);
            PrepareDashBoardModel(model, employees);
            return View(model);
        }

        private void PrepareDashBoardModel(DashBoardModel model, List<Employee> employees)
        {

            model.AvailableGenders.Add(new SelectListItem() { Value = "", Text = "All" });
            model.AvailableGenders.Add(new SelectListItem(){ Value = "M", Text = "Male" });
            model.AvailableGenders.Add(new SelectListItem() { Value = "F" , Text = "Female" });

            model.AvailableRace.Add(new SelectListItem() { Value = "", Text = "All" });
            model.AvailableRace.Add(new SelectListItem() { Value = "B", Text = "Black African" });
            model.AvailableRace.Add(new SelectListItem() { Value = "C", Text = "Coloured" });
            model.AvailableRace.Add(new SelectListItem() { Value = "I", Text = "Indian or Asian" });
            model.AvailableRace.Add(new SelectListItem() { Value = "W", Text = "White" });
            model.AvailableRace.Add(new SelectListItem() { Value = "N", Text = "Non Dominant" });

            model.Employees = employees;

        }


    }
}