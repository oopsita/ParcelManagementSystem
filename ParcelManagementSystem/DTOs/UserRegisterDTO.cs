
namespace ParcelManagementSystem.DTOs;
public class UserRegisterDTO 
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "user";
}
