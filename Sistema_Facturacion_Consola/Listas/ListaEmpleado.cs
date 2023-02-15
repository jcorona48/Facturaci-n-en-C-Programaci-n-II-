using Capa_Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Consola.Listas
{
    public class ListaEmpleado
    {
        public static string ObtenerSexo(ArrayList Aempleado, int ID)
        {
            foreach (Empleado emp in Aempleado)
            {
                if(emp.getID() == ID)
                {
                    if(emp.getSexo().ToUpper() == "M")
                    {
                        return "Masculino";
                    }
                    else
                        return "Femenino";
                }
            }
            return "No definido";
        }
        public static void Desplegar(ArrayList Aempleado)
        {

            int fila = 32;
            string encabezadotabla = "ID       |Nombre Empleado | Cargo     |Sexo       ";
            string titulotabla = "LISTA DE EMPLEADOS";
            Sistema_Facturacion_Consola.Program.Limpiar(4, 80, fila - 3, fila - 3);
            Console.SetCursorPosition(((encabezadotabla.Length - titulotabla.Length) / 2) + 4, fila - 3); Console.Write(titulotabla);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4, fila - 1); Console.Write(encabezadotabla);

            Console.ResetColor();
            foreach (Empleado p in Aempleado)
            {
                Console.SetCursorPosition(4, fila); Console.Write(p.getID());
                Console.SetCursorPosition(14, fila); Console.Write(p.getNombre());
                Console.SetCursorPosition(31, fila); Console.Write(p.getOcupacion());
                Console.SetCursorPosition(44 + ((9 - ObtenerSexo(Aempleado,p.getID()).Length) / 2), fila); Console.Write(ObtenerSexo(Aempleado,p.getID()));
                fila++;

            }
        }
    }
}
