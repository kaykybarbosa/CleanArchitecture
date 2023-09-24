using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            Id = id;
            
            ValidationDomain(name, description, price, stock, image);
        }
        
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }
     
        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Too short, minimum 3 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description. Too short, minimum 5 characters.");
            DomainExceptionValidation.When(price < 0, "Invalid price value.");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image. Too long, maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
    }
}