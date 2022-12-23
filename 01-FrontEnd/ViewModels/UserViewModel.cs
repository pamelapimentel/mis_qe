using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class UserBasicInformationViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string FatherLastName { get; set; }
        [Required]
        public string MotherLastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}