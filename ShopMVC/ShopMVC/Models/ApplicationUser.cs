using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public int CartId { get; set; }

    public Cart Cart { get; set; }
}
