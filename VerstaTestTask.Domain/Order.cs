using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Models;

public class Order
{
    public Guid Id { get; init; }

    [StringLength(170, MinimumLength = 1, ErrorMessage = "Слишком длинное название города отправителя")]
    public required string SenderCity { get; init; }

    [StringLength(300, MinimumLength = 2, ErrorMessage = "Слишком длинный адрес отправителя")]
    public required string SenderAdress { get; init; }

    [StringLength(170, MinimumLength = 1, ErrorMessage = "Слишком длинное название города получателя")]
    public required string RecieverCity { get; init; }

    [StringLength(300, MinimumLength = 2, ErrorMessage = "Слишком длинный адрес получателя")]
    public required string RecieverAdress { get; init; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Неправильно задан вес")]
    public required double WeightInGrams { get; init; }
    public required DateTime PickUpDate { get; init; }
}
