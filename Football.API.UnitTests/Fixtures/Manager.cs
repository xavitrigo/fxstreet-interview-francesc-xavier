using Football.API.Models;

namespace Football.API.UnitTests.Fixtures
{
    public class ManagerFixture
    {
        public static Manager managerInDb = new Manager() 
        {
            Id = 1,
            Name = "Alex",
            RedCard = 1,
            YellowCard = 2
        };

        public static Manager managerToAdd = new Manager()
        {
            Id = 2,
            Name = "Zidane",
            RedCard = 0,
            YellowCard = 1
        };

        public static Manager managerToUpdate = new Manager()
        {
            Id = 3,
            Name = "Guardiola",
            RedCard = 2,
            YellowCard = 1
        };
    }
}
