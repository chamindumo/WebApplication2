using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

public class BasicAuthHandler
{
    private readonly RequestDelegate _next;
    private readonly string _realm;

    public BasicAuthHandler(RequestDelegate next, string realm)
    {
        _next = next;
        _realm = realm;
    }

    public async Task Invoke(HttpContext context)
    {
        string authHeader = context.Request.Headers["Authorization"];

        if (authHeader != null && authHeader.StartsWith("Basic "))
        {
            // Extract credentials
            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            byte[] data = Convert.FromBase64String(encodedUsernamePassword);
            string decodedUsernamePassword = Encoding.UTF8.GetString(data);
            string[] parts = decodedUsernamePassword.Split(":");
            string username = parts[0];
            string password = parts[1];

            // Your authentication logic here
            // For example, check username and password against a database or a predefined list.

            if (IsValidUser(username, password))
            {
                await _next(context);
                return;
            }
        }

        // If the user is not authenticated or no credentials provided, send a challenge response
        context.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
        context.Response.StatusCode = 401;
    }

    private bool IsValidUser(string username, string password)
    {
        // Implement your own logic to validate the user's credentials.
        // Return true if the user is authenticated, otherwise false.
        // You may validate against a database or a predefined list of users.
        // For demonstration purposes, we'll use a simple hardcoded check.

        // In this modified version, we'll always challenge the user for credentials,
        // so we'll always return false here.
        return false;
    }
}
