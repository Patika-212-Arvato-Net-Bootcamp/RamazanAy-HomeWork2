using Bogus;
using WebApp2.Entities;


namespace WebApp2.FakeData;

public static class FakeDb
{
   private static List<User> _users = new List<User>(); //I have a list by User
   private static List<BootCamp> _bootCamps = new List<BootCamp>();//I have a list by Bootcamp
   public static List<User> GetUsers(int number)
   {
      if (_users.Count==0)
      {
         _users = new Faker<User>() //I used Bogus for create fake DataBase. And Fills the following parameters as fake
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Adress, f => f.Address.Country())
            .RuleFor(a => a.Name, f => f.Name.FirstName())
            .RuleFor(b => b.SurName, f => f.Name.LastName())
            .RuleFor(b => b.BootcamId, f => f.IndexFaker).Generate(number); // Aslında bu bootcampId ile altta ki BootcampId nin ilişkisel olması  gerek
                                                                                                // ancak simüle edeceğim için şuan bir problem yok :D
      }
      return _users;
   }

      
   public static List<BootCamp> GetBootCamps(int number)
   {
      if (_bootCamps.Count==0)
      {
         _bootCamps = new Faker<BootCamp>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(a => a.BootCampName, f => f.Company.CompanyName()).Generate(number);
      }
      return _bootCamps;
   }

}