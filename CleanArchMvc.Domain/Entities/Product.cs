using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : EntityBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string? image)
    {
        Validate(name, description, price, stock, image);
   
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public Product(int id, string name, string description, decimal price, int stock, string? image)
    {
        DomainExceptionValidation.When(id <= 0, "Invalid Id value");
        Validate(name, description, price, stock, image);
        
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public void Update(string name, string description, decimal price, int stock, string? image, int categoryId)
    {
        Validate(name, description, price, stock, image);
        
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
    }

    private void Validate(string name, string description, decimal price, int stock, string? image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid product name.");

        DomainExceptionValidation.When(name.Length < 3,
            "Name must be at least 3 characters long.");
        
        DomainExceptionValidation.When(description.Length < 5, 
            "Invalid product description.");
        
        DomainExceptionValidation.When(price < 0, 
            "Invalid product price.");
        
        DomainExceptionValidation.When(stock < 0, 
            "Invalid stock.");
        
        DomainExceptionValidation.When(image?.Length > 250, 
            "Invalid image name, too long, maximum 250 characters.");
    }
}