using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Domain;

public class Entity
{
    [Key]
    public Guid Id { get; set; }
}
