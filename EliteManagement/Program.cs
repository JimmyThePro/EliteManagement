using EliteManagement.Services;

StatusTypeService statusTypeService = new();
MenuService menuService = new();

await statusTypeService.CreateStatusTypesAsync();

while (true)
{
    await menuService.MainMenu();
    Console.ReadKey();
}
