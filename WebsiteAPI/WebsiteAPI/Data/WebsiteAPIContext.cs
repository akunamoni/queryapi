#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebsiteAPI;

namespace WebsiteAPI.Data
{
    public class WebsiteAPIContext : DbContext
    {
        public WebsiteAPIContext (DbContextOptions<WebsiteAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebsiteAPI.WebApp> WebApp { get; set; }
    }
}
