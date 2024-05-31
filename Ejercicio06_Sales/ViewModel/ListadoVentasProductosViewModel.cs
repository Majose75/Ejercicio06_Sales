using System.ComponentModel.DataAnnotations;

namespace Ejercicio06_Sales.ViewModel
{
    public class ListadoVentasProductosViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Producto")]
        public string NombreProducto { get; set; }
        public string ColorProducto { get; set; }
        public int CodProducto { get; set; }
        public int CantidadProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public decimal TotalProducto { get; set; }


    }
}
