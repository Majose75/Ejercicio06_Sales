using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio06_Sales.Models;

[ModelMetadataType(typeof(ProductMetadata))]
public partial class Product { }
public class ProductMetadata
{
 
    public int ProductID { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; } = null!;
    [Display(Name = "Nº Producto")]
    public string ProductNumber { get; set; } = null!;

    [Display(Name = "Fabricado Internamente")]
    public bool MakeFlag { get; set; }
    [Display(Name = "Fabricado Internamente")]
    public bool FinishedGoodsFlag { get; set; }

    
    public string? Color { get; set; }

    [Display(Name = "Stock")]
    public short SafetyStockLevel { get; set; }


    public short ReorderPoint { get; set; }

    public decimal StandardCost { get; set; }


    public decimal ListPrice { get; set; }


    public string? Size { get; set; }


    public string? SizeUnitMeasureCode { get; set; }


    public string? WeightUnitMeasureCode { get; set; }


    public decimal? Weight { get; set; }


    public int DaysToManufacture { get; set; }


    public string? ProductLine { get; set; }


    public string? Class { get; set; }

 
    public string? Style { get; set; }


    public int? ProductSubcategoryID { get; set; }


    public int? ProductModelID { get; set; }


    public DateTime SellStartDate { get; set; }

 
    public DateTime? SellEndDate { get; set; }

  
    public DateTime? DiscontinuedDate { get; set; }


    public Guid rowguid { get; set; }

 
    public DateTime ModifiedDate { get; set; }
}

