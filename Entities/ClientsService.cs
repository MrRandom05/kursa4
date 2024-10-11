using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs.Entities
{
    public class ClientsService
    {
        public int ClientsServiceId { get; set; }
        public Car ClientCar {  get; set; }
        public ServiceList Service {  get; set; }
        public int ClientCarCarId { get; set; }
        public int ServiceServiceListId { get; set; }
    }
}
