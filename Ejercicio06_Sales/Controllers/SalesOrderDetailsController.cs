using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejercicio06_Sales.Models;
using Ejercicio06_Sales.ViewModel;

namespace Ejercicio06_Sales.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly AdventureWorks2016Context _context;

        public SalesOrderDetailsController(AdventureWorks2016Context context)
        {
            _context = context;
        }

        // GET: SalesOrderDetails
        public async Task<IActionResult> Index()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            return View(await adventureWorks2016Context.Take(2000).ToListAsync());
        }
        //Ejercicios nuevos
        public async Task<IActionResult> ListadoVentasProductos()
        {
            var resultado = from SalesODetails in _context.SalesOrderDetail.Take(500)
                join Producto in _context.Product
                    on SalesODetails.ProductID equals Producto.ProductID
                select new ListadoVentasProductosViewModel()
                {
                    Id = SalesODetails.ProductID,
                    CodProducto=Producto.ProductID,
                    NombreProducto = Producto.Name,
                    ColorProducto =Producto.Color,
                    CantidadProducto=SalesODetails.OrderQty,
                    PrecioProducto= SalesODetails.UnitPrice,
                    TotalProducto= SalesODetails.LineTotal
                };

            return View(resultado);
        }





        // Todos los listados ordenados por fecha ascendente y por nombre del producto(id)  ModifiedDate
        // Ventas 2011. CarrierTrackingNumber que no acaben en letra. 
        public async Task<IActionResult> IndexListado01()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            string[] numerosAcabar = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var listado01 =
                from texto in adventureWorks2016Context
                where texto.ModifiedDate.Year == 2011 && numerosAcabar.Any(x => texto.CarrierTrackingNumber.EndsWith(x))
                orderby texto.ModifiedDate, texto.ProductID 
                select texto;

            return View(await listado01.ToListAsync());
        }

        // Ventas 2012. Ordenado por Fecha y por ID Producto. Precio por Unidad >150
        public async Task<IActionResult> IndexListado02()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            string[] numerosAcabar = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var listado02 =
                from texto in adventureWorks2016Context
                where texto.ModifiedDate.Year == 2012 && texto.UnitPrice <=150
                orderby texto.ModifiedDate, texto.ProductID
                select texto;

            return View(await listado02.ToListAsync());
        }

        // Ventas 2013. Ordenado por Fecha y por ID Producto. Cantidad >2 y Total >2000
        public async Task<IActionResult> IndexListado03()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
           var listado03 =
                from texto in adventureWorks2016Context
                where texto.ModifiedDate.Year == 2013 && texto.OrderQty >2 && texto.LineTotal > 2000
                orderby texto.ModifiedDate, texto.ProductID
                select texto;

            return View(await listado03.ToListAsync());
        }

        // Ventas 2014. Ordenado por Fecha y por ID Producto. Total >5000 y <9000
        public async Task<IActionResult> IndexListado04()
        {
            var adventureWorks2016Context = _context.SalesOrderDetail.Include(s => s.SalesOrder);
            var listado04 =
                from texto in adventureWorks2016Context
                where texto.ModifiedDate.Year == 2014 && texto.UnitPrice > 500 && (texto.LineTotal < 9000 && texto.LineTotal > 5000)
                orderby texto.ModifiedDate, texto.ProductID
                select texto;

            return View(await listado04.ToListAsync());
        }

        // GET: SalesOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetail
                .Include(s => s.SalesOrder)
                .FirstOrDefaultAsync(m => m.SalesOrderID == id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["SalesOrderID"] = new SelectList(_context.SalesOrderHeader, "SalesOrderID", "SalesOrderID");
            return View();
        }

        // POST: SalesOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid,ModifiedDate")] SalesOrderDetail salesOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesOrderID"] = new SelectList(_context.SalesOrderHeader, "SalesOrderID", "SalesOrderID", salesOrderDetail.SalesOrderID);
            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetail.FindAsync(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }
            ViewData["SalesOrderID"] = new SelectList(_context.SalesOrderHeader, "SalesOrderID", "SalesOrderID", salesOrderDetail.SalesOrderID);
            return View(salesOrderDetail);
        }

        // POST: SalesOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid,ModifiedDate")] SalesOrderDetail salesOrderDetail)
        {
            if (id != salesOrderDetail.SalesOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderDetailExists(salesOrderDetail.SalesOrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesOrderID"] = new SelectList(_context.SalesOrderHeader, "SalesOrderID", "SalesOrderID", salesOrderDetail.SalesOrderID);
            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetail
                .Include(s => s.SalesOrder)
                .FirstOrDefaultAsync(m => m.SalesOrderID == id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return View(salesOrderDetail);
        }

        // POST: SalesOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderDetail = await _context.SalesOrderDetail.FindAsync(id);
            if (salesOrderDetail != null)
            {
                _context.SalesOrderDetail.Remove(salesOrderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderDetailExists(int id)
        {
            return _context.SalesOrderDetail.Any(e => e.SalesOrderID == id);
        }
    }
}
