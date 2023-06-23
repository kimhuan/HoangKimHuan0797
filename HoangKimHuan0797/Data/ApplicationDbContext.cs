using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoangKimHuan0797.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    

        public DbSet<HoangKimHuan0797.Models.HKHEmployee> HKHEmployee { get; set; } = default!;

    

        public DbSet<HoangKimHuan0797.Models.HKHPerson> HKHPerson { get; set; } = default!;

    

        public DbSet<HoangKimHuan0797.Models.HKHStudent> HKHStudent { get; set; } = default!;
    }
