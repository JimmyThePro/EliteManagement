using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteManagement.Models.Entities;

internal class AddressEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string StreetName { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string City { get; set; } = null!;

    public ICollection<UserEntity> Users { get; set;} = new HashSet<UserEntity>();
}
