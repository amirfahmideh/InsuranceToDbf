using System;
using System.Text;
using InsuranceToDbf.Convertor;

namespace InsuranceToDbf.Lib
{
    /// <summary>
    /// اطلاعات مربوط به حقوق پرسنل
    /// </summary>
    public class SalaryInsuranceItem
    {
        /// <summary>
        /// DSW_ID:‌کد کارگاه
        /// </summary>
        public string WorkOfficeInsuranceCode { get; set; } = "";
        /// <summary>
        /// DSW_YY: سال عملکرد : 1405
        /// </summary>
        public int Year { get; set; }
        public int YearTwo => Year % 100;
        /// <summary>
        /// DSW_MM: ماه عملکرد
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// DSW_LISTNO: شماره لیست
        /// </summary>
        public string ListNo { get; set; } = "01";
        /// <summary>
        /// DSW_ID1: شماره بیمه
        /// </summary>
        public string PersonnelInsuranceNo { get; set; } = "";
        /// <summary>
        /// DSW_FName: نام
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// DSW_LName : نام خانوادگی
        /// </summary>
        public string LastName { get; set; } = "";
        /// <summary>
        /// DSW_DName: نام پدر
        /// </summary>
        public string FatherName { get; set; } = "";
        /// <summary>
        /// DSW_IDNO: شماره شناسنامه
        /// </summary>
        public string BirthCertificateNo { get; set; } = "";
        /// <summary>
        /// DSW_IDPLC: محل صدور
        /// </summary>
        public string BirthCertificateAreaName { get; set; } = "";
        /// <summary>
        /// DSW_IDATE: تاریخ صدور شناسنامه
        /// </summary>
        public DateTime? BirthCertificateDate { get; set; }
        /// <summary>
        /// تاریخ صدور به فرمت شمسی
        /// </summary>
        public string BirthCertificateDateFa => BirthCertificateDate.HasValue ? BirthCertificateDate.Value.ToStringPersian() : "";
        /// <summary>
        /// DSW_BDATE: تاریخ تولد
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// تاریخ تولد شمسی
        /// </summary>
        public string BirthDateFa => BirthDate.HasValue ? BirthDate.Value.ToStringPersian() : string.Empty;
        /// <summary>
        /// DSW_SEX: جنسیت
        /// </summary>
        public SexEnum Sex { get; set; } = SexEnum.Man;
        /// <summary>
        /// مقدار فارسی برای جنسیت
        /// </summary>
        public string SexTitle => Sex.GetDisplayName() ?? "";
        /// <summary>
        /// DSW_NAT: ملیت
        /// </summary>
        public CitizenshipStatusEnum CitizenshipStatus { get; set; }
        /// <summary>
        /// مقدار فارسی ملیت
        /// </summary>
        public string CitizenshipStatusTitle => CitizenshipStatus.GetDisplayName() ?? "";
        /// <summary>
        /// DSW_OCP: شرح شغل
        /// </summary>
        public string OccupationDescription { get; set; } = "";
        /// <summary>
        /// DSW_SDate : تاریخ شروع کار
        /// </summary>
        public DateTime? StartWorkDate { get; set; }
        /// <summary>
        /// تاریخ شروع به کار شمسی
        /// </summary>
        public string StartWorkDateFa => StartWorkDate.HasValue ? StartWorkDate.Value.ToStringPersian() : "";
        /// <summary>
        /// DSW_EDate: تاریخ ترک کار
        /// </summary>
        public DateTime? EndWorkDate { get; set; }
        /// <summary>
        /// تاریخ ترک کار شمسی
        /// </summary>
        public string EndWorkDateFa => EndWorkDate.HasValue ? EndWorkDate.Value.ToStringPersian() : "";
        /// <summary>
        /// DSW_DD : تعداد روزهای کارکرد
        /// </summary>
        public decimal DaysOperationCount { get; set; }
        /// <summary>
        /// DSW_ROOZ : دستمزد روزانه
        /// </summary>
        public decimal? DailyWagePrice { get; set; }
        /// <summary>
        /// DSW_MAH : دستمزد ماهانه
        /// </summary>
        public decimal? MonthlyWagePrice { get; set; }
        /// <summary>
        /// DSW_MAZ: مزایای ماهانه
        /// </summary>
        public decimal? MonthlyReward { get; set; }
        /// <summary>
        /// DSW_MASH: جمع دستمزد و مزایای ماهیانه
        /// </summary>
        public decimal? MonthlyWageAndReward { get; set; }
        /// <summary>
        /// DSW_TOTL: جمک کل دستمزد و مزایای ماهیانه
        /// </summary>
        public decimal? MonthlyWageAndRewardTotal { get; set; }
        /// <summary>
        /// DSW_BIME: حق بیمه سهم بیمه شده
        /// </summary>
        public decimal? InsuredContributionInsurance { get; set; }
        /// <summary>
        /// DSW_PRATE: نرخ پورسانتاژ
        /// </summary>
        public decimal? PercentageRate { get; set; } = 0;
        /// <summary>
        /// DSW_JOB: کد شغل
        /// </summary>
        public string OccupationCode { get; set; } = "";
        /// <summary>
        /// PER_NATCOD : کد ملی
        /// </summary>
        public string NationalNo { get; set; } = "";

        /// <summary>
        /// DSW_INC: پایه سنواتی
        /// </summary>
        public decimal? RightYearsPrice { get; set; }

        // <summary>
        /// DSW_SPOUSE: حق تاهل
        /// </summary>
        public decimal? SpouseRightPrice { get; set; }

        public object[] ToDbfFormat()
        {
            var convert = new ConvertWindowsPersianToDos();
            return new object[] {
                this.WorkOfficeInsuranceCode,
                YearTwo,
                Month,
            this.ListNo,
            this.PersonnelInsuranceNo,
            convert.get_Unicode_To_IranSystem(this.FirstName),
            convert.get_Unicode_To_IranSystem(this.LastName),
            convert.get_Unicode_To_IranSystem(this.FatherName),
            convert.get_Unicode_To_IranSystem(this.BirthCertificateNo),
            convert.get_Unicode_To_IranSystem(this.BirthCertificateAreaName),
            !String.IsNullOrEmpty(this.BirthCertificateDateFa) ? this.BirthCertificateDateFa.Replace("/", ""): this.BirthCertificateDateFa,
            this.BirthDateFa.Replace("/",""),
            convert.get_Unicode_To_IranSystem(this.SexTitle),
            convert.get_Unicode_To_IranSystem(this.CitizenshipStatusTitle),
            convert.get_Unicode_To_IranSystem(this.OccupationDescription),
            !String.IsNullOrEmpty(this.StartWorkDateFa) ? this.StartWorkDateFa.Replace("/", "") : this.StartWorkDateFa,
            !String.IsNullOrEmpty(this.EndWorkDateFa) ? this.EndWorkDateFa.Replace("/", "") : this.EndWorkDateFa,
            this.DaysOperationCount,
            this.DailyWagePrice ?? 0,
            this.MonthlyWagePrice ?? 0,
            this.MonthlyReward ?? 0,
            this.MonthlyWageAndReward ?? 0,
            this.MonthlyWageAndRewardTotal ?? 0,
            this.InsuredContributionInsurance ?? 0,
            this.PercentageRate ?? 0,
            this.OccupationCode,
            convert.get_Unicode_To_IranSystem(this.NationalNo),
            this.RightYearsPrice ?? 0,
            this.SpouseRightPrice ?? 0,

        };
        }
    }
}
