namespace EliteManagement.Services;

internal class MenuService
{
    private readonly UserService _userService = new();
    private readonly CaseService _caseService = new();

    public async Task MainMenu()
    {
        Console.Clear();
        Console.WriteLine(" =============================");
        Console.WriteLine(" ===== Elite Management! =====");
        Console.WriteLine(" =============================\n");
        Console.WriteLine("\n ---");
        Console.WriteLine(" [1] View all cases.");
        Console.WriteLine(" [3] Create a new case.");
        Console.WriteLine(" [2] View all case managers.");
        Console.WriteLine(" ---");
        Console.Write("\nChoose one of the options above: ");

        var option = Console.ReadLine();

        switch (option)
        {

        }
    }
}
