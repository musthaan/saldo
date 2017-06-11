using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saldo.Api.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Limit { get; set; }
        public int UserID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
}