using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Sistema_Facturacion_Consola;

namespace Sistema_Facturacion_Consola.Listas
{
    public class ListaProducto
    {
        public static string NombreCatID(ArrayList acat, int id)
        {
            return Sistema_Facturacion_Consola.Program.NombreCatID(acat,id);
        }
        public static void Desplegar(ArrayList Aproducto, ArrayList Acategoria)
        {
            
            int fila = 32;
            string encabezadotabla = "ID       |Nombre Producto | Categoria | Precio   | Existencias ";
            string titulotabla = "LISTA DE PRODUCTOS";
            Sistema_Facturacion_Consola.Program.Limpiar(4,80,fila-3,fila-3);
            Console.SetCursorPosition(((encabezadotabla.Length - titulotabla.Length) / 2)+4, fila - 3); Console.Write(titulotabla);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4, fila - 1); Console.Write(encabezadotabla);

            Console.ResetColor();
            foreach (Producto p in Aproducto)
            {
                Console.SetCursorPosition(4, fila); Console.Write(p.getIDProducto());
                Console.SetCursorPosition(14, fila); Console.Write(p.getNombre());
                Console.SetCursorPosition(31, fila); Console.Write(NombreCatID(Acategoria, p.getIDCategoria()));
                Console.SetCursorPosition(44, fila); Console.Write(p.getPrecio().ToString("###,###,###.00").PadLeft(9));
                Console.SetCursorPosition(56 + ((9 - p.getExistencias().ToString("###,###,##0").Length)/2), fila); Console.Write(p.getExistencias().ToString("###,###,##0"));
                fila++;

            }
        }
    }
}
