using Capa_Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Consola.Listas
{
    public class ListaCategoria
    {
        public static void Desplegar(ArrayList Acategoria)
        {

            int fila = 11;
            int colum = 77;
            string encabezadotabla = "ID       |Nombre Categoria";
            string titulotabla = "LISTA DE CATEGORIAS";
            Sistema_Facturacion_Consola.Program.Limpiar(4, 80, 29, 29);
            Console.SetCursorPosition(((encabezadotabla.Length - titulotabla.Length) / 2) + 4+colum, fila - 3); Console.Write(titulotabla);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4+colum, fila - 1); Console.Write(encabezadotabla);

            Console.ResetColor();
            foreach (Categoria p in Acategoria)
            {
                Console.SetCursorPosition(colum+4, fila); Console.Write(p.getID());
                Console.SetCursorPosition(colum+14, fila); Console.Write(p.getNombre());
                fila++;

            }
        }
    }
}
