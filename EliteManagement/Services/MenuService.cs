using EliteManagement.Models.Entities;

namespace EliteManagement.Services;

internal class MenuService
{
    private readonly UserService _userService = new();
    private readonly CaseService _caseService = new();

    public async Task MainMenu()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("======= Elite Management! =======");
        Console.WriteLine("=================================\n");
        Console.WriteLine(" [1] - Create a case manager.");
        Console.WriteLine(" [2] - View all cases.");
        Console.WriteLine(" [3] - Create a new case.");
        Console.WriteLine(" [4] - Update a case.\n");
        Console.Write(" Choose one of the options above: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await CreateUserAsync();
                break;

            case "2":
                await AllCasesAsync();
                break;

            case "3":
                await NewCaseAsync();
                break;

            case "4":
                await UpdateCaseAsync();
                break;
        }
    }

    public async Task<UserEntity> CreateUserAsync()
    {
        var _entity = new UserEntity();
        Console.Clear();
        Console.WriteLine("========== Create new case manager ==========\n");
        Console.Write(" Case manager: ");
        _entity.FirstName = Console.ReadLine() ?? "";
        Console.WriteLine($" --> '{_entity.FirstName}' created successfully!");

        return await _userService.SaveAsync(_entity);
    }

    private async Task AllCasesAsync()
    {
        Console.Clear();
        Console.WriteLine("========== All cases ==========");
        foreach (var _case in await _caseService.GetAllAsync())
        {
            Console.WriteLine($"| Case ID: {_case.Id} | Created: {_case.Created} | Modified: {_case.Modified} |");
            Console.WriteLine("--------------------------------------------------------------------------------");
            
        }
    }

    private async Task NewCaseAsync()
    {
        var _entity = new CaseEntity();
        
        Console.Clear();
        Console.WriteLine("========== Create a new case ==========");
        Console.Write(" Customer firstname: ");
    }


    private async Task UpdateCaseAsync()
    {
        
    }
}
