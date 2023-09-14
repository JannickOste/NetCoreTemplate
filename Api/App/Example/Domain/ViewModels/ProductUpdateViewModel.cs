using App.Core.Domain.Mappers.Entity;
using App.Example.Domain.Models;

namespace App.Example.Infrastructure.ViewModels;

[SetEntityRemapper(mapTo: typeof(Product))]
public class ProductUpdateViewModel 
{
    public string? Name {get; set;}
    public decimal? Price {get; set;}
}