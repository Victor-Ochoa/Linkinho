using Linkinho.Domain.Core.Base;

namespace Linkinho.Domain.Entities;

public class Link : Entity
{
    public Link(): base() {}
    public Link(string url) : base()
    {
        Url = url;
    }

    public string Identificator { get; private set; } = Guid.NewGuid().ToString().Replace("-", "").Remove(6);
    public string Url { get; private set; } = string.Empty;
    public DateTime CreateAt { get; private set; } = DateTime.Now;
    public int CountClick { get; private set; } = 0;


    public void Click()
    {
        CountClick++;
    }
}
