using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinAppTemplate.Models;

namespace XamarinAppTemplate.Persistance
{
    public class XamarinAppTemplateDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
    }
}
