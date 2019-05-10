using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Sample
{
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        [EnableQuery]
        [HttpGet]
        public IQueryable<Person> Get(string search = "")
        {
            return new string[] { "Alice", "Bob", "Chloe", "Dorothy", "Emma", "Fabian", "Garry", "Hannah", "Julian" }
                .Select(v => new Person { Name = v, Id = Guid.NewGuid() })
                .AsQueryable()
                .Where(v => v.Name.Contains(search));
        }

        public class Person
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
