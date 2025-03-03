using OpenTransfer.Api.Application.Services;

namespace OpenTransfer.Api.Endpoints;

/// <summary>
/// Endpoints for the Applikation API. Handles all requests related to Applikation.
/// </summary>
public static class ApplicationEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpoints"></param>
    public static void MapApplikationEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var applikation = endpoints.MapGroup("/v1/applikation").WithTags("Applikation");
        var applikationer = endpoints.MapGroup("/v1/applikationer").WithTags("Applikation");

        applikation.MapGet("/{id:int}/afhaengigheder",
            static (int id, ApplicationService applicationService) => Applications(applicationService));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applikationService"></param>
    /// <returns></returns>
    private static async Task<IResult> Applications(ApplicationService applikationService)
    {
        var applikationer = await applikationService.ApplikationerAsync();
        if (applikationer == null)
            return Results.Content("Applikationer not found", contentType: "application/json", statusCode: 404);

        var jsonResponse = System.Text.Json.JsonSerializer.Serialize(applikationer);
        return Results.Content(jsonResponse, contentType: "application/json", statusCode: 200);
    }
}