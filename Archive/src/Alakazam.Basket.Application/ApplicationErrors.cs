using System.Diagnostics.CodeAnalysis;
using System.Net;
using Alakazam.Basket.Domain;

namespace Alakazam.Basket.Application
{
    [ExcludeFromCodeCoverage]
    public class ApplicationErrors
    {
        public static DomainException ProductCanNotBeFetch;

        static ApplicationErrors()
        {
            ProductCanNotBeFetch = new DomainException("ProductCanNotBeFetch", "<doc-link>", HttpStatusCode.PreconditionFailed);
        }
    }
}