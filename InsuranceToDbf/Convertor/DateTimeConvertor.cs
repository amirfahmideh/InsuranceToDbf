using System.Globalization;
namespace InsuranceToDbf.Convertor;
internal static class DateTimeConvertor
{
    public static string ToStringPersian(this DateTime thisDate)
    {
        PersianCalendar pc = new PersianCalendar();
        int year = pc.GetYear(thisDate);
        int month = pc.GetMonth(thisDate);
        string monthStr = month <= 9 ? $"0{month}" : month.ToString();

        int monthDay = pc.GetDayOfMonth(thisDate);
        string monthDayStr = monthDay <= 9 ? $"0{monthDay}" : monthDay.ToString();
        return $"{year}/{monthStr}/{monthDayStr}";
    }
}