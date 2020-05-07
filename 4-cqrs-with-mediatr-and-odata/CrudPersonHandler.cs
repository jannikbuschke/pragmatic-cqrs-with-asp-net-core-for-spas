using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample
{
    // You might want to split the types on different files
    // However I like to put the request and corresponding
    // handler next to each other into one file and call
    // the file like the request. I.e. 'CreatePerson.cs'
    // would contain CreatePerson: IRequest<Person> as
    // well as CreatePersonHandler<CreatePerson, Person>.
    // In this file here I even put several requests
    // next to each other and only use one handler.
    // Usually I use one handler per request, however
    // all of this is of course up to you.

    public class CreatePerson : IRequest<Person>
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public class UpdatePerson : IRequest<Person>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public class DeletePerson : IRequest
    {
        public Guid Id { get; set; }
    }

    public class CrudPersonHandler
        : IRequestHandler<CreatePerson, Person>
        , IRequestHandler<UpdatePerson, Person>
        , IRequestHandler<DeletePerson>
    {
        private readonly DataContext ctx;

        public CrudPersonHandler(DataContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            Person person = new Person
            {
                FirstName = request.FirstName,
                Age = request.Age,
            };
            ctx.Add(person);

            await ctx.SaveChangesAsync();

            return person;
        }

        public async Task<Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
        {
            Person person = await ctx.Persons.SingleOrDefaultAsync(v => v.Id == request.Id);
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
            Person person = await ctx.Persons.SingleOrDefaultAsync(v => v.Id == request.Id);
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
