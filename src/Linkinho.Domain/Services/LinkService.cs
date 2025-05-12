using Linkinho.Domain.Contracts.Service;
using Linkinho.Domain.Core.Contracts;
using Linkinho.Domain.Entities;

namespace Linkinho.Domain.Services;

public class LinkService : ILinkService
{
    private readonly IRepository<Link> _linkRepository;

    public LinkService(IRepository<Link> linkRepository)
    {
        _linkRepository = linkRepository;
    }

    public async Task<Link> CreateLink(string url)
    {
        if (string.IsNullOrEmpty(url))
            throw new ArgumentNullException(nameof(url));

        var link = new Link(url);
        return await _linkRepository.Create(link);
    }

    public async Task<string> GetUrlToRedirect(string identificator)
    {
        if (string.IsNullOrEmpty(identificator))
            throw new ArgumentNullException(nameof(identificator));

        var link = await _linkRepository.Get(x => x.Identificator == identificator);

        if (link is null)
            return string.Empty;

        link.Click();
        await _linkRepository.Update(link);

        return link.Url;
    }

    public async Task<Link> GetLink(string identificator, bool countClick = true)
    {
        if (string.IsNullOrEmpty(identificator))
            throw new ArgumentNullException(nameof(identificator));

        var link = await _linkRepository.Get(x => x.Identificator == identificator);

        if (link is null)
            return null;

        if (countClick)
        {
            link.Click();
            await _linkRepository.Update(link);
        }

        return link;
    }
}
