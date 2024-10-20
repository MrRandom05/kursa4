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
        public ServiceStatus Status { get; set; } = ServiceStatus.Ordered;

        public static ClientsService Of(ServiceList service, Car car, ServiceStatus status)
        {
            return new ClientsService() { ClientCarCarId = car.CarId, ServiceServiceListId = service.ServiceListId, Status = status };
        }
    }

    public enum ServiceStatus
    {
        Ordered,
        InProgress,
        Done
    }
}
