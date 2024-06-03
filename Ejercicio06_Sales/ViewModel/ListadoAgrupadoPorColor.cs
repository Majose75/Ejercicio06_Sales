using Ejercicio06_Sales.Models;

namespace Ejercicio06_Sales.ViewModel
{
    public class ListadoAgrupadoPorColor
    {
        public int Id { get; set; }
        public string Color {get;set;}
        public List<ListadoVentasProductosViewModel> ListaVentasporColor { set; get; }
    }
}
