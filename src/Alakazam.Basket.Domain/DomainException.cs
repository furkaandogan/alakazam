using System.Net;

namespace Alakazam.Basket.Domain
{
    public sealed class DomainException
        : System.Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public DomainException(string message, string helpLink, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            HelpLink = helpLink;
            StatusCode = statusCode;
        }

    }
}