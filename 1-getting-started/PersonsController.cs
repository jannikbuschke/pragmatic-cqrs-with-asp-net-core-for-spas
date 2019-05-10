using Microsoft.AspNet.OData;
using System;
using System.Linq;

namespace Sample
{
    public class PersonsController : ODataController
    {
        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return new string[] { "Alice", "Bob", "Chloe", "Dorothy", "Emma", "Fabian", "Garry", "Hannah", "Julian" }
                .Select(v => new Person { FirstName = v, Id = Guid.NewGuid(), Age = new Random().Next(80) })
                .AsQueryable();
        }
    }
}