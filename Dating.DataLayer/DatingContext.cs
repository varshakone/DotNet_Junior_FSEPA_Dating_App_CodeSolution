using Dating.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.DataLayer
{
   public class DatingContext : DbContext
    {
        public DatingContext(DbContextOptions<DatingContext> options) : base(options)
        {

        }
        public DbSet<DateDetails> AllDates { get; set; }
    }
}
