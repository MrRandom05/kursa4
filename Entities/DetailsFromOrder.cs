using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class DetailsFromOrder
    {
        public int DetailsFromOrderId { get; set; }
        public int Count { get; set; }
        [Required]
        public Detail Detail { get; set; }
        [Required]
        public int DetailDetailId { get; set; }
    }
}
