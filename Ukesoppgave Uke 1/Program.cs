namespace Ukesoppgave_Uke_1;

public class Animal
{
    public string Name { get; set; }
    public string[] Food { get; set; }
    public int CorrectFoodIndex { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hva heter du?");
        var name = Console.ReadLine();
        var capitalizedName = char.ToUpper(name[0]) + name.Substring(1);

        var animals = new Animal[5]
        {
            new() { Name = "fisk", Food = new[] { "Reker", "Kebab", "Biff" }, CorrectFoodIndex = 0 },
            new() { Name = "apekatt", Food = new[] { "Biff", "Bananer", "Leverpostei" }, CorrectFoodIndex = 1 },
            new() { Name = "gorilla", Food = new[] { "Nøtter", "Blader", "Ost" }, CorrectFoodIndex = 2 },
            new() { Name = "løve", Food = new[] { "Biff", "Gulerot", "Innsekter" }, CorrectFoodIndex = 0 },
            new() { Name = "pusekatt", Food = new[] { "Eple", "Gress", "Tunfisk" }, CorrectFoodIndex = 2 }
        };

        var random = new Random();
        var chosenAnimal = animals[random.Next(0, animals.Length)];
        Console.WriteLine($"\nHei, {capitalizedName}.\n" +
                          $"Du ser en {chosenAnimal.Name}. Du går bort til den.\n");

        Console.WriteLine($"Du får lyst til å gi {chosenAnimal.Name}en noe snacks å spise.\n" +
                          $"Hva velger du å gi? Velg 1-3.\n");
        var counter = 1;
        foreach (var food in chosenAnimal.Food)
        {
            Console.WriteLine($"{counter}. {food}");
            counter++;
        }

        var choice = Console.ReadLine();
        var capitalizedAnimalName = char.ToUpper(chosenAnimal.Name[0]) + chosenAnimal.Name.Substring(1);
        if (int.TryParse(choice, out var selectedFoodIndex) && selectedFoodIndex >= 1 && selectedFoodIndex <= 3)
        {
            if (selectedFoodIndex - 1 == chosenAnimal.CorrectFoodIndex)
                Console.WriteLine($"\n{capitalizedAnimalName}en elsket snacken og gikk sin vei!\n" +
                                  $"Det samme gjorde du..");
            else
                Console.WriteLine($"\n{capitalizedAnimalName}en synes du var mer fristende! Du ble spist levende.");
        }
        else
        {
            Console.WriteLine("\nUgyldig valg, prøv igjen. Du kan kun velge 1-3.");
        }

        Console.ReadLine();
    }
}