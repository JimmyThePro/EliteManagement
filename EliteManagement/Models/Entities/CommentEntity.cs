using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteManagement.Models.Entities;

internal class CommentEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string Comment { get; set; } = null!;

    public CaseEntity Case { get; set; } = null!;
}
