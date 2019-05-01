using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
    public class PersonsController : ODataController
    {
        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return new string[] { "Alice", "Bob", "Chloe", "Dorothy", "Emma", "Fabian", "Garry", "Hannah", "Julian" }
                .Select(v => new Person { FirstName = v, Id = Guid.NewGuid(), Age = new Random().Next(80) }).AsQueryable();
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public class OdataModelConfigurations : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<Person>("Persons");
        }
    }
}