namespace Domain.Exceptions
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(Guid id)
            : base($"The product with ID = ${id} not found")
        {
        }
    }
}
