using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class DetailsFromOrder
    {
        public int DetailsFromOrderId { get; set; }
        public Detail Detail { get; set; }
        public DetailsOrder Order { get; set; }
        public User Creator { get; set; }
        public int DetailDetailId { get; set; }
        public int OrderDetailsOrderId { get; set; }
        public int CreatorUserId { get; set; }
    }
}
