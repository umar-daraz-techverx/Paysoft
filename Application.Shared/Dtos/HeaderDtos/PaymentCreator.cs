using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.Enums;

namespace Techverx.Paysoft.Dtos.HeaderDtos
{
    public class PaymentCreator
    {
        public int EmployeeId{ get; set; }
        public ServiceBatchType Service { get; set; }
        public EmployeeType ServiceType { get; set; }
        public string Key { get; set; }
    }
}
