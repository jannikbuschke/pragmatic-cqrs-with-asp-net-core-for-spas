using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample
{
    public class PersonHandler
        : IRequestHandler<CreatePerson, Person>
        , IRequestHandler<UpdatePerson, Person>
        , IRequestHandler<DeletePerson>
    {
        private readonly DataContext ctx;

        public PersonHandler(DataContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                Age = request.Age,
            };
            ctx.Add(person);

            await ctx.SaveChangesAsync();

            return person;
        }

        public  async Task<Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
        {
            var person = await ctx.Persons.SingleOrDefaultAsync(v => v.Id == request.Id);
            if (person == null)
            {
                throw new Exception("Record does not exist");
            }
            person.Age = request.Age;
            person.FirstName = request.FirstName;
            ctx.Persons.Update(person);
            await ctx.SaveChangesAsync();
            return person;
        }

        public async Task<Unit> Handle(DeletePerson request, CancellationToken cancellationToken)
        {
            var person = await ctx.Persons.SingleOrDefaultAsync(v => v.Id == request.Id);
            if (person == null)
            {
                throw new Exception("Record does not exist");
            }
            ctx.Persons.Remove(person);
            await ctx.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
