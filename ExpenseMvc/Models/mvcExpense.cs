using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseMvc.Models
{
    public class mvcExpense
    {
        public int exId { get; set; }
        [Required(ErrorMessage ="Enter Expense Name")]
        public string exName { get; set; }
        [Required(ErrorMessage ="Enter Description")]
        public string exDec { get; set; }
        [Required(ErrorMessage ="Select Category of Expense")]
        public string exCat { get; set; }
        [Required(ErrorMessage ="Enter Amount")]
        public int exAmount { get; set; }
        [Required(ErrorMessage = "Enter Category Id of Expense")]
        public int catId { get; set; }
        [Required(ErrorMessage = "Please Enter Date Time")]
        private DateTimeOffset dt = DateTimeOffset.Now;

        public DateTimeOffset exDateTime { get { return dt; } set { dt = value; } }

        public virtual mvcCategory Category { get; set; }
    }
}