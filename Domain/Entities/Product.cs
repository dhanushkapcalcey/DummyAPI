namespace Domain.Entities
{
    public class Product
    {
        public Product(string name, float price, string imageUrl, int quantity)
        {
            Id = new Guid();
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }


        //public Product CreateProduct(string name, float price, string imageUrl, int quantity) 
        //{
        //    var product = new Product();
        //    product.Id = Guid.NewGuid();
        //    product.Name = name;
        //    product.Price = price;
        //    product.ImageUrl = imageUrl;
        //    product.Quantity = quantity;
        //    return product;
        //}
    }
}
