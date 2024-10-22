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

            System.IO.File.WriteAllText(@"guaranteeData3.json", jsonData);
            Console.WriteLine("JSON data has been saved to guaranteeData.json");

            Console.ReadLine();

            //獲取目前專案檔案執行的路徑
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //定義完整檔案路徑，Path.Combine是C#裡合併路徑的靜態方法，作用是將多個字串組合成一個合法的檔案或資料夾路徑，並且會自動處理路徑之間的分隔符號
            //例如，當你手動拼接路徑時，如果不小心忘記加上分隔符號或重複加上，就可能產生不正確的路徑。而 Path.Combine 則會自動處理這些情況，確保結果是正確的
            string filePath = Path.Combine(baseDirectory,@"guaranteeData2.json");


            if (File.Exists(filePath))
            {
                string jsonData1 = File.ReadAllText(filePath);


                GuaranteeData guaranteeData1 = JsonConvert.DeserializeObject<GuaranteeData>(jsonData1);

                Console.WriteLine("InvestorAccount :" + guaranteeData1.InvestorAccount);
                Console.WriteLine("GuaranteeDate :" + guaranteeData1.GuaranteeDate);
                Console.WriteLine("GuaranteeSerialNumber :" + guaranteeData1.GuaranteeSerialNumber);
                Console.WriteLine("CommissionDate :" + guaranteeData1.CommissionDate);
                Console.WriteLine("CommissionSerialNumber :" + guaranteeData1.CommissionSerialNumber);
                Console.WriteLine("ReportedGuaranteeAmount :" + guaranteeData1.ReportedGuaranteeAmount);
                Console.WriteLine("GuaranteeMaintainRate :" + guaranteeData1.GuaranteeMaintainRate);
                Console.WriteLine("ExceededGuaranteeRate :" + guaranteeData1.ExceededGuaranteeRate);
                Console.WriteLine("FunctionalCode :" + guaranteeData1.FunctionalCode);
                Console.WriteLine("TransactionStatus :" + guaranteeData1.TransactionStatus);
                Console.WriteLine("RepaymentStatus :" + guaranteeData1.RepaymentStatus);
            }
            else 
            {
                Console.WriteLine("找不到檔案");
            }
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
