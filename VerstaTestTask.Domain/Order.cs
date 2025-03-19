using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerstaTestTask.Domain;

public class Order : Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public uint Number { get; set; }

    [Required]
    public required string SenderCity { get; set; }

    [Required]
    public required string SenderAdress { get; set; }

    [Required]
    public required string RecieverCity { get; set; }

    [Required]
    public required string RecieverAdress { get; set; }

    [Required]
    public required double WeightInGrams { get; set; }

    [Required]
    public required DateTime PickUpDate { get; set; }
}
