using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseMvc.Models
{
    public class mvcCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mvcCategory()
        {
            this.Expenses = new HashSet<mvcExpense>();
        }

        public int catId { get; set; }
        [Required(ErrorMessage = "Enter Category Name")]
        public string catName { get; set; }
        [Required(ErrorMessage ="Enter Category Limit")]
        public int catExlimit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mvcExpense> Expenses { get; set; }
    }
}