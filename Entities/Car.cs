using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarNumber { get; set; }
        public int OwnerUserId { get; set; }
        public User Owner { get; set; }

        public static Car Of(string number, int ownerId)
        {
            return new Car() { CarNumber = number, OwnerUserId = ownerId };
        }
    }
}
