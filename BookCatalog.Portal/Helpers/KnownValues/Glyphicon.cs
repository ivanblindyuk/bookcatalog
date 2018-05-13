using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCatalog.Portal.Helpers.KnownValues
{
    public enum Glyphicon
    {
        [Display(Name = "plus")]
        Add,

        [Display(Name = "copyright")]
        Copyright,

        [Display(Name = "save")]
        Save,

        [Display(Name = "times")]
        Cancel,

        [Display(Name = "edit")]
        Edit,

        [Display(Name = "trash")]
        Delete,

        [Display(Name = "calendar")]
        Date
    }
}