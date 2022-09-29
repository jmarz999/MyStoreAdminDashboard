using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStoreAdminDashboard.Services.ProductService.Enums
{
    public enum Manufacturer
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Balea")]
        Balea,
        [Display(Name = "Alverde")]
        Alverde,
        [Display(Name = "Essence")]
        Essence,
        [Display(Name = "Maybeline")]
        Maybeline,
        [Display(Name = "Garnier")]
        Garnier,
        [Display(Name = "Siberica")]
        Siberica
    }
}
