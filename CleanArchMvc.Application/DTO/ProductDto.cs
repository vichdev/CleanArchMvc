using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTO;

public class ProductDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The name is required")]
    [MinLength(3, ErrorMessage = "The name must be at least 3 characters long")]
    [MaxLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The description is required")]
    [MinLength(5, ErrorMessage = "The description must be at least 5 characters long")]
    [MaxLength(200, ErrorMessage = "The description cannot be longer than 200 characters")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "The price is required")]
    [Column(TypeName = "decimal(18, 2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "The stock is required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }
    
    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string? Image { get; set; }

    [DisplayName("Category")]
    public int CategoryId { get; set; }
    
    public Category? Category { get; set; }
}