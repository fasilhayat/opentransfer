namespace OpenTransfer.Api.Infrastructure.Repositories;

using Core.Interfaces;
using Data;
using System.Data;

/// <summary>
/// Repository for interacting with applikation-related data in the database.
/// </summary>
public class ApplicationRepository : IApplicationRepository
{
    /// <summary>
    /// The DbContext instance used to interact with the database.
    /// </summary>
    private readonly DbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRepository"/> class.
    /// </summary>
    /// <param name="context">The DbContext used to interact with the database.</param>
    public ApplicationRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Fetches all applikationer from the database.
    /// </summary>
    /// <returns>A list of <see cref="Application"/> objects, or null if an error occurs.</returns>
    public async Task<IEnumerable<Core.Entitites.Application>?> ApplikationerAsync()
    {
        var applikationer = new List<Core.Entitites.Application>();
        try
        {
            const string functionName = "kenosis.fn_get_applikationer()"; // The stored function to retrieve systems.
            var resultTable = await _context.ExecuteFunctionAsync(functionName);

            // If no systems are returned, return an empty list.
            if (resultTable.Rows.Count == 0)
                return applikationer;

            // Map the result rows to the Applikation entity
            applikationer.AddRange(resultTable.Rows.Cast<DataRow>()
                .Select(row => new Core.Entitites.Application
                {
                  
                }));
        }
        catch (Exception ex)
        {
            // Log the exception (adjust based on your logging setup)
            Console.WriteLine($"Error fetching applikationer: {ex.Message}");
            return null;
        }
        return applikationer;
    }

    /// <summary>
    /// Fetches the total number of applikationer from the database.
    /// </summary>
    /// <returns>The total number of applikationer, or -1 if an error occurs.</returns>
    public async Task<int> AntalApplikationerAsync()
    {
        try
        {
            const string functionName = "SElECT kenosis.fn_get_antal_applikationer()"; // The stored function to retrieve the count of systems.
            var result = await _context.ExecuteScalarFunctionAsync<int>(functionName);
            return result;
        }
        catch (Exception ex)
        {
            // Log the exception (adjust based on your logging setup)
            Console.WriteLine($"Error fetching systems count: {ex.Message}");
            return -1;
        }
    }
}