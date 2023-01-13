using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseMvc.Models
{
    public class mvcTotal
    {
        public int totId { get; set; }
        [Required(ErrorMessage = "Enter total limit of expense")]
        public Nullable<int> totEx { get; set; }
    }
}