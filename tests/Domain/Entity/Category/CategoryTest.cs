using System;
using FlixCatalogDomain.Exceptions;
using DomainCategory = FlixCatalogDomain.Entity.Category;


namespace Flix.Tests.Domain.Entity.Category
{
    public class CategoryTest
    {
        [Fact(DisplayName = nameof(Instantiate))]
        [Trait("Domain", "Category-Aggregates")]
        public void Instantiate()
        {
            // Arrange
            var validData = new {
                Name = "Category 1",
                Description = "Description 1"
            };

            // Act

            var datetimeBefore = DateTime.Now;

            var category = new DomainCategory(validData.Name, validData.Description);

            var datetimeAfter = DateTime.Now;

            // Assert
            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(default(Guid), category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(datetimeBefore < category.CreatedAt);
            Assert.True(datetimeAfter > category.CreatedAt);
            Assert.True(category.IsActive);
        }



        [Theory(DisplayName = nameof(InstantiateWithIsActive))]
        [Trait("Domain", "Category-Aggregates")]
        [InlineData(true)]
        [InlineData(false)]
         public void InstantiateWithIsActive(bool isActive)
        {
            // Arrange
            var validData = new {
                Name = "Category 1",
                Description = "Description 1"
            };

            // Act

            var datetimeBefore = DateTime.Now;

            var category = new DomainCategory(validData.Name, validData.Description, isActive);

            var datetimeAfter = DateTime.Now;

            // Assert
            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(default(Guid), category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(datetimeBefore < category.CreatedAt);
            Assert.True(datetimeAfter > category.CreatedAt);
            Assert.Equal(isActive, category.IsActive);
        }

        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsEmpty))]
        [Trait("Domain", "Category-Aggregates")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void InstantiateErrorWhenNameIsEmpty(string? name)
        {
            Action action = () => new DomainCategory(name!, "Description 1");

            var exception =  Assert.Throws<EntityValidationArgumentException>(action);

            Assert.Equal("Name should not be empty or null", exception.Message);

        }

        [Fact(DisplayName = nameof(InstantiateErrorWhenDescriptionIsNotNull))]
        [Trait("Domain", "Category-Aggregates")]
        public void InstantiateErrorWhenDescriptionIsNotNull()
        {
            Action action = () => new DomainCategory("Category Name", null!);

            var exception =  Assert.Throws<EntityValidationArgumentException>(action);

            Assert.Equal("Description should not be empty or null", exception.Message);

        }

        //nome deve ter no minimo 3 caracteres
        [Theory(DisplayName = nameof(InstantiateErrorWhenNameHasLessThan3Characters))]
        [Trait("Domain", "Category-Aggregates")]
        [InlineData("a")]
        [InlineData("ab")]
        [InlineData("1")]
        public void InstantiateErrorWhenNameHasLessThan3Characters(string invalidName)
        {
            Action action = () => new DomainCategory(invalidName, "Category ok description");

            var exception =  Assert.Throws<EntityValidationArgumentException>(action);

            Assert.Equal("Name should have at least 3 characters long", exception.Message);

        }
        //nome deve ter no maximo 245 caracteres
        //descrição no maximo 10_00 caracteres

    }
}