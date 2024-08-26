using NetworkDetect.Core.Entities;

public interface IJwtService
{
	public string GetJwt(AppUser user, IList<string> roles);
}