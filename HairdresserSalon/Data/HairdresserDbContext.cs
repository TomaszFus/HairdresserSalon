using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;

namespace HairdresserSalon.Data
{
    public class HairdresserDbContext : DbContext
    {
        public HairdresserDbContext(DbContextOptions<HairdresserDbContext> options) : base(options)
        {

        }

        public DbSet<HairdresserModel> Hairdressers { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<DayModel> Days { get; set; }
        public DbSet<HourModel> Hours { get; set; }
        public DbSet<VisitModel> Visits { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OpinionModel> Opinions { get; set; }
        public DbSet<OpeningHourModel> OpeningHours { get; set; }
        public DbSet<InformationModel> Informations { get; set; }
    }
}
