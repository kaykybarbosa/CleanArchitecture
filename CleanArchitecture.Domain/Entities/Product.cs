namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product
    {
        public int Id{ get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stoke { get; private set; }
        public string ImageUri { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}