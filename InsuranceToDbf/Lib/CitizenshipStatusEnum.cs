using System.ComponentModel.DataAnnotations;

namespace InsuranceToDbf.Lib
{
    public enum CitizenshipStatusEnum
    {
        [Display(Name = "ایرانی")]
        Iranian = 1,
        [Display(Name = "غیرایرانی")]
        Foreign = 2,
    }
}
