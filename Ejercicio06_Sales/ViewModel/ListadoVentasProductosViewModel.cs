using System.ComponentModel.DataAnnotations;

namespace Ejercicio06_Sales.ViewModel
{
    public class ListadoVentasProductosViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Producto")]
        public string NombreProducto { get; set; }
        [Display(Name = "Color")]
        public string ColorProducto { get; set; }
        [Display(Name = "Código")]
        public int CodProducto { get; set; }
        [Display(Name = "Cantidad")]
        public int CantidadProducto { get; set; }
        [Display(Name = "Precio")]
        public decimal PrecioProducto { get; set; }
        [Display(Name = "Total")]
        public decimal TotalProducto { get; set; }


    }
}
