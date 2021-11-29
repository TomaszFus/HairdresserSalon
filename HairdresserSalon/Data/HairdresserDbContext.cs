﻿using Microsoft.EntityFrameworkCore;
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
    }
}