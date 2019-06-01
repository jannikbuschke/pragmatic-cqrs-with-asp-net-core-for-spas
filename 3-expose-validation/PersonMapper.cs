namespace Sample
{
    public static class PersonMapper
    {
        public static Person ToPerson(this CreatePerson dto)
        {
            return new Person
            {
                Name = dto.Name,
                Email = dto.Email
            };
        }
    }
}
