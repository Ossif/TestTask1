using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Person
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[JsonIgnore] 
		public long id { get; set; }
		public string name { get; set; }
		public string displayName { get; set; }
		public List<Skill> skills { get; set; } = new List<Skill>();

		public Person()
		{
			skills = new List<Skill>();
		}

	}
	public class Skill {

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[JsonIgnore] 
		public int id { get; set; }
		public string name { get; set; }
		
		[Range(0, 10)]
		public byte level { get; set; }	
	}


}
