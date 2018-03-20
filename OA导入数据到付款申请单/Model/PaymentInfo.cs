using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputData.Model
{
    public class PaymentInfo
    {
        public long ID { get; set; }
        public string EmployeeID { get; set; }
        public string ReceivingUnit { get; set; }
        public string Tax { get; set; }
        public string AmountMoney { get; set; }
        public string Subject { get; set; }
        public string State { get; set; }
    }
}
