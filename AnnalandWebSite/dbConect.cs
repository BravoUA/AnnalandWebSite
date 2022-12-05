using AnnalandWebSite.Models;

using Microsoft.EntityFrameworkCore;

namespace AnnalandWebSite
{
    public class DBConect : DbContext
    {


        public DbContext DbContext { get; set; }
           public DbSet<MachineryModel> Machinery { get; set; }
           public DbSet<TechnicModel> Technic { get; set; }

    

       public DBConect()
       {
            Database.EnsureCreated();
        }

       protected override void OnConfiguring(DbContextOptionsBuilder options)
       {
           // connect to sqlite database
           options.UseSqlite("Filename=ALDB.db");
       }



    }
}
