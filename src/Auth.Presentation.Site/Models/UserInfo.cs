namespace Auth.Presentation.Site.Models
{
    public record UserInfo(string Email, IEnumerable<string> Roles);
}
