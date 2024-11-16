namespace WildLifeSpotter;

class Program
{
    static void Main()
    {
        var observation = new Observation
        {
            Location = "In the woods",
            Date = DateTime.Now,
            Notes = "Saw a deer",
            Animal = new Animal
            {
                Name = "Deer",
                Species = "Odocoileus virginianus"
            }
        };

        Console.WriteLine($"Saw a {observation.Animal.Name} at {observation.Location} on {observation.Date}");
    }
}