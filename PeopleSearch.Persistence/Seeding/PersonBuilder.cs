using PeopleSearch.Persistence.Entities;

namespace PeopleSearch.Persistence.Seeding
{
    public class PersonBuilder
    {
        private readonly Person _person;
        private readonly Address _address;

        private PersonBuilder(int id)
        {
            _person = new Person()
            {
                Id = id
            };
            _address = new Address()
            {
                Id = _person.Id,
                PersonId = _person.Id
            };
        }

        public static PersonBuilder BuildPerson(int id)
        {
            return new PersonBuilder(id);
        }

        public PersonBuilder Name(string firstName, string lastName)
        {
            _person.FirstName = firstName;
            _person.LastName = lastName;
            return this;
        }

        public PersonBuilder Age(int age)
        {
            _person.Age = age;
            return this;
        }

        public PersonBuilder Interests(string interests)
        {
            _person.Interests = interests;
            return this;
        }

        public PersonBuilder PictureUrl(string pictureUrl)
        {
            _person.PictureUrl = pictureUrl;
            return this;
        }

        public PersonBuilder Street(string street)
        {
            _address.Street = street;
            return this;
        }

        public PersonBuilder City(string city)
        {
            _address.City = city;
            return this;
        }

        public PersonBuilder State(string state)
        {
            _address.State = state;
            return this;
        }

        public PersonBuilder Country(string country)
        {
            _address.Country = country;
            return this;
        }

        public PersonBuilder ZipCode(string zipCode)
        {
            _address.ZipCode = zipCode;
            return this;
        }

        public Person GetPerson() => _person;
        public Address GetAddress() => _address;
    }
}
