using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class DetailsOrder
    {
        public int DetailsOrderId { get; set; }
        public string OrderTitle { get; set; }
        public User Creator { get; set; }
        public int CreatorUserId { get; set; }
        public List<DetailsFromOrder> OrderDetails { get; set; }
    }
}
