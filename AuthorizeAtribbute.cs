using Microsoft.AspNetCore.Authorization;

internal class AuthorizeAtribbute : AuthorizationPolicy {
    public string Roles { get; set; }
}