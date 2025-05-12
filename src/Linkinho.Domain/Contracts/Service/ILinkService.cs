using Linkinho.Domain.Entities;

namespace Linkinho.Domain.Contracts.Service;

public interface ILinkService
{
    Task<string> GetUrlToRedirect(string identificator);
    Task<Link> CreateLink(string url);
    Task<Link> GetLink(string identificator, bool countClick = true);
}
