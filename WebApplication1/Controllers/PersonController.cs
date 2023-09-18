using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
	[Route("api/[controller]/")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly CRUDContext _crudContext;

		public PersonController(CRUDContext crudContext) { 
				_crudContext = crudContext;
		}

		// GET: api/Persons
		[HttpGet]
		public IEnumerable<Person> Get()
		{
			return _crudContext.Persons.Include(x => x.skills);
		}

		// GET api/Persons/5
		[HttpGet("{id}")]
		public Person Get(int id)
		{
			Person p = _crudContext.Persons.Include(x => x.skills).SingleOrDefault(x => x.id == id);
			return p;
		}

		// POST api/Persons
		[HttpPost]
		public void Post([FromBody] Person person)
		{
			_crudContext.Persons.Add(person);
			_crudContext.SaveChanges();
		}

		// PUT api/Persons/5
		[HttpPut("{id}")]
		public void Put([FromBody] Person person)
		{
			_crudContext.Persons.Update(person);
			_crudContext.SaveChanges();
		}

		// DELETE api/Persons/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var item = _crudContext.Persons.FirstOrDefault(x=>x.id == id);
			if(item != null) { 
				_crudContext.Persons.Remove(item);
				_crudContext.SaveChanges();
			}
		}
	}
}
