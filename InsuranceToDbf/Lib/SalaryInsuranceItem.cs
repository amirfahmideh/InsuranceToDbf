
using System;
using System.Text;
using InsuranceToDbf.Convertor;

namespace InsuranceToDbf.Lib
{
    public class SalaryInsuranceItem
    {
        public string WorkOfficeInsuranceCode { get; set; }
        public long PersonnelId { get; set; }
        public long WorkOfficeId { get; set; }
        public int Year { get; set; }
        public int YearTwo => Year % 100;

        public int Month { get; set; }
        public string ListNo { get; set; } = "01";
        public string PersonnelInsuranceNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string BirthCertificateNo { get; set; }
        public string BirthCertificateAreaName { get; set; }
        public DateTime? BirthCertificateDate { get; set; }
        public string BirthCertificateDateFa => BirthCertificateDate?.ToStringPersian();
        public DateTime? BirthDate { get; set; }
        public string BirthDateFa => BirthDate?.ToStringPersian() ?? string.Empty;
        public SexEnum? Sex { get; set; }
        public string SexTitle => Sex?.GetDisplayName();
        public CitizenshipStatusEnum? CitizenshipStatus { get; set; }
        public string CitizenshipStatusTitle => CitizenshipStatus?.GetDisplayName();
        public string WorkOfficeName { get; set; }
        public string OccupationDescription { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public string StartWorkDateFa => StartWorkDate?.ToStringPersian();
        public DateTime? EndWorkDate { get; set; }
        public string EndWorkDateFa => EndWorkDate?.ToStringPersian();
        public decimal DaysOperationCount { get; set; }
        public decimal? DailyWagePrice { get; set; }
        public decimal? MonthlyWagePrice { get; set; }
        public decimal? MonthlyReward { get; set; }
        public decimal? MonthlyWageAndReward { get; set; }
        public decimal? MonthlyWageAndRewardTotal { get; set; }
        public decimal? InsuredContributionInsurance { get; set; }
        public decimal? PercentageRate { get; set; } = 0;
        public string OccupationCode { get; set; }
        public string NationalNo { get; set; }

        public decimal? EmployerContributionInsurance { get; set; }
        public decimal? UnemploymentInsurancePortion { get; set; }

        public object[] ToDbfFormat()
        {
            var convert = new ConvertWindowsPersianToDos();
            return new object[] {
                this.WorkOfficeInsuranceCode,
                YearTwo,
                Month,
            this.ListNo,
            this.PersonnelInsuranceNo,
            convert.Win2Dos(this.FirstName),
            convert.Win2Dos(this.LastName),
            convert.Win2Dos(this.FatherName),
            convert.Win2Dos(this.BirthCertificateNo),
            convert.Win2Dos(this.BirthCertificateAreaName),
            !String.IsNullOrEmpty(this.BirthCertificateDateFa) ? this.BirthCertificateDateFa.Replace("/", ""): this.BirthCertificateDateFa,
            this.BirthDateFa.Replace("/",""),
            convert.Win2Dos(this.SexTitle),
            convert.Win2Dos(this.CitizenshipStatusTitle),
            convert.Win2Dos(this.OccupationDescription),
            !String.IsNullOrEmpty(this.StartWorkDateFa) ? this.StartWorkDateFa.Replace("/", "") : this.StartWorkDateFa,
            !String.IsNullOrEmpty(this.EndWorkDateFa) ? this.EndWorkDateFa.Replace("/", "") : this.EndWorkDateFa,
            this.DaysOperationCount,
            this.DailyWagePrice,
            this.MonthlyWagePrice,
            this.MonthlyReward,
            this.MonthlyWageAndReward,
            this.MonthlyWageAndRewardTotal,
            this.InsuredContributionInsurance,
            this.PercentageRate,
            this.OccupationCode,
            convert.Win2Dos(this.NationalNo)
        };
        }
    }
}
