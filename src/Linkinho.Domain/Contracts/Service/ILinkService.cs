using Linkinho.Domain.Entities;

namespace Linkinho.Domain.Contracts.Service;

public interface ILinkService
{
    Task<string> GetUrlToRedirect(string identificator);
    Task<Link> CreateLink(string url);
}
