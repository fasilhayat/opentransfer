namespace OpenTransfer.Api.Core.Interfaces;

/// <summary>
/// Interface for accessing and managing system data.
/// </summary>
public interface IApplicationRepository
{
    /// <summary>
    /// Retrieves all systems asynchronously from the repository.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with the result being a collection of systems, or null if no data is found.</returns>
    Task<IEnumerable<Entitites.Application>?> ApplikationerAsync();

    /// <summary>
    /// Retrieves the total count of systems asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with the result being the total count of systems.</returns>
    Task<int> AntalApplikationerAsync();
}