using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio06_Sales.Models;

[ModelMetadataType(typeof(SalesOrderDetailMetadata))]
public partial class SalesOrderDetail { }
public  class SalesOrderDetailMetadata
{
    [Display(Name = "ID Orden")]
    public int SalesOrderID { get; set; }

    [Display(Name = "ID Orden Detalle Venta")]
    public int SalesOrderDetailID { get; set; }

    [Display(Name = "Nº Seguimiento")]
    public string? CarrierTrackingNumber { get; set; }

    [Display(Name = "Cantidad")]
    public short OrderQty { get; set; }

    [Display(Name = "ID Producto")]
    public int ProductID { get; set; }


    public int SpecialOfferID { get; set; }

    [Display(Name = "Precio Unidad")]
    [DataType(DataType.Currency)]
    public decimal UnitPrice { get; set; }

    [Display(Name = "Descuento Unidad")]

    public decimal UnitPriceDiscount { get; set; }

    [Display(Name = "Total")]
    [DataType(DataType.Currency)]
    public decimal LineTotal { get; set; }

  
    public Guid rowguid { get; set; }

    [Display(Name = "Fecha Modificación")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
    public DateTime ModifiedDate { get; set; }
    [Display(Name = "Nº Orden")]
    public virtual SalesOrderHeader SalesOrder { get; set; } = null!;
}

