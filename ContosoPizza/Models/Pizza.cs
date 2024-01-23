using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }

    [Range(0.01, 9999.99)]
    
    
    private decimal price;

    [Range(0.01, 9999.99)]
    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

}

public enum PizzaSize { Small, Medium, Large }