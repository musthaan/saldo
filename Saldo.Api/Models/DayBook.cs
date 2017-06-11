using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saldo.Api.Models
{
    public class DayBook
    {
        public int DayBookID { get; set; }
        public DateTime EntryDate { get; set; }
        public int CategoryID { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public int UserID { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}