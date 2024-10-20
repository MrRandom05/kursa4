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
        [NotMapped]
        public string Details
        {
            get
            {
                string res = "";
                var order = Navigator.db.DetailsOrders.Include("OrderDetails").First(x => x.DetailsOrderId == DetailsOrderId);
                foreach (var item in order.OrderDetails)
                {
                    if (!string.IsNullOrEmpty(res)) res += "\n";
                    res += $"{item.Detail.DetailName} x{item.Count}";
                }

                return res;
            }
        }
    }
}
