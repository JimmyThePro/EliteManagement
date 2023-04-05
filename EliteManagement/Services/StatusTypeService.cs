using EliteManagement.Contexts;
using EliteManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteManagement.Services;

internal class StatusTypeService
{
    private readonly DataContext _context = new();

    public async Task CreateStatusTypesAsync()
    {
        if (!await _context.StatusTypes.AnyAsync())
        {
            string[] _statuses = new string[] { "Not started", "In progress", "Completed" };

            foreach (var status in _statuses)
            {
                await _context.AddAsync(new StatusTypeEntity { StatusName = status });
                await _context.SaveChangesAsync();
            }
        }
    }
}
