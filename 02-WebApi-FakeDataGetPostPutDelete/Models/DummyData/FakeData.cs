using Bogus;
namespace _02_WebApi_FakeDataGetPostPutDelete.Models.DummyData

{
    public static class FakeData
    {

        private static List<User> _users;
        public static List<User> GetUsers(int count)
        {
            _users = new Faker<User>("en",null)
                .RuleFor(x => x.Id, faker => faker.IndexFaker + 1)
                .RuleFor(x => x.FirsName, faker => faker.Name.FirstName())
                .RuleFor(x => x.LastName, faker => faker.Name.LastName())
                .RuleFor(x => x.Adress, faker => faker.Address.FullAddress())
                .RuleFor(x => x.Phone, faker => faker.Phone.PhoneNumber())
                .RuleFor(x => x.Email, faker => faker.Lorem.Paragraph())
                .Generate(count);
            return _users;
        }
    }

}


