using EliteManagement.Models.Entities;

namespace EliteManagement.Services;

internal class MenuService
{
    private readonly UserService _userService = new();
    private readonly CaseService _caseService = new();

    public async Task MainMenu(int userId)
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("============= Elite Management =============");
        Console.WriteLine("============================================");
        Console.WriteLine(" --- We are the best staffing company! ---\n");
        Console.WriteLine(" [1] Create a New case.");
        Console.WriteLine(" [2] View all Cases.");
        Console.WriteLine(" [3] View a Specific case.");
        Console.WriteLine(" [4] View all Users.");
        Console.WriteLine(" [5] Update a specific case Status.");
        Console.Write(" \nChoose an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await NewCaseAsync(userId);
                break;

            case "2":
                await AllCasesAsync();
                break;

            case "3":
                await GetCaseAsync();
                break;

            case "4":
                await UsersAsync();
                break;

            case "5":
                await UpdateStatusAsync();
                break;

            default:
                Console.Clear();
                Console.Write(" No valid option! Please try again.");
                break;
        }
    }

    private async Task AllCasesAsync()
    {
        Console.Clear();
        Console.WriteLine("============ All cases ===========\n");
        foreach (var _case in await _caseService.GetAllAsync())
        {
            Console.WriteLine($" Case ID-number: {_case.Id}");
            Console.WriteLine($" Created: {_case.Created}");
            Console.WriteLine($" Modified: {_case.Modified}");
            Console.WriteLine($" Case status: {_case.Status.StatusName}");
            Console.WriteLine($" User: {_case.UserId}\n");
        }
    }

    private async Task UsersAsync()
    {
        Console.Clear();
        Console.WriteLine("============ All users ===========\n");
        foreach (var _user in await _userService.GetAllAsync())
        {
            Console.WriteLine($" User-ID: {_user.Id}");
            Console.WriteLine($" Username: {_user.FirstName} {_user.LastName}");
            Console.WriteLine($" Email: {_user.Email}\n");
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

    private async Task GetCaseAsync()
    {
        Console.Clear();
        Console.WriteLine("=============== View a specific case ===============\n");
        Console.Write("Enter case ID-number: ");
        int id = int.Parse(Console.ReadLine());
        var _case = await _caseService.GetAsync(x => x.Id == id);
        if (_case != null)
        {
            Console.WriteLine($"\n Case-ID: {_case.Id} Created: {_case.Created} Modified: {_case.Modified}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($" Customer Name: {_case.CustomerFirstName} {_case.CustomerLastName}");
            Console.WriteLine($" Customer Email: {_case.CustomerEmail}");
            Console.WriteLine($" Customer Phonenumber: {_case.CustomerEmail}");
            Console.WriteLine($" Customer Profession: {_case.CustomerProfession}");
            Console.WriteLine($" Started by user-ID: {_case.UserId}");
            Console.WriteLine($" --> Case status: {_case.Status.StatusName}\n");
        }
        else
        {
            Console.WriteLine(" Case-ID not found.");
        }
    }

    private async Task UpdateStatusAsync()
    {
        Console.Clear();
        Console.WriteLine("=============== Update case status ===============\n");
        Console.Write("Enter case ID-number: ");
        int caseId = int.Parse(Console.ReadLine());
        
        var _case = await _caseService.GetAsync(x => x.Id == caseId);
        if (_case != null)
        {
            Console.Write("Enter new status ID-number: ");
            int statusId = int.Parse(Console.ReadLine());
            await _caseService.UpdateCaseStatusAsync(caseId, statusId);
            Console.WriteLine("Case status updated successfully.");
        }
        else
        {
            Console.WriteLine(" Case-ID not found.");
        }
    }
}
