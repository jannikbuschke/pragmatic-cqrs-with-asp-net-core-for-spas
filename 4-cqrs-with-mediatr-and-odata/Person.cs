using System;

namespace Sample
{
    // The (code-first) database model (also the CQRS/Odata read-model)
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
