using EliteManagement.Services;

StatusTypeService statusTypeService = new();
// MenuService menuService = new();

await statusTypeService.CreateStatusTypesAsync();