using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MenegmentSystemEmploye.Program;

namespace MenegmentSystemEmploye
{
    abstract class Employee:IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public event PromotionEventHandle PromotionEvent;

        public abstract string GetEmployeeDetails();

        public abstract string PerformDuties();

        public void Promote(string newRole)
        { 
        Role=newRole;
            OnPromotion();

        }
        public virtual void OnPromotion()
        {
            PromotionEvent?.Invoke(this, new EventArgs());
        }
    }
}
