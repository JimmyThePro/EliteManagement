using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteManagement.Models.Entities;

internal class UserEntity
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set;} = null!;

    [Required]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string PhoneNumber { get; set; } = null!;

    public int UserTypeId { get; set; }
    public int AddressId { get; set; }

    public UserTypeEntity UserType { get; set; } = null!;
    public AddressEntity Address { get; set; } = null!;

    public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
}
