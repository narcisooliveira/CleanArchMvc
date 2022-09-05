using Xunit;

namespace CleanArchMvc.Domain.Tests.ProductUnitTest1
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_resultObjectValidState()
        {
            Action action = () => new Product(1)
        }
    }
}