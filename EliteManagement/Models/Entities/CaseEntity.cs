using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteManagement.Models.Entities;

internal class CaseEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string CustomerFirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string CustomerLastName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string CustomerEmail { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string? CustomerPhoneNumber { get; set; }
    public string CustomerProfession { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Modified { get; set; } = DateTime.Now;

    public int StatusId { get; set; } = 1;
    public StatusTypeEntity Status { get; set; } = null!;

    public UserEntity User { get; set; } = null!;

    public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
}
