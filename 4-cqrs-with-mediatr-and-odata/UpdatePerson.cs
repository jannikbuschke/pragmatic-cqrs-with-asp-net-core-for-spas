using MediatR;
using System;

namespace Sample
{
    public class UpdatePerson: IRequest<Person>
    {
        /// <summary>
        /// Id of the person
        /// </summary>
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
