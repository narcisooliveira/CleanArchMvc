using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTests
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () =>
        {
            Category category = new(1, "Category Name");
        };
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Short Name Value")]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () =>
        {
            Category category = new(1, "Ca");
        };
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Category With Negative Id Value")]
    public void CreateCategory_NegativeIdValue_DomainExceptionNegativeIdValue()
    {
        Action action = () =>
        {
            Category category = new(-1, "Category Name");
        };
        action.Should()
            .Throw<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Missing Name Value")]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () =>
        {
            Category category = new(1, string.Empty);
        };
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.Name is required");
    }

    [Fact(DisplayName = "Create Category With Null Name Value")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () =>
        {
            Category category = new(1, string.Empty);
        };
        action.Should()
            .Throw<DomainExceptionValidation>();
    }
}