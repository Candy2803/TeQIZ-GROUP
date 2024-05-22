using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeQIZ_WEBSITE.Models;

namespace TeQIZ_WEBSITE.Data
{
    public class TeQIZ_WEBSITEContext : DbContext
    {
        public TeQIZ_WEBSITEContext (DbContextOptions<TeQIZ_WEBSITEContext> options)
            : base(options)
        {
        }

        public DbSet<TeQIZ_WEBSITE.Models.Contact> Contact { get; set; } = default!;
        public DbSet<TeQIZ_WEBSITE.Models.Me> Me { get; set; } = default!;
        public DbSet<TeQIZ_WEBSITE.Models.Logout> Logout { get; set; } = default!;
        public DbSet<TeQIZ_WEBSITE.Models.Web> Web { get; set; } = default!;
    }
}
