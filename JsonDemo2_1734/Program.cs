using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace JsonDemo2_1734
{
    public class Program
    {
        static void Main(string[] args)
        {
            var guaranteeData = new GuaranteeData 
            {
                InvestorAccount = "DavidWang1204",
                GuaranteeDate = DateTime.Now,
                GuaranteeSerialNumber = "G12345",
                CommissionDate = DateTime.Now,
                CommissionSerialNumber = "Y12345",
                ReportedGuaranteeAmount = 9000,
                GuaranteeMaintainRate = 80,
                ExceededGuaranteeRate = 90,
                FunctionalCode = "Hello",
                TransactionStatus = "Success",
                RepaymentStatus = "Success"
            };
            string jsonData = JsonConvert.SerializeObject(guaranteeData, Formatting.Indented);
            Console.WriteLine(jsonData);
        }
    }
    public class GuaranteeData
    {
        public string InvestorAccount { get; set; }
        public DateTime GuaranteeDate { get; set; }
        public string GuaranteeSerialNumber { get; set; }
        public DateTime CommissionDate { get; set; }
        public string CommissionSerialNumber { get; set; }  
        public string TransactionStatus { get; set; }
        public string RepaymentStatus { get; set; }
        public decimal ReportedGuaranteeAmount { get; set; }
        public decimal GuaranteeMaintainRate { get; set; }
        public decimal ExceededGuaranteeRate { get; set; }
        public string FunctionalCode { get; set; }
       
    }
}
