using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegmentSystemEmploye
{
    internal class Manager : Employee
    {
        public override string GetEmployeeDetails()
        {
            return $"ID: {Id}, Name: {Name}, Role: {Role}";
        }

        public override string PerformDuties()
        {
            return $"{Name} is Managing the team.";
        }
    }
}
