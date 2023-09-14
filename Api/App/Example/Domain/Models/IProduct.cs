namespace App.Example.Domain.Models;

public interface IProduct
{
    public int Id {get; set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
}