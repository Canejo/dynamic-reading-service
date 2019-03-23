using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Data
{
    //Add-Migration FirstMigration
    //Update-Database
    public class DynamicReadingServiceContext : DbContext
    {
        public DynamicReadingServiceContext(DbContextOptions<DynamicReadingServiceContext> options)
            : base(options)
        {
        }
    }
}
