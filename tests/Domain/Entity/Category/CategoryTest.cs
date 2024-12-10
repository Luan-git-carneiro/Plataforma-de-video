namespace Flix.Tests.Domain.Entity.Category;
{
    public class CategoryTest
    {
        [Fact(DisplayName = nameof(Instantiate))]
        [trait("Domain", "Category-Aggregates")]
        public void Instantiate()
        {
            // Arrange
            var validData = new {
                Name = "Category 1",
                Description = "Description 1"
            };

            // Act
            var category = new Category(validData.Name, validData.Description);

            // Assert
            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
        }
    }
}