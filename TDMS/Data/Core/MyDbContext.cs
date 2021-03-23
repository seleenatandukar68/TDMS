using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDMS.Model;

namespace TDMS.Data.Core
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        public DbSet<TeleDirectory> TeleDirectories { get; set; }
    }
}
