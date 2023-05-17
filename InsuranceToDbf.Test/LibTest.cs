using InsuranceToDbf.Convertor;
using InsuranceToDbf.Lib;
namespace InsuranceToDbf.Test;
public class LibTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DateTimeTest()
    {
        SalaryInsuranceWorkOffice wo = new SalaryInsuranceWorkOffice
        {
            ContractNumber = "1",
            ContributionInsuranceRate = 2,
            DailyWagePrice = 100,
            DaysOperationCount = 30,
            EmployeeContributionInsurance = 70,
            EmployerContributionInsurance = (decimal)30,
            HardOccupationRate = 0,
            ListDescription = "شرح دیسکت",
            ListNo = "01",
            ListType = 1,
            Month = 1,
            MonthlyReward = 10,
            MonthlyWageAndReward = 20,
            MonthlyWageAndRewardTotal = 30,
            MonthlyWagePrice = 40,
            PercentageRate = 0,
            PersonnelCount = 1,
            UnemploymentInsurancePortion = 5,
            WorkOfficeAddress = "آدرس شماره یک",
            WorkOfficeInsuranceCode = "5",
            WorkOfficeInsuranceName = "عنوان آزمایشی",
            WorkOfficeMasterName = "عنوان",
            Year = 1402
        };

        List<SalaryInsuranceItem> items = new List<SalaryInsuranceItem>() {
            new SalaryInsuranceItem() {
                BirthCertificateAreaName = "تهران",
                BirthCertificateDate = DateTime.Now,
                BirthCertificateNo = "1205",
                BirthDate = DateTime.Now,
                CitizenshipStatus = CitizenshipStatusEnum.Iranian,
                DailyWagePrice = 100,
                DaysOperationCount = 31,
                EmployerContributionInsurance = 42,
                FatherName = "پدر",
                FirstName = "نام",
                LastName = "نام خانوادگی",
                ListNo = "01",
                Month = 1,
                MonthlyReward = 100,
                MonthlyWageAndReward = 101,
                MonthlyWageAndRewardTotal = 201,
                NationalNo = "0217640125",
                InsuredContributionInsurance = 10,
                MonthlyWagePrice = 22,
                OccupationCode = "100",
                OccupationDescription = "شرح شغل",
                PersonnelId = 100,
                PercentageRate = 50,
                PersonnelInsuranceNo = "554656",
                Sex = SexEnum.Man,
                StartWorkDate = DateTime.Now.AddYears(-1),
                UnemploymentInsurancePortion = 10,
                WorkOfficeId = 2,
                WorkOfficeName = "محل خدمت",
                WorkOfficeInsuranceCode = "10",
                Year = 1402
    }
        };

        InsuranceToDbf.Export.ExportToDbf.Export(wo, items, out MemoryStream ms, out MemoryStream msItems);
        Console.WriteLine("MS Length");
        Console.WriteLine(ms.Length);
        string path = @"D:\header.dbf";
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        ms.WriteTo(fs);
        Assert.Pass();
    }
}