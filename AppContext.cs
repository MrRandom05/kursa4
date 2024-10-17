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
        // home: (localdb)\MSSqlLocalDb     college: DESKTOP-VNNK9U7\\SQLEXPRESS
        public AppContext() : base("Server=(localdb)\\MSSqlLocalDb;Initial Catalog=AutoServiceKuzmin;Trusted_Connection=True;")
        {
            if (Database.CreateIfNotExists())
            {
                Users.AddRange(new User[]
                {
                    User.Of("1", "1", Role.Admin)
                });
                SaveChanges();
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DetailsFromOrder> DetailsFromOrders { get; set; }
        public DbSet<DetailsOrder> DetailsOrders { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceList> ServiceList { get; set; }
        public DbSet<ClientsService> clientsServices { get; set; }
    }
}
