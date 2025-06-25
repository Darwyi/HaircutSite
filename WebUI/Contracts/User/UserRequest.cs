using System.ComponentModel.DataAnnotations;

namespace WebUI.Contracts.User
{
    public record UserRequest(
        [Required] string Name,
        [Required] string Password);
}
