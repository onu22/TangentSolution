using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tangent.Core.Domain.Employees;

namespace TangentSolution.Models.DashBoard
{
    public class DashBoardModel
    {
        public DashBoardModel()
        {
            this.AvailableRace= new List<SelectListItem>();
            this.AvailableGenders= new List<SelectListItem>();
            this.Employees = new List<Employee>();
            this.Statistics = new StatisticsModel();
        }

        public IList<Employee> Employees { get; set; }
        public string RaceValue { get; set; }
        public IList<SelectListItem> AvailableRace { get; set; }
        public string GenderValue { get; set; }
        public IList<SelectListItem> AvailableGenders { get; set; }
        public StatisticsModel Statistics { get; set; }

    }

    public class StatisticsModel
    {
        public int NumberOfEmployees { get; set; }
        public int BirthDays { get; set; }
        public int Positions { get; set; }
        public int Reviews { get; set; }

    }

}
