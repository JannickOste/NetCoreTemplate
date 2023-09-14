using App.Core.Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Example.Domain.Models;

[PrimaryKey(nameof(Id))]
[DbEntity(typeof(Product))]
public class Product : IProduct
{
    public int Id {get; set;}
    public string Name {get; set;} = String.Empty;
    public decimal Price {get; set;} = 0.0M;
}