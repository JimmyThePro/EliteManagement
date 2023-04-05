using EliteManagement.Models.Entities;

namespace EliteManagement.Services;

internal class MenuService
{
    private readonly UserService _userService = new();
    private readonly CaseService _caseService = new();

    public async Task MainMenu(int userId)
    {
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("=============== Elite Management ===============");
        Console.WriteLine("================================================\n");
        Console.WriteLine(" [1] View all cases.");
        Console.WriteLine(" [2] Create a new case.");
        Console.WriteLine(" [3] View all users.");
        Console.WriteLine(" [4] Create a new user.");
        Console.Write(" \nChoose an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await AllCasesAsync();
                break;

            case "2":
                await NewCaseAsync(userId);
                break;

            case "3":
                await UsersAsync();
                break;

            default:
                Console.Clear();
                Console.Write(" No valid option! Try again...");
                break;
        }
    }

    private async Task AllCasesAsync()
    {
        Console.Clear();
        Console.WriteLine("========== All cases ==========\n");
        foreach (var _case in await _caseService.GetAllActiveAsync())
        {
            Console.WriteLine($"Ärendenummer: {_case.Id}");
            Console.WriteLine($"Skapad: {_case.Created}");
            Console.WriteLine($"Modifierad: {_case.Modified}");
            Console.WriteLine($"Status: {_case.Status.StatusName}");
            Console.WriteLine($"User: {_case.UserId}");
            Console.WriteLine("");
        }
    }

    private async Task UsersAsync()
    {
        Console.Clear();
        Console.WriteLine("========== All users ==========\n");
        foreach (var _user in await _userService.GetAllAsync())
        {
            Console.WriteLine($"Handläggare-ID: {_user.Id}");
            Console.WriteLine($"Namn: {_user.FirstName} {_user.LastName}");
            Console.WriteLine($"E-postadress: {_user.Email}");
            Console.WriteLine("");
        }
    }

    private async Task NewCaseAsync(int userId)
    {
        var _entity = new CaseEntity { UserId = userId };

        Console.Clear();
        Console.WriteLine("========== Create a new case ==========\n");
        Console.Write(" Customer Firstname: ");
        _entity.CustomerFirstName = Console.ReadLine() ?? "";
        Console.Write(" Customer Lastname: ");
        _entity.CustomerLastName = Console.ReadLine() ?? "";
        Console.Write(" Customer Email: ");
        _entity.CustomerEmail = Console.ReadLine() ?? "";
        Console.Write(" Customer Phonenumber: ");
        _entity.CustomerPhoneNumber = Console.ReadLine() ?? "";
        Console.Write(" Customer Profession: ");
        _entity.CustomerProfession = Console.ReadLine() ?? "";

        await _caseService.CreateAsync(_entity);
    }

    public async Task<UserEntity> CreateUserAsync()
    {
        var _entity = new UserEntity();
        Console.Clear();
        Console.WriteLine("=============== Create new user ===============\n");
        Console.Write(" FirstName: ");
        _entity.FirstName = Console.ReadLine() ?? "";
        Console.Write(" LastName: ");
        _entity.LastName = Console.ReadLine() ?? "";
        Console.Write(" Email: ");
        _entity.Email = Console.ReadLine() ?? "";
        Console.Write(" Phonenumber: ");
        _entity.PhoneNumber = Console.ReadLine() ?? "";

        return await _userService.CreateAsync(_entity);
    }
}
