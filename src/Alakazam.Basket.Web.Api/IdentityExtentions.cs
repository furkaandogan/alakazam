namespace Alakazam.Basket.Web.Api
{
    public static class IdentityExtentions
    {
        public static Domain.Customer ToCustomer(this Identity identity)
        {
            return new Domain.Customer(identity.Id);
        }
    }
}