using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.Models.BankAccount;
using Techverx.Paysoft.Enums;

namespace Techverx.Paysoft.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
		public string Email { get; set; }
		public string Surname { get; set; }
		public string ClientCode{ get; set; }
		public string CustomerCode { get; set; }
		public virtual Account Account { get; set; }
       
    }
}
