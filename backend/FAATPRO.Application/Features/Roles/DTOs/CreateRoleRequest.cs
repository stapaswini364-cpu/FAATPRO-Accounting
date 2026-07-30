using System.ComponentModel.DataAnnotations;

namespace FAATPRO.Application.Features.Roles.DTOs;

public class CreateRoleRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;


    [MaxLength(250)]
    public string? Description { get; set; }
}