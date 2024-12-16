using FlixCatalogDomain.Exceptions;

namespace FlixCatalogDomain.Entity
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Boolean IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
         public Category(string name, string description, bool isActive = true)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = isActive;
            CreatedAt = DateTime.Now;

            Validate();
        }

        public void Validate()
        {
            if(String.IsNullOrWhiteSpace(Name))
            {
                throw new EntityValidationArgumentException($"{nameof(Name)} should not be empty or null");
            };
            if(Description == null)
            {
                throw new EntityValidationArgumentException($"{nameof(Description)} should not be empty or null");
            };
            if(Name.Length < 3)
            {
                throw new EntityValidationArgumentException($"{nameof(Name)} should have at least 3 characters long");
            };
        }

    }

}