namespace Linkinho.Domain.Core.Contracts.Service;

public interface ILinkService
{
    Task<string> GetUrlToRedirect(string identificator);
    Task CreateLink(string url);
}
