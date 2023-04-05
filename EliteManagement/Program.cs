using EliteManagement.Services;

StatusTypeService statusService = new();
MenuService menuService = new();
UserService userService = new();

await statusService.CreateStatusTypesAsync();

var currentUser = await userService.GetAsync(x => x.Email == "jim@email.com");
if (currentUser == null)
    currentUser = await menuService.CreateUserAsync();

while (true)
{
    await menuService.MainMenu(currentUser.Id);
    Console.ReadKey();
}
