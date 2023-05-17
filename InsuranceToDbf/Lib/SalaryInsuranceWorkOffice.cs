using System;
using System.Text;
using InsuranceToDbf.Convertor;
namespace InsuranceToDbf.Lib
{
    public class SalaryInsuranceWorkOffice
    {
        /// <summary>
        /// DSK_ID: کد کارگاه
        /// </summary>
        public string WorkOfficeInsuranceCode { get; set; }
        /// <summary>
        /// DSK_Name: نام کارگاه
        /// </summary>
        public string WorkOfficeInsuranceName { get; set; }
        /// <summary>
        /// DSK_FARM: نام کارفرما
        /// </summary>
        public string WorkOfficeMasterName { get; set; }
        /// <summary>
        /// DSK_ADRS: آدرس کارگاه
        /// </summary>
        public string WorkOfficeAddress { get; set; }
        /// <summary>
        /// DSK_YY: سال عملکرد
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// ۲ عدد آخر سال عمل کرد
        /// </summary>
        public int YearTwo => Year % 100;
        /// <summary>
        /// DSK_MM: ماه عملکرد
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// DSK_Kind: نوع لیست
        /// </summary>
        public int ListType { get; set; } = 0;
        /// <summary>
        /// DSK_LISTNO:‌شماره لیست
        /// </summary>
        public string ListNo { get; set; } = "01";
        /// <summary>
        /// DSK_DISK: شرح لیست
        /// </summary>
        public string ListDescription { get; set; } = "";
        /// <summary>
        /// DSK_NUM: تعداد کارکنان
        /// </summary>
        public int PersonnelCount { get; set; }
        /// <summary>
        /// DSK_TDD: مجموع روزهای کارکرد
        /// </summary>
        public decimal DaysOperationCount { get; set; }
        /// <summary>
        /// DSK_TROOZ: مجموع دستمزد روزانه
        /// </summary>
        public decimal? DailyWagePrice { get; set; }
        /// <summary>
        /// DSK_TMAH: مجموع دستمزد ماهانه
        /// </summary>
        public decimal? MonthlyWagePrice { get; set; }
        /// <summary>
        /// DSK_TMAZ: مجموع مزایای ماهانه مشمول
        /// </summary>
        public decimal? MonthlyReward { get; set; }
        /// <summary>
        /// DSK_TMASH: مجموع دستمزد و مزایای ماهانه مشمول 
        /// </summary>
        public decimal? MonthlyWageAndReward { get; set; }
        /// <summary>
        /// DSK_TTOTL: مجموع کل دستمزد و مزایای ماهانه (مشمول و غیر مشمول)
        /// </summary>
        public decimal? MonthlyWageAndRewardTotal { get; set; }
        /// <summary>
        /// DSK_TBIMEH: مجموع حق بیمه سهم بیمه شده
        /// </summary>
        public decimal? EmployeeContributionInsurance { get; set; }
        /// <summary>
        /// DSK_TKOSO: مجموع حق بیمه شده سهم کارفرما
        /// </summary>
        public decimal? EmployerContributionInsurance { get; set; }
        /// <summary>
        /// DSK_BIC: مجموع حق بیمه بیکاری
        /// </summary>
        public decimal? UnemploymentInsurancePortion { get; set; }
        /// <summary>
        /// DSK_RATE: نرخ حق بیمه
        /// </summary>
        public decimal? ContributionInsuranceRate { get; set; } = 27;
        /// <summary>
        /// DSK_PRATE: نرخ پورسانتاژ
        /// </summary>
        public decimal? PercentageRate { get; set; }
        /// <summary>
        /// DSK_BIMH: نرخ مشاغل سخت و زیان آور
        /// </summary>
        public decimal? HardOccupationRate { get; set; }
        /// <summary>
        /// MON_PYM:‌ردیف پیمان
        /// </summary>
        public string ContractNumber { get; set; } = "";

        public object[] ToDbfFormat()
        {
            var convert = new ConvertWindowsPersianToDos();
            return new object[] {
                this.WorkOfficeInsuranceCode,
                convert.Win2Dos(this.WorkOfficeInsuranceName),
                convert.Win2Dos(this.WorkOfficeMasterName),
                convert.Win2Dos(this.WorkOfficeAddress),
                ListType,
                YearTwo,
                Month,
                ListNo,
                convert.Win2Dos(this.ListDescription),
                PersonnelCount,
                DaysOperationCount,
                DailyWagePrice,
                MonthlyWagePrice,
                MonthlyReward,
                MonthlyWageAndReward,
                MonthlyWageAndRewardTotal,
                EmployeeContributionInsurance,
                EmployerContributionInsurance,
                UnemploymentInsurancePortion,
                ContributionInsuranceRate ?? null,
                0,
                0,
                convert.Win2Dos(this.ContractNumber?.ToString())
            };
        }
    }
}
