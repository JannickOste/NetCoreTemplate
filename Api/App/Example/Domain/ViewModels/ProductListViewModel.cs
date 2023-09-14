using System.ComponentModel.DataAnnotations;
using App.Example.Domain.Models;

namespace App.Example.Infrastructure.ViewModels;

public class ProductListViewModel 
{
    public IEnumerable<Product> Products {get; set;}
}