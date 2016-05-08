using MVC5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.ViewModels
{
    public class EditAccountViewModel
    {
        public EditAccountViewModel(User user)
        {
            UserName = user.UserName;
            CreditCard = user.CreditCard;
            PhoneNumber = user.PhoneNumber;
        }

        [Required]
        [Display(Name = "用户名")]
        [StringLength(20, ErrorMessage = "用户名不能超过20个字")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "联系方式")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "银行卡号")]
        public string CreditCard { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("NewPassword", ErrorMessage = "密码和确认密码不一致。")]
        public string ConfirmPassword { get; set; }
        public List<string> LicensePlate { get; set; }
    }

    public class AccountInformationViewModel
    {

        [Required]
        [Display(Name = "用户名")]
        [StringLength(20, ErrorMessage = "用户名不能超过20个字")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "用户名")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string CreditCard { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("PassWord", ErrorMessage = "密码和确认密码不一致。")]
        public string ConfirmPassword { get; set; }

        public string LicensePlate { get; set; }
    }

    public class MakeReservationViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Interval { get; set; }     
        public float ExpectPrice { get; set; }
    }

}