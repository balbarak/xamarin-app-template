using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAppTemplate.Models;

namespace XamarinAppTemplate.Persistance
{
    public class XamarinAppTemplateDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlite($"Filename={MobileAppSettings.DATABASE_FULL_FILE_NAME}", (options) =>
            {

            });
        }


        public async Task EnsureSeeding()
        {
            bool hasData = await Countries.AnyAsync();

            if (!hasData)
            {
                var dataBytes = Resx.Data.Countries;

                var data = Encoding.UTF8.GetString(dataBytes);

                var result = JsonConvert.DeserializeObject<Country[]>(data);

                foreach (var item in result)
                {
                    await Countries.AddAsync(item);

                    Debug.WriteLine($"Adding country: {item.Name.English}");
                }

                await SaveChangesAsync();
                
            }
        }

        public static Task<XamarinAppTemplateDbContext> InitDatabase()
        {
            return Task.Run(async () =>
            {
                if (!Directory.Exists(MobileAppSettings.DATABASE_FOLDER_PATH))
                {
                    Directory.CreateDirectory(MobileAppSettings.DATABASE_FOLDER_PATH);
                }

                var context = new XamarinAppTemplateDbContext();

                context.Database.Migrate();
                context.Database.EnsureCreated();

                await context.EnsureSeeding();

                return context;
            });
        }

        public static Task DeleteDatabase()
        {
            var context = new XamarinAppTemplateDbContext();

            return context.Database.EnsureDeletedAsync();
        }
    }
}
