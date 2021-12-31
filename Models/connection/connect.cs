using Microsoft.EntityFrameworkCore;


namespace atmnet
{
   public class connect:DbContext
   {
       public DbSet<user> users{ get; set; }

       public DbSet<account> accounts{ get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder db)
       {
          db.UseSqlServer( "Data Source =.;Initial Catalog=atm;Integrated Security=True");		

       }
   
   } 
}