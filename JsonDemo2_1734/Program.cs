﻿using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Transactions;

namespace JsonDemo2_1734
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            GuaranteeWrapper guaranteeWrapper = new GuaranteeWrapper
            {
                SearchCriteria = new SearchCriteria
                {
                    CollateralDate = DateTime.Now,
                    InvestorAccount = "DavidWang1204",
                    TransactionStatus = "Success",
                    RepaymentStatus = "Success"
                },
                GuaranteeData = new GuaranteeData
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
                }
            };


            //.SerializeObject用於將guaranteeData的資料轉換成JSON字串
            //Formatting.Indented用於美化排版,默認情況下是沒有縮排的   
            string jsonData = JsonConvert.SerializeObject(guaranteeWrapper, Formatting.Indented);
            Console.WriteLine(jsonData);

            //第一段@"guaranteeWrapper.json"為檔案存入的路徑，檔案會被存入當專案執行的跟目錄下，也可以指定路徑寫成@"C:\data\guaranteeWrapper.json"
            //第二段jsonData為要存入的資料
            //@ 符號表示這是一個逐字字串，可以直接使用反斜線而不用加上跳脫字符
            //System.IO.File.WriteAllText用來將字串內容寫入檔案的靜態方法，如果檔案已存在，會直接覆蓋，如果檔案不存在，會自動創建
            System.IO.File.WriteAllText(@"guaranteeWrapper.json", jsonData);

            Console.WriteLine("JSON data has been saved to guaranteeWrapper.json");

            Console.ReadLine();

            //獲取目前專案檔案執行的路徑，AppDomain.CurrentDomain.BaseDirectory用於動態獲得當前專案目錄，不用寫死
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //定義完整檔案路徑，Path.Combine是C#裡合併路徑的靜態方法，作用是將多個字串組合成一個合法的檔案或資料夾路徑，並且會自動處理路徑之間的分隔符號
            //例如，當你手動拼接路徑時，如果不小心忘記加上分隔符號或重複加上，就可能產生不正確的路徑。而 Path.Combine 則會自動處理這些情況，確保結果是正確的
            string filePath = Path.Combine(baseDirectory, @"guaranteeWrapper.json");

            //如果檔案存在，反序列化並輸出，如果不存在，顯示檔案不存在
            if (File.Exists(filePath))
            {
                //ReadAllText為從指定的檔案一次性閱讀所有的文字
                string jsonData1 = File.ReadAllText(filePath);

                //DeserializeObject<GuaranteeData>(jsonData1)將 JSON 字串轉換為 C# 中的物件
                GuaranteeWrapper guaranteeWrapper1 = JsonConvert.DeserializeObject<GuaranteeWrapper>(jsonData1);

                Console.WriteLine("InvestorAccount :" + guaranteeWrapper1.GuaranteeData.InvestorAccount);
                Console.WriteLine("GuaranteeDate :" + guaranteeWrapper1.GuaranteeData.GuaranteeDate);
                Console.WriteLine("GuaranteeSerialNumber :" + guaranteeWrapper1.GuaranteeData.GuaranteeSerialNumber);
                Console.WriteLine("CommissionDate :" + guaranteeWrapper1.GuaranteeData.CommissionDate);
                Console.WriteLine("CommissionSerialNumber :" + guaranteeWrapper1.GuaranteeData.CommissionSerialNumber);
                Console.WriteLine("ReportedGuaranteeAmount :" + guaranteeWrapper1.GuaranteeData.ReportedGuaranteeAmount);
                Console.WriteLine("GuaranteeMaintainRate :" + guaranteeWrapper1.GuaranteeData.GuaranteeMaintainRate);
                Console.WriteLine("ExceededGuaranteeRate :" + guaranteeWrapper1.GuaranteeData.ExceededGuaranteeRate);
                Console.WriteLine("FunctionalCode :" + guaranteeWrapper1.GuaranteeData.FunctionalCode);
                Console.WriteLine("TransactionStatus :" + guaranteeWrapper1.GuaranteeData.TransactionStatus);
                Console.WriteLine("RepaymentStatus :" + guaranteeWrapper1.GuaranteeData.RepaymentStatus);
            }
            else 
            {
                Console.WriteLine("找不到檔案");
            }
        }


    }

    public class GuaranteeWrapper 
    {
        /// <summary>
        /// 擔保資料
        /// </summary>
        public GuaranteeData GuaranteeData { get; set; }
        /// <summary>
        /// 搜尋資料
        /// </summary>
        public SearchCriteria SearchCriteria { get; set; }
    }

    public class GuaranteeData
    {
        /// <summary>
        /// 投資人帳號
        /// </summary>
        public string InvestorAccount { get; set; }
        /// <summary>
        /// 擔保日期
        /// </summary>
        public DateTime GuaranteeDate { get; set; }
        /// <summary>
        /// 擔保序號
        /// </summary>
        public string GuaranteeSerialNumber { get; set; }
        /// <summary>
        /// 委託日期
        /// </summary>
        public DateTime CommissionDate { get; set; }
        /// <summary>
        /// 委託序號
        /// </summary>
        public string CommissionSerialNumber { get; set; }  
        
        /// <summary>
        /// 已申報擔保總經額
        /// </summary>
        public decimal ReportedGuaranteeAmount { get; set; }
        /// <summary>
        /// 擔保維持率
        /// </summary>
        public decimal GuaranteeMaintainRate { get; set; }
        /// <summary>
        /// 超過擔保規定比率總值
        /// </summary>
        public decimal ExceededGuaranteeRate { get; set; }
        /// <summary>
        /// 功能碼
        /// </summary>
        public string FunctionalCode { get; set; }
        /// <summary>
        /// 成交狀態
        /// </summary>
        public string TransactionStatus { get; set; }
        /// <summary>
        /// 還劵狀態
        /// </summary>
        public string RepaymentStatus { get; set; }


    }

    public class SearchCriteria 
    {
        /// <summary>
        /// 擔保品日期
        /// </summary>
        public DateTime CollateralDate { get; set; }
        /// <summary>
        /// 投資人帳號
        /// </summary>
        public string InvestorAccount {get; set; }
        /// <summary>
        /// 成交狀態
        /// </summary>
        public string TransactionStatus { get; set; }
        /// <summary>
        /// 還劵狀態
        /// </summary>
        public string RepaymentStatus { get; set; }

    }
}
