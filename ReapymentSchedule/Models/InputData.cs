﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReapymentSchedule.Models
{
    public class InputData
    {
        [Required(ErrorMessage = "Type is required")]
        public TypeOfLoan Type { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public TypeOfPeriod PeriodType { get; set; }
        [Required(ErrorMessage = "Text is required")]
       // [RegularExpression(@"^[ a-zA-Z]+[ a-zA-Z-_?!., \n|\r|\r\n]*$", ErrorMessage = @"There are some incorect character (e.g. quotation marks)")]

        //[DataType(DataType.MultilineText)]
        public decimal Amount { get; set; }
        public decimal Instalment { get; set; }
      

    }
}