using AnnalandWebSite.Models;

using Microsoft.EntityFrameworkCore;

namespace AnnalandWebSite
{
    public class DBConect : DbContext
    {


        public DbContext DbContext { get; set; }
        public DbSet<MachineryModel> Machinery { get; set; }
        public DbSet<TechnicModel> Technic { get; set; }
        public DbSet<HadImgPath> HadImgPath { get; set; }
        public DbSet<HadImgPathT> HadImgPathT { get; set; }
        public DbSet<MachinesImg> MachinesImg { get; set; }
        public DbSet<TechnicImg> TechnicImg { get; set; }
		public DbSet<Users> Users { get; set; }
		public DbSet<Salt> Salt{ get; set; }



		public DBConect()
       {
            Database.EnsureCreated();
        }

       protected override void OnConfiguring(DbContextOptionsBuilder options)
       {
           // connect to sqlite database
           options.UseSqlite("Filename=MyDb.db");
       }
        
        


    }
}
