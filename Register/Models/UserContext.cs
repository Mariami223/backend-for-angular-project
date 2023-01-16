using System;
using Microsoft.EntityFrameworkCore;
namespace Register.Models
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions options) :base(options)
		{

		}


        public DbSet<User> Users { get; set;}
    }

	
	
}
