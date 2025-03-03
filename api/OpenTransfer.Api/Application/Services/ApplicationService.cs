namespace OpenTransfer.Api.Application.Services;

using Core.Interfaces;

/// <summary>
/// 
/// </summary>
public class ApplicationService
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IApplicationRepository _applicationRepository;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="applikationRepository"></param>
    public ApplicationService(IApplicationRepository applikationRepository)
    {
        _applicationRepository = applikationRepository;
    }

    /// <summary>
    /// Get all systemer asynchronously.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Core.Entitites.Application>?> ApplikationerAsync()
    {
        return await _applicationRepository.ApplikationerAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<int> AntalRegistreringerAsync()
    {
        return await _applicationRepository.AntalApplikationerAsync();
    }
}
