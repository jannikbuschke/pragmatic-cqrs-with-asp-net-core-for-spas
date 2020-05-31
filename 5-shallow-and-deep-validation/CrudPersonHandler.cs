using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Sample
{
    public class SignUp : IRequest<User>
    {
        [Required]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
    }

    public class CrudPersonHandler : IRequestHandler<SignUp, User>
    {
        private readonly DataContext ctx;

        public CrudPersonHandler(DataContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<User> Handle(SignUp request, CancellationToken cancellationToken)
        {
            User person = new User
            {
                FirstName = request.FirstName,
                Age = request.Age,
            };
            ctx.Add(person);

            await ctx.SaveChangesAsync();

            return person;
        }

    }
}
