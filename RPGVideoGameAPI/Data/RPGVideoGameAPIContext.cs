using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameLibrary.Models;

namespace RPGVideoGameAPI.Data
{
    public class RPGVideoGameAPIContext : DbContext
    {
        public RPGVideoGameAPIContext (DbContextOptions<RPGVideoGameAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RPGVideoGameLibrary.Models.Profile> Profile { get; set; }
    }
}
