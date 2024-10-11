using Praktika4Kurs.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika4Kurs
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Server=DESKTOP-VNNK9U7\\SQLEXPRESS;Initial Catalog=AutoServiceKuzmin;Trusted_Connection=True;")
        {
            if (Database.CreateIfNotExists())
            {
                Roles.AddRange(new Role[]
                {
                    Role.Of("админ"),
                    Role.Of("клиент"),
                    Role.Of("работник")
                });
                SaveChanges();
                Users.AddRange(new User[]
                {
                    User.Of("1", "1", Roles.First())
                });
                SaveChanges();
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DetailsFromOrder> DetailsFromOrders { get; set; }
        public DbSet<DetailsOrder> DetailsOrders { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceList> ServiceList { get; set; }
        public DbSet<ClientsService> clientsServices { get; set; }
    }
}
