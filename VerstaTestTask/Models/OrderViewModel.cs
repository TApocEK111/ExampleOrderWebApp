using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Web.Models;

public class OrderViewModel
{
    public Guid Id { get; set; }
    public uint Number { get; set; }

    [Required]
    [StringLength(170, MinimumLength = 1, ErrorMessage = "Слишком длинное название города отправителя")]
    public required string SenderCity { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 2, ErrorMessage = "Слишком длинный адрес отправителя")]
    public required string SenderAdress { get; set; }

    [Required]
    [StringLength(170, MinimumLength = 1, ErrorMessage = "Слишком длинное название города получателя")]
    public required string RecieverCity { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 2, ErrorMessage = "Слишком длинный адрес получателя")]
    public required string RecieverAdress { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Неправильно задан вес")]
    public required double WeightInGrams { get; set; }

    [Required]
    public required DateTime PickUpDate { get; set; }

    public bool IsNew { get; set; } = false;
}
