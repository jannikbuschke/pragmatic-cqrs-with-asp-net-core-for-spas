using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Sample
{

    /// Create Person command DTO ///
    public class CreatePerson : IRequest<Person>
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
