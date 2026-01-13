using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTests
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () =>
        {
            Product product = new(1, "Product Name", "Product Description", 9.99m,99, "product image");
        };
        action.Should()
            .NotThrow<DomainExceptionValidation>();             
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () =>
        {
            Product product = new(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
        };
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () =>
        {
            Product product = new(1, "Pr", "Product Description", 9.99m, 99, "product image");
        };
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact]
    public void CreateProduct_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () =>
        {
            Product product = new(1, "Product name", "Product Description", 9.99m, 
                99, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooggggggggggggggggggggggg name");
        };
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 100 characters");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_DomainExceptionWithNullImageName()
    {
        Action action = () =>
        {
            Product product = new(1, "Product name", "Product Description", 9.99m, 99, string.Empty);
        };
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithNullImageName_DomainExceptionWithNullImageNameNoNullReferenceException()
    {
        Action action = () =>
        {
            Product product = new(1, "Product name", "Product Description", 9.99m, 99, string.Empty);
        };
        action.Should().NotThrow<NullReferenceException>();
    }

    [Fact]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
        Action action = () =>
        {
            Product product = new(1, "Product name", "Product Description", 9.99m, 99, string.Empty);
        };
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_InvalidPriceValue_NoDomainException()
    {
        Action action = () =>
        {
            Product product = new(1, "Product name", "Product Description", -9.99m, 99, "Product Image");
        };
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_NoDomainExceptionInvalidStockValue(int value)
    {
        Action action = () =>
        {
            Product product = new(1, "Pro", "Product Description", 9.99m, value, "product image");
        };
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}
