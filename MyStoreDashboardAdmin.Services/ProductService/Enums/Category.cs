using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStoreAdminDashboard.Services
{
    public enum Category
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Hair")]
        Hair,
        [Display(Name = "Face")]
        Face,
        [Display(Name = "Makeup")]
        Makeup,
        [Display(Name = "Body")]
        Body
    }
}
