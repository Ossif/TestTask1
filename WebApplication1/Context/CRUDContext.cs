using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class CRUDContext : DbContext
	{
		public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { 
				
		}

		public DbSet<Person> Persons { get; set; }
		public DbSet<Skill> Skills { get; set; }
	}
}
