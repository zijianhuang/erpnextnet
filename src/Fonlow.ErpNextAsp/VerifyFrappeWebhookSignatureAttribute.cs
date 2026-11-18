using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.Text;

namespace Fonlow.ErpNextAsp;

// crafted by Claude.

/// <summary>
/// An attribute that verifies the signature of incoming Frappe webhooks using HMAC-SHA256.
/// Decorate your controller action with this attribute to ensure that the request is coming from a trusted source in the form of [ServiceFilter(typeof(VerifyFrappeWebhookSignatureAttribute))]
/// </summary>
public class VerifyFrappeWebhookSignatureAttribute : Attribute, IAuthorizationFilter
{
    private readonly string webhookSecret;

    public VerifyFrappeWebhookSignatureAttribute(string webhookSecret)
    {
        this.webhookSecret = webhookSecret;
    }

    /// <summary>
    /// expecting the webhook secret to be in configuration under "ERPNext:WebhookSecret". This constructor is generally used when the attribute is applied
    /// </summary>
    /// <param name="configuration">In generally injected by DI of ASP.NET Core.</param>
    public VerifyFrappeWebhookSignatureAttribute(IConfiguration configuration)
    {
        webhookSecret = configuration["ERPNext:WebhookSecret"];
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var request = context.HttpContext.Request;

        // Read signature from header
        if (!request.Headers.TryGetValue("X-Frappe-Webhook-Signature", out StringValues signatureHeader))
        {
            context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
            return;
        }

        // Read raw body
        request.EnableBuffering();
        using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
        var body = reader.ReadToEndAsync().Result;
        request.Body.Position = 0;

        // Compute HMAC-SHA256
        var secretBytes = Encoding.UTF8.GetBytes(webhookSecret);
        var bodyBytes = Encoding.UTF8.GetBytes(body);
        using var hmac = new HMACSHA256(secretBytes);
        var hash = hmac.ComputeHash(bodyBytes);
        var computedSignature = Convert.ToBase64String(hash);

        // Compare
        if (!CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(computedSignature),
                Encoding.UTF8.GetBytes(signatureHeader)))
        {
            context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
        }
    }
}
