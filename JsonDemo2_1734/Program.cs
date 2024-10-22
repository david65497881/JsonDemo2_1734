using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace JsonDemo2_1734
{
    public class Program
    {
        static void Main(string[] args)
        {
            //宣告gunarnteeData裡的資料
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

            //.SerializeObject用於將guaranteeData的資料轉換成JSON字串
            //Formatting.Indented用於美化排版,默認情況下是沒有縮排的   
            string jsonData = JsonConvert.SerializeObject(guaranteeData, Formatting.Indented);
            Console.WriteLine(jsonData);

            //第一段@"guaranteeData3.json"為檔案存入的路徑，檔案會被存入當專案執行的跟目錄下，也可以指定路徑寫成@"C:\data\guaranteeData3.json"
            //第二段jsonData為要存入的資料
            //@ 符號表示這是一個逐字字串，可以直接使用反斜線而不用加上跳脫字符
            //System.IO.File.WriteAllText用來將字串內容寫入檔案的靜態方法，如果檔案已存在，會直接覆蓋，如果檔案不存在，會自動創建
            System.IO.File.WriteAllText(@"guaranteeData3.json", jsonData);

            Console.WriteLine("JSON data has been saved to guaranteeData3.json");

            Console.ReadLine();

            //獲取目前專案檔案執行的路徑，AppDomain.CurrentDomain.BaseDirectory用於動態獲得當前專案目錄，不用寫死
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //定義完整檔案路徑，Path.Combine是C#裡合併路徑的靜態方法，作用是將多個字串組合成一個合法的檔案或資料夾路徑，並且會自動處理路徑之間的分隔符號
            //例如，當你手動拼接路徑時，如果不小心忘記加上分隔符號或重複加上，就可能產生不正確的路徑。而 Path.Combine 則會自動處理這些情況，確保結果是正確的
            string filePath = Path.Combine(baseDirectory,@"guaranteeData2.json");

            //如果檔案存在，反序列化並輸出，如果不存在，顯示檔案不存在
            if (File.Exists(filePath))
            {
                //ReadAllText為從指定的檔案一次性閱讀所有的文字
                string jsonData1 = File.ReadAllText(filePath);

                //DeserializeObject<GuaranteeData>(jsonData1)將 JSON 字串轉換為 C# 中的物件
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
