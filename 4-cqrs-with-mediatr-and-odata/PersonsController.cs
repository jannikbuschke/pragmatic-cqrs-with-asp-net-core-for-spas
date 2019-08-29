using MediatR;
using Microsoft.AspNet.OData;
using System;
using System.Linq;

namespace Sample
{

    public class DeletePerson : IRequest
    {
        /// <summary>
        /// Id of the person
        /// </summary>
        public Guid Id { get; set; }
    }

    public class PersonsController : ODataController
    {
        private readonly DataContext ctx;

        public PersonsController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        [EnableQuery]
        public SingleResult<Person> GetPerson(Guid key)
        {
            return new SingleResult<Person>(ctx.Persons.Where(v => v.Id == key));
        }

        [EnableQuery]
        public IQueryable<Person> GetPersons()
        {
            return ctx.Persons;
        }
    }
}
