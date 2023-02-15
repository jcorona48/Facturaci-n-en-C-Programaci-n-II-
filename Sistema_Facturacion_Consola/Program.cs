using Capa_Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion_Consola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int menuopcion;
            ArrayList ACategoria = new ArrayList();
            ArrayList Aproducto = new ArrayList();
            ArrayList Aempleado = new ArrayList();
            Aempleado.Add(new Empleado(1, "Joan Corona", 19, "Administrador", "M", "4886", "jcorona"));
            Aempleado.Add(new Empleado(2, "Milko Ortiz", 20, "Administrador", "M", "4566", "mortiz"));
            Aempleado.Add(new Empleado(3, "Capellan", 42, "Administrador", "M", "admin", "admin"));
            Aempleado.Add(new Empleado(4, "Wander Jerez", 19, "Administrador", "M", "1234", "wanderj"));
            Aempleado.Add(new Empleado(5, "Esteban Pacheco", 19, "Administrador", "M", "1811", "pesteban"));
            ArrayList AFactura_Detalle = new ArrayList();
            ArrayList AFactura_Encabezado = new ArrayList();

            ConsoleKeyInfo salir;
            do
            {
                Empleado sesion = Login(Aempleado);
                do
                {
                    Console.Clear();
                    Cuadro(1, 80, 1, 6);
                    Titulos("M e n u   P r i n c i p a l");
                    Menu(sesion);
                    menuopcion = MenuChoice();
                    DoChoice(menuopcion, Aproducto, ACategoria, AFactura_Detalle, AFactura_Encabezado, Aempleado, sesion);
                    if (menuopcion != 0)
                        Console.ReadKey();
                } while (menuopcion != 0);
                Console.SetCursorPosition(15, 23); Console.Write("Presiones ESC para salir del programa, otro para ir al login.");
                salir = Console.ReadKey();
            } while (salir.Key != ConsoleKey.Escape);
        }
        public static Empleado Login(ArrayList Aempleado)
        {
            string usuario = "", pass = "";
            Empleado sesion = new Empleado();
            bool NoEncontrado = true;
            do
            {  
                Console.Clear();
                Cuadro(5, 80, 4, 16);
                string title = "*** LOGIN ***";
                Console.SetCursorPosition((4 + (80-title.Length) / 2), 7); Console.Write(title);
                Console.SetCursorPosition(15, 10); Console.Write("Ingrese el nombre de usuario......: ");
                Console.SetCursorPosition(15, 13); Console.Write("Ingrese la contraseña de usuario..: ");
                Console.SetCursorPosition(51, 10);  usuario = Console.ReadLine();
                Console.SetCursorPosition(51, 13);  pass = Console.ReadLine();

                if (Uencontrado(usuario, pass, Aempleado))
                {
                    sesion = BuscarEmpleado(usuario, pass, Aempleado);
                    NoEncontrado= false;
                }
                else
                {
                    Console.SetCursorPosition(15, 20); Console.WriteLine("Usuario o Contraseña incorrecta");
                    Console.SetCursorPosition(15, 23); Console.Write("Presiones ESC para salir del programa, otro intentar nuevamente.");
                    ConsoleKeyInfo salir = Console.ReadKey();
                    if (salir.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }
            } while (NoEncontrado);
            return sesion;
        }
        public static bool Uencontrado(string user, string pass, ArrayList Aempleado)
        {
            bool encontrado = false;

            foreach (Empleado em in Aempleado)
            {
                if (user == em.getUser() && pass == em.getPass())
                {
                    encontrado = true;
                    break;
                }
            }
            return encontrado;
        }
        public static Empleado BuscarEmpleado(string user, string pass, ArrayList Aempleado)
        {
            Empleado emp = new Empleado();
            foreach (Empleado em in Aempleado)
            {
                if (user == em.getUser() && pass == em.getPass())
                {
                    emp = em;
                    return emp;
                }
            }
            return emp;
        }
        public static Empleado BuscarEmpleadoID(int ID, ArrayList Aempleado)
        {
            Empleado emp = new Empleado();
            foreach (Empleado em in Aempleado)
            {
                if (ID == em.getID())
                {
                    emp = em;
                    return emp;
                }
            }
            return emp;
        }
        public static void Cuadro(int x1, int x2, int y1, int y2)
        {
            for (int x = x1; x <= x2; x++)
            {
                Console.SetCursorPosition(x, y1); Console.Write("═");
                Console.SetCursorPosition(x, y2); Console.Write("═");
            }

            for (int y = y1; y <= y2; y++)
            {
                Console.SetCursorPosition(x1, y); Console.Write("║");
                Console.SetCursorPosition(x2, y); Console.Write("║");
            }
            Console.SetCursorPosition(x1, y1); Console.Write("╔");
            Console.SetCursorPosition(x2, y1); Console.Write("╗");
            Console.SetCursorPosition(x1, y2); Console.Write("╚");
            Console.SetCursorPosition(x2, y2); Console.Write("╝");
        }
        public static void Titulos(string texto)
        {
            string t1 = "Milko Company",
                t2 = "El placer del buen servicio",
                t3 = "Sistema de Inventario",
                t4 = texto;
            Console.SetCursorPosition((80 - t1.Length) / 2, 2); Console.Write(t1);
            Console.SetCursorPosition((80 - t2.Length) / 2, 3); Console.Write(t2);
            Console.SetCursorPosition((80 - t3.Length) / 2, 4); Console.Write(t3);
            Console.SetCursorPosition((80 - t4.Length) / 2, 5); Console.Write(t4);

        }
        public static void Titulosconsulta()
        {
            string t1 = "Milko Company",
                t2 = "El placer del buen servicio",
                t3 = "Sistema de Inventario",
                t4 = "M e n u   Consultas";
            Console.SetCursorPosition((120 - t1.Length) / 2, 2); Console.Write(t1);
            Console.SetCursorPosition((120 - t2.Length) / 2, 3); Console.Write(t2);
            Console.SetCursorPosition((120 - t3.Length) / 2, 4); Console.Write(t3);
            Console.SetCursorPosition((120 - t4.Length) / 2, 5); Console.Write(t4);
        }
        public static void Menu(Empleado emp)
        {
            Console.SetCursorPosition(15, 8); Console.Write("1 - Registrar Categoria de Productos");
            Console.SetCursorPosition(15, 9); Console.Write("2 - Registrar Productos");
            Console.SetCursorPosition(15, 10); Console.Write("3 - Aumentar Inventario");
            Console.SetCursorPosition(15, 11); Console.Write("4 - Reducir Inventario");
            Console.SetCursorPosition(15, 12); Console.Write("5 - Consultar Inventario");
            Console.SetCursorPosition(15, 13); Console.Write("6 - Registrar Empleado");
            Console.SetCursorPosition(15, 14); Console.Write("7 - Registrar Venta");
            Console.SetCursorPosition(15, 15); Console.Write("8 - Consultar Ventas");
            Console.SetCursorPosition(15, 16); Console.Write("9 - Buscar Factura");
            Console.SetCursorPosition(15, 17); Console.Write("0 - Salir");
            string saludos = "Bienvenido " + emp.getOcupacion() + ":";

            Cuadro(63, 76+saludos.Length, 10, 16);
            Console.SetCursorPosition(70, 12); Console.Write(saludos);
            Console.SetCursorPosition((70 + (saludos.Length - emp.getNombre().Length) / 2), 14); Console.Write(emp.getNombre());

        }
        public static void Filtrosmenu()
        {

            Console.SetCursorPosition(15, 8); Console.Write("1 - Historico de venta");
            Console.SetCursorPosition(15, 9); Console.Write("2 - Reporte por Empleado");
            Console.SetCursorPosition(15, 10); Console.Write("3 - Reporte por Fecha");
            Console.SetCursorPosition(15, 11); Console.Write("4 - Reporte por Cliente");
            Console.SetCursorPosition(15, 12); Console.Write("5 - Top Productos mas vendidos");
            Console.SetCursorPosition(15, 13); Console.Write("0 - Salir");

        }
        public static int MenuChoice()
        {
            int op = -1;
            do
            {
                try
                {
                    Console.SetCursorPosition(15, 20); Console.Write("Su opcion...: ");
                    op = ReadInt(false);
                    if (op < 0 || op > 9)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Ha elegido una opcion no válida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(ex.Message);
                }

            } while (op < 0 || op > 9);
            return op;
        }
        public static void Limpiar(int x1, int x2, int y1, int y2)
        {
            for (int x = x1; x <= x2; x++)
                for (int y = y1; y <= y2; y++)
                {
                    Console.SetCursorPosition(x, y); Console.Write(" ");
                }
        }
        public static int LastIDP(ArrayList Array)
        {
            int id = 0;
            foreach (Producto p in Array)
            {
                id = p.getIDProducto();
            }
            return id + 1;
        }
        public static int LastIDE(ArrayList Array)
        {
            int id = 0;
            foreach (Empleado p in Array)
            {
                id = p.getID();
            }
            return id + 1;
        }
        public static void ModificarStock(ArrayList array, int id, int newstock, bool aumentar)
        {
            foreach (Producto p in array)
            {
                if (p.getIDProducto() == id)
                {
                    if (p.getEstado())
                    {
                        if (!aumentar)
                        {
                            if (newstock <= 0)
                            {
                                Console.SetCursorPosition(20, 24); Console.Write("No se permite numeros menores a uno (1). ");
                                return;
                            }
                            if ((p.getExistencias() - newstock) < 0)
                            {
                                Console.SetCursorPosition(20, 24); Console.Write("Esta modificacion dejaria el stock negativo. ");
                                return;
                            }

                            p.setExistencias(p.getExistencias() - newstock);
                            if (p.getExistencias() == 0)
                                p.setActivo(false);
                            Console.SetCursorPosition(20, 24); Console.Write("El stock se ha modificado correctamente. ");
                            return;
                        }
                        else
                        {
                            if (newstock <= 0)
                            {
                                Console.SetCursorPosition(20, 24); Console.Write("No se permite numeros menores a uno (1). ");
                                return;
                            }

                            p.setExistencias(p.getExistencias() + newstock);
                            Console.SetCursorPosition(20, 24); Console.Write("El stock se ha modificado correctamente. ");
                            return;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("El producto se encuentra inactivo. ");
                    }

                }

            }
        }
        public static int LastIDC(ArrayList Array)
        {
            int id = 0;
            foreach (Categoria c in Array)
            {
                id = c.getID();
            }
            return id + 1;
        }
        public static int LastIDV(ArrayList Array)
        {
            int id = 0;
            foreach (Factura_Encabezado FE in Array)
            {
                id = FE.getID();
            }
            return id + 1;
        }
        public static string NombreCatID(ArrayList acat, int id)
        {
            string nombre = "Nulo";
            foreach (Categoria c in acat)
            {
                if (c.getID() == id)
                    nombre = c.getNombre();
            }
            return nombre;
        }
        public static bool FindP(int ID, ArrayList array, bool Producto = true)
        {
            bool encontrado = false;
            if (Producto)
                foreach (Producto p in array)
                {
                    if (p.getIDProducto() == ID)
                    {
                        encontrado = true;
                        return encontrado;
                    }
                }
            else
                foreach (Categoria c in array)
                {
                    if (c.getID() == ID)
                    {
                        encontrado = true;
                        return encontrado;
                    }
                }

            return encontrado;
        }
        public static Producto BuscarProducto(int ID, ArrayList array)
        {
            Producto producto = new Producto();
            foreach (Producto p in array)
            {
                if (p.getIDProducto() == ID)
                {
                    producto = p;
                }

            }
            return producto;
        }
        public static void RegistrarCategoria(ArrayList acategoria)
        {
            int cid;
            bool activo = true;
            int pid = 0, stock = 0;
            string repetir = "";
            string nombre = "";
            string cdescrip = "";
            do
            {
                Console.Clear();
                Cuadro(1, 80, 1, 6);
                Titulos("M e n u   P r i n c i p a l");
                cdescrip = "";
                nombre = "";
                repetir = "";
                activo = true;
                cid = LastIDC(acategoria);
                Console.SetCursorPosition(28, 08); Console.Write("REGISTRO DE CATEGORIA");
                Console.SetCursorPosition(20, 10); Console.Write("ID Categoria...: " + Convert.ToString(cid));
                Console.SetCursorPosition(20, 11); Console.Write("Nombre.........: ");
                nombre = Console.ReadLine();
                Console.SetCursorPosition(20, 12); Console.Write("Descripcion....: ");
                cdescrip = Console.ReadLine();

                acategoria.Add(new Categoria(cid, nombre, cdescrip));
                Console.SetCursorPosition(20, 24); Console.Write("Categoria Registrada Satisfactoriamente ");
                Console.SetCursorPosition(20, 26); Console.Write("Desea Ingresar otra Categoria? Si(1) No(Otro): ");
                repetir = Console.ReadLine();
            } while (repetir == "1");
        }
        public static void RegistrarProducto(ArrayList aproducto, ArrayList acategoria)
        {
            int cid;
            bool activo = true;
            int pid = 0, stock = 0;
            string repetir = "";
            string nombre = "";
            string cdescrip = "";
            do
            {
                Console.Clear();
                Cuadro(1, 80, 1, 6);
                Titulos("M e n u   P r i n c i p a l");
                cid = 0;
                repetir = "";
                pid = LastIDP(aproducto);
                stock = 0;
                double pprecio = 0;
                nombre = "";
                activo = true;
                Console.SetCursorPosition(28, 08); Console.Write("REGISTRO DE PRODUCTO");
                Console.SetCursorPosition(20, 10); Console.Write("ID Producto...: " + Convert.ToString(pid));

                Console.SetCursorPosition(4, 29); Console.Write("Ver lista de categorias (-1) ");
                do
                {
                    Console.SetCursorPosition(20, 11); Console.Write("ID Categoria..: ");
                    try
                    {
                        cid = Convert.ToInt32(Console.ReadLine());
                        if (cid == -1)
                        {
                            Listas.ListaCategoria.Desplegar(acategoria);
                            Limpiar(17, 50, 11, 11);
                            continue;
                        }
                        Limpiar(4, 80, 29, 29);
                        if (!FindP(cid, acategoria, false))
                        {
                            Console.SetCursorPosition(20, 24); Console.Write("No se encuentra Categoria");

                            Console.ReadKey();
                            Limpiar(20, 80, 24, 24);
                            Limpiar(36, 80, 11, 11);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Ingrese el codigo de la categoria");
                        Console.ReadKey();
                        Limpiar(20, 80, 24, 24);
                        Limpiar(36, 80, 11, 11);
                        continue;
                    }

                } while (!FindP(cid, acategoria, false));
                Console.SetCursorPosition(48, 11); Console.Write("Nombre Categoria.: " + NombreCatID(acategoria, cid));
                Console.SetCursorPosition(20, 12); Console.Write("Nombre........: ");
                nombre = Console.ReadLine().ToString();
                Console.SetCursorPosition(20, 13); Console.Write("Precio........: ");
                pprecio = ReadDouble();
                Console.SetCursorPosition(20, 14); Console.Write("Existencias...: ");
                stock = ReadInt();

                aproducto.Add(new Producto(pid, cid, stock, nombre, pprecio));
                Console.SetCursorPosition(20, 24); Console.Write("Producto Registrado Satisfactoriamente ");
                if (repetir == "1") { continue; }
                Console.SetCursorPosition(20, 26); Console.Write("Desea Ingresar otro Producto? Si(1) No(Otro) ");
                repetir = Console.ReadLine();
            } while (repetir == "1");
        }
        public static void DoChoice(int opcion, ArrayList aproducto, ArrayList acategoria, ArrayList afactura_detalle, ArrayList afactura_encabezado, ArrayList Aempleado, Empleado emp)
        {
            int cid;
            bool activo = true;
            int pid = 0, stock = 0;
            string repetir = "";
            string nombre = "";
            string cdescrip = "";
            switch (opcion)
            {
                case 1:
                    RegistrarCategoria(acategoria);

                    break;
                case 2:
                    if (acategoria.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, ingrese al menos una categoria");
                        break;
                    }
                    RegistrarProducto(aproducto,acategoria);
                    break;

                case 3:
                    if (aproducto.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, ingrese al menos un producto");
                        break;
                    }
                    ModStockS(repetir, pid, aproducto, acategoria, stock);

                    break;

                case 4:
                    if (aproducto.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, ingrese al menos un producto");
                        break;
                    }
                    ModStockR(repetir, pid, aproducto, acategoria, stock);
                    break;
                case 5:
                    if (aproducto.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, ingrese al menos un producto");
                        break;
                    }
                    Console.Clear();
                    Titulos("M e n u   P r i n c i p a l");
                    ConsultarInventario(aproducto, acategoria);
                    break;

                case 6:
                    RegistrarEmpleado(Aempleado);
                    break;
                case 7:
                    if (aproducto.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, ingrese al menos un producto");
                        break;
                    }
                    RegistrarVenta(afactura_encabezado, aproducto, acategoria, emp, afactura_detalle);
                    break;

                case 8:
                    if (afactura_detalle.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, realice al menos una venta");
                        break;
                    }
                    OpcionConsultar(afactura_encabezado, Aempleado, afactura_detalle, aproducto, acategoria);
                    break;
                case 9:
                    if (afactura_detalle.Count <= 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Antes, realice al menos una venta");
                        break;
                    }
                    Verfactura(afactura_encabezado, afactura_detalle, Aempleado, aproducto, acategoria);
                    break;
            }
        }
        public static void ModStockR(string repetir, int pid, ArrayList aproducto, ArrayList acategoria, int stock)
        {
            do
            {
                if (repetir != "1")
                {
                    Console.Clear();
                    Cuadro(1, 80, 1, 6);
                    Titulos("M e n u   P r i n c i p a l");
                    Console.SetCursorPosition(4, 29); Console.Write("Ver lista de productos (-1) ");
                }
                repetir = "1";
                Limpiar(1, 79, 8, 20);
                Console.SetCursorPosition(28, 08); Console.Write("DISMINUIR INVENTARIO");

                Console.SetCursorPosition(20, 10); Console.Write("ID Producto....: ");
                pid = ReadInt();
                if (pid == -1)
                {
                    Listas.ListaProducto.Desplegar(aproducto, acategoria);

                    Limpiar(37, 80, 10, 10);
                    continue;
                }
                if (FindP(pid, aproducto))
                {
                    Producto p = BuscarProducto(pid, aproducto);
                    Console.SetCursorPosition(20, 11); Console.Write("ID Categoria...: " + NombreCatID(acategoria, p.getIDProducto()));
                    Console.SetCursorPosition(20, 12); Console.Write("Nombre.........: " + p.getNombre());
                    Console.SetCursorPosition(20, 13); Console.Write("Precio.........: " + p.getPrecio());
                    Console.SetCursorPosition(20, 14); Console.Write("Existencias....: " + p.getExistencias());

                    Console.SetCursorPosition(20, 16); Console.Write("Disminuir stock: ");
                    stock = ReadInt();

                    ModificarStock(aproducto, pid, stock, false);
                    repetir = "";
                }
                else
                {
                    Console.SetCursorPosition(20, 24); Console.Write("Producto no se encuentra en el inventario.");
                    Console.ReadKey();
                    Limpiar(20, 80, 24, 24);
                    Limpiar(37, 80, 10, 10);
                    repetir = "1";
                }
                if (repetir == "1") { continue; }
                Console.SetCursorPosition(20, 26); Console.Write("Desea Aumentar otro stock? Si(1) No(Otro) ");
                repetir = Console.ReadLine();
                Console.Clear();
                Cuadro(1, 80, 1, 6);
                Titulos("M e n u   P r i n c i p a l");
                Console.SetCursorPosition(4, 29); Console.Write("Ver lista de productos (-1) ");
            } while (repetir == "1");
        }
        public static void ModStockS(string repetir, int pid, ArrayList aproducto, ArrayList acategoria, int stock)
        {
            do
            {

                if (repetir != "1")
                {
                    Console.Clear();
                    Cuadro(1, 80, 1, 6);
                    Titulos("M e n u   P r i n c i p a l");
                    Console.SetCursorPosition(4, 29); Console.Write("Ver lista de productos (-1) ");
                }
                repetir = "1";
                Console.SetCursorPosition(28, 08); Console.Write("AUMENTAR INVENTARIO");
                Console.SetCursorPosition(20, 10); Console.Write("ID Producto....: ");
                pid = ReadInt();
                if (pid == -1)
                {
                    Listas.ListaProducto.Desplegar(aproducto, acategoria);
                    Limpiar(37, 80, 10, 10);
                    continue;
                }
                if (FindP(pid, aproducto))
                {
                    Producto p = BuscarProducto(pid, aproducto);
                    Console.SetCursorPosition(20, 11); Console.Write("ID Categoria...: " + NombreCatID(acategoria, p.getIDProducto()));
                    Console.SetCursorPosition(20, 12); Console.Write("Nombre.........: " + p.getNombre());
                    Console.SetCursorPosition(20, 13); Console.Write("Precio.........: " + p.getPrecio());
                    Console.SetCursorPosition(20, 14); Console.Write("Existencias....: " + p.getExistencias());

                    Console.SetCursorPosition(20, 16); Console.Write("Aumentar stock: ");
                    stock = ReadInt();

                    ModificarStock(aproducto, pid, stock, true);
                    repetir = "";
                }
                else
                {
                    Console.SetCursorPosition(20, 24); Console.Write("Producto no se encuentra en el inventario.");
                    Console.ReadKey();
                    Limpiar(20, 80, 24, 24);
                    Limpiar(37, 80, 10, 10);
                    repetir = "1";
                }
                if (repetir == "1") { continue; }
                Console.SetCursorPosition(20, 26); Console.Write("Desea Aumentar otro stock? Si(1) No(Otro) ");
                repetir = Console.ReadLine();
                Console.Clear();
                Cuadro(1, 80, 1, 6);
                Titulos("M e n u   P r i n c i p a l");
                Console.SetCursorPosition(4, 29); Console.Write("Ver lista de productos (-1) ");
            } while (repetir == "1");

        }
        public static void OpcionConsultar(ArrayList afactura_encabezado, ArrayList Aempleado, ArrayList AFactura_Detalle, ArrayList Aproducto, ArrayList Acategoria)
        {
            int TipoFiltro = 1;
            do
            {
                try
                {
                    Console.Clear();
                    Filtrosmenu();
                    Cuadro(20, 100, 1, 6);
                    Titulosconsulta();
                    Console.SetCursorPosition(17, 15); Console.Write("Su opcion...: ");
                    TipoFiltro = Convert.ToInt32(Console.ReadLine());
                    if (TipoFiltro < 0 || TipoFiltro > 4)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Ha elegido una opcion no válida.");
                    }
                    if (TipoFiltro > 0 && TipoFiltro < 6)
                    {
                        if (TipoFiltro > 0 && TipoFiltro < 5)
                            ConsultarVentas(afactura_encabezado, Aempleado, TipoFiltro);
                        else
                        {

                            ImprimirTopVentas(AFactura_Detalle, Aempleado, Aproducto, Acategoria);
                            Console.ReadKey();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(ex.Message);
                }

            } while (TipoFiltro < 0 || TipoFiltro > 4);
        }
        public static void ConsultarInventario(ArrayList aproducto, ArrayList acategoria)
        {
            int fila = 11;
            Limpiar(1, 79, 8, 20);
            Console.SetCursorPosition(28, 08); Console.Write("PRODUCTOS EN EL INVENTARIO");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 10); Console.Write("IDProducto |Categoria  | Nombre del producto      |Existencia|  Precio|   Estado ");
            Console.ResetColor();

            foreach (Producto p in aproducto)
            {
                Console.SetCursorPosition(6, fila); Console.Write(p.getIDProducto());
                Console.SetCursorPosition(13, fila); Console.Write(NombreCatID(acategoria, p.getIDCategoria()));
                Console.SetCursorPosition(25, fila); Console.Write(p.getNombre().PadLeft(12));
                Console.SetCursorPosition(52, fila); Console.Write(p.getExistencias());
                Console.SetCursorPosition(63, fila); Console.Write(p.getPrecio().ToString("###,###,###,###").PadLeft(8));
                Console.SetCursorPosition(72, fila); Console.Write(((p.getEstado()) ? "Activo" : "Inactivo").PadLeft(9));
                fila++;
            }
            Console.ReadKey();
        }
        public static bool VerifyUserAvl(string usuario, ArrayList Aempleado)
        {
            bool disponible = true;

            foreach (Empleado em in Aempleado)
            {
                if (usuario == em.getUser())
                {
                    disponible = false;
                    return disponible;
                }
            }
            return disponible;
        }
        public static int ReadInt(bool positivo = true)
        {
            int num = 0;
            int x1 = Console.CursorLeft;
            int y1 = Console.CursorTop;
            do
            {
                try
                {
                    Console.SetCursorPosition(x1, y1); num = Convert.ToInt32(Console.ReadLine());
                    if(positivo)
                        if (num <=0)
                        {
                            Console.SetCursorPosition(20, 24); Console.WriteLine("No se permiten numeros negativos ni 0");
                            Console.ReadKey();
                            Limpiar(20, 80, 24, 24);
                            Limpiar(x1, 80, y1, y1);
                            continue;
                        }
                    break;
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Limpiar(20, 80, 24, 24);
                    Limpiar(x1, 80, y1, y1);
                    continue;
                }
            } while (true);
            
            return num;
        }
        public static double ReadDouble(bool positivo = true)
        {
            double num = 0;
            int x1 = Console.CursorLeft;
            int y1 = Console.CursorTop;
            do
            {
                try
                {
                    Console.SetCursorPosition(x1, y1); num = Convert.ToDouble(Console.ReadLine());
                    if (positivo)
                        if (num <= 0)
                        {
                            Console.SetCursorPosition(20, 24); Console.WriteLine("No se permiten numeros negativos ni 0");
                            Console.ReadKey();
                            Limpiar(20, 80, 24, 24);
                            Limpiar(x1, 80, y1, y1);
                            continue;
                        }
                    break;
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Limpiar(20, 80, 24, 24);
                    Limpiar(x1, 80, y1, y1);
                    continue;
                }
            } while (true);

            return num;
        }
        public static void RegistrarEmpleado(ArrayList Aempleado)
        {
            string user = "";
            string repetir = "";
            string sexo;
            do
            {
                Console.Clear();
                Cuadro(1, 80, 1, 6);
                Titulos("M e n u   P r i n c i p a l");
                Limpiar(1, 79, 8, 20);
                Console.SetCursorPosition(28, 08); Console.Write("REGISTRO DE EMPLEADO");
                Console.SetCursorPosition(20, 10); Console.Write("ID Empleado...: " + Convert.ToString(LastIDE(Aempleado)));
                Console.SetCursorPosition(20, 11); Console.Write("Nombre........: ");
                string nombre = Console.ReadLine().ToString();
                Console.SetCursorPosition(20, 12); Console.Write("Edad..........: ");
                int edad = ReadInt();
                do
                {
                    Console.SetCursorPosition(20, 13); Console.Write("Sexo..........: ");
                    sexo = Console.ReadLine();
                    if(sexo != "M" && sexo != "F")
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Digite M (Masculino) F (Femenino).");
                        Console.ReadKey();
                        Limpiar(20, 80, 24, 24);
                        Limpiar(20, 80, 13, 13);
                        continue;
                    }
                    break;
                } while (true);
                
                Console.SetCursorPosition(20, 14); Console.Write("Ocupacion.....: ");
                string ocupacion = Console.ReadLine();
                do
                {
                    Console.SetCursorPosition(20, 15); Console.Write("Usuario.......: ");
                    user = Console.ReadLine();
                    if (!VerifyUserAvl(user, Aempleado))
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Este nombre de Usuario ya se encuentra registrado.");
                        Console.ReadKey();
                        Limpiar(20, 80, 24, 24);
                        Limpiar(16, 80, 15, 15);
                        continue;
                    }
                    break;
                } while (true);

                Console.SetCursorPosition(20, 16); Console.Write("Contraseña.......: ");
                string pass = Console.ReadLine();

                Aempleado.Add(new Empleado(LastIDE(Aempleado), nombre, edad, ocupacion, sexo, pass, user));

                Console.SetCursorPosition(20, 24); Console.Write("Empleado Registrado Satisfactoriamente ");
                Console.SetCursorPosition(20, 26); Console.Write("Desea Ingresar otro Empleado? Si(1) No(Otro) ");
                repetir = Console.ReadLine();

            } while (repetir == "1");
        }
        public static int LastIDVD(ArrayList Array)
        {
            int id = 0;
            foreach (Factura_Detalle FD in Array)
            {
                id = FD.getID();
            }
            return id + 1;
        }
        public static void RegistrarVenta(ArrayList AFactura_Encabezado, ArrayList aproducto, ArrayList acategoria, Empleado em, ArrayList AFactura_Detalle)
        {
            string repetir = "";
            double total = 0;
            double t_itbis = 0;
            do
            {
                Console.Clear();
                Cuadro(1, 80, 1, 6);
                Titulos("M e n u   P r i n c i p a l");
                Limpiar(1, 79, 8, 20);
                Producto p = new Producto();
                int producto = 0;
                int cantidad = 0;
                Console.SetCursorPosition(20, 11); Console.Write("Num. Factura...: " + LastIDV(AFactura_Encabezado).ToString("0000000"));
                Console.SetCursorPosition(20, 12); Console.Write("Empleado.......: " + em.getNombre());
                Console.SetCursorPosition(20, 13); Console.Write("Fecha..........: " + DateTime.Today.ToString("dd/MM/yyyy"));
                Console.SetCursorPosition(4, 29); Console.Write("Ver lista de producto (-1) ");
                do
                {
                    Console.SetCursorPosition(20, 14); Console.Write("ID Producto....: ");
                    try {
                        producto = Convert.ToInt32(Console.ReadLine());
                        if (producto == -1)
                        {
                            Listas.ListaProducto.Desplegar(aproducto, acategoria);
                            Limpiar(37, 48, 14, 14);
                            continue;
                        }
                        if (FindP(producto, aproducto))
                        {
                            p = BuscarProducto(producto, aproducto);
                            Console.SetCursorPosition(50, 11); Console.Write("ID Categoria...: " + NombreCatID(acategoria, p.getIDCategoria()));
                            Console.SetCursorPosition(50, 12); Console.Write("Nombre.........: " + p.getNombre());
                            Console.SetCursorPosition(50, 13); Console.Write("Precio.........: " + p.getPrecio());
                            Console.SetCursorPosition(50, 14); Console.Write("Existencias....: " + p.getExistencias());

                        }
                        else
                        {
                            Console.SetCursorPosition(20, 24); Console.Write("Producto no se encuentra en el inventario.");
                            Console.ReadKey();
                            Limpiar(37, 48, 14, 14);
                            Limpiar(20, 80, 24, 24);
                        }
                    } catch(Exception ex)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write(ex.Message);
                        Console.ReadKey();
                        Limpiar(37, 48, 14, 14);
                        Limpiar(20, 80, 24, 24);
                    }
                    

                } while (!FindP(producto, aproducto));
                do
                {
                try
                {

                    Console.SetCursorPosition(20, 15); Console.Write("Cantidad.......: ");
                    cantidad = Convert.ToInt32(Console.ReadLine());
                    if(cantidad <= 0)
                        {
                            Console.SetCursorPosition(20, 24); Console.Write("No se acepta valores negativos ni 0.");
                            Console.ReadKey();
                            Limpiar(37, 48, 15, 15);
                            continue;
                        }
                    if(p.getExistencias() - cantidad < 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("No se puede vender esta cantidad porque no hay existencias.");
                        Console.ReadKey();
                        Limpiar(37, 48, 15, 15);
                            Limpiar(20, 80, 24, 24);
                            continue;
                    }
                        break;
                }catch(Exception ex)
                {
                    Console.SetCursorPosition(20, 24); Console.Write(ex.Message);
                    Console.ReadKey();
                    Limpiar(37, 48, 15, 15);
                        Limpiar(20, 80, 24, 24);
                    }
                }while(true);
                double subtotal = cantidad * p.getPrecio();

                double itbis = (0.18) * subtotal;
                ModificarStock(aproducto, producto, cantidad, false);
                AFactura_Detalle.Add(new Factura_Detalle(LastIDVD(AFactura_Detalle), LastIDV(AFactura_Encabezado), producto, subtotal, itbis, cantidad));

                total += subtotal;
                t_itbis += itbis;
                Limpiar(20, 90, 24, 24);
                Console.SetCursorPosition(20, 24); Console.Write("Detalle Registrado Satisfactoriamente ");
                Console.SetCursorPosition(20, 26); Console.Write("Desea Ingresar otro Producto? Si(1) No(Otro) ");
                repetir = Console.ReadLine();
            } while (repetir == "1");
            double neto = total - t_itbis;

            AFactura_Encabezado.Add(new Factura_Encabezado(LastIDV(AFactura_Encabezado), DateTime.Today.ToString("dd/MM/yyyy"), "Contado", em.getID(), total, t_itbis, neto));
        }
        public static void ConsultarVentas(ArrayList AFactura_Encabezado, ArrayList Aempleado, int TipoFiltro = 1)
        {
            Empleado emp = new Empleado();
            Limpiar(1, 79, 8, 20);

            int fila = 14;
            string filtro = "";
            /*

                1 - Historico de venta
                2 - Reporte por Empleado
                3 - Reporte por Dia
                4 - Reporte por Cliente
                0 - Salir

             */
            Console.SetCursorPosition(38, 08); Console.Write("CONSULTA DE VENTAS");
            if (TipoFiltro != 1)
            {
                Console.SetCursorPosition(10, 11); Console.Write("Digite el valor por el cual filtrar: ");
                filtro = Console.ReadLine();
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 13); Console.Write("Num. Factura | Fecha      | Cliente   | Empleado     | Total Bruto|  Total ITBIS|   Total Neto|  Estado ");
            Console.ResetColor();

            foreach (Factura_Encabezado f in AFactura_Encabezado)
            {
                emp = BuscarEmpleadoID(f.getCajero(), Aempleado);
                if (TipoFiltro != 1)
                {
                    if (TipoFiltro == 2 && filtro != emp.getNombre()) { continue; }
                    if (TipoFiltro == 3 && filtro != f.getFecha()) { continue; }
                    if (TipoFiltro == 4 && filtro != f.getN_Cliente()) { continue; }
                }
                Console.SetCursorPosition(4, fila); Console.Write(f.getID().ToString("0000000"));
                Console.SetCursorPosition(17, fila); Console.Write(f.getFecha());
                Console.SetCursorPosition(30, fila); Console.Write(f.getN_Cliente());
                Console.SetCursorPosition(41, fila); Console.Write(emp.getNombre());
                Console.SetCursorPosition(58, fila); Console.Write(f.getT_bruto().ToString("###,###,###.00").PadLeft(9));
                Console.SetCursorPosition(69, fila); Console.Write(f.getT_descuento().ToString("###,###,###.00").PadLeft(12));
                Console.SetCursorPosition(83, fila); Console.Write(f.getT_neto().ToString("###,###,###.00").PadLeft(12));
                Console.SetCursorPosition(95, fila); Console.Write(((f.getActivo()) ? "Activo" : "Inactivo").PadLeft(8));
                fila++;
            }
            Console.ReadKey();
        }
        public static bool FindF(int ID, ArrayList array)
        {
            bool encontrado = false;

            foreach (Factura_Encabezado f in array)
            {
                if (f.getID() == ID)
                {
                    encontrado = true;
                    return encontrado;
                }
            }

            return encontrado;
        }
        public static Factura_Encabezado BuscarFactura(int ID, ArrayList array)
        {
            Factura_Encabezado factura = new Factura_Encabezado();
            foreach (Factura_Encabezado f in array)
            {
                if (f.getID() == ID)
                {
                    factura = f;
                }

            }
            return factura;
        }
        public static void Verfactura(ArrayList AFactura_Encabezado, ArrayList AFactura_Detalle, ArrayList Aempleado, ArrayList Aproducto, ArrayList Acategoria)
        {
            Console.Clear();
            Cuadro(1, 80, 1, 6);
            Titulos("F A C T U R A");
            Limpiar(1, 79, 8, 20);
            Producto p = new Producto();
            Factura_Encabezado f = new Factura_Encabezado();
            Empleado emp = new Empleado();
            int ID = 0;
            do
            {
                Console.SetCursorPosition(15, 11); Console.Write("Num Factura...: ");
                ID = ReadInt();
                if (FindF(ID, AFactura_Encabezado))
                {
                    f = BuscarFactura(ID, AFactura_Encabezado);
                    emp = BuscarEmpleadoID(f.getCajero(), Aempleado);
                    Console.SetCursorPosition(15, 12); Console.Write("Fecha.........: " + f.getFecha());
                    Console.SetCursorPosition(15, 13); Console.Write("Tipo Factura..: Contado");


                    Console.SetCursorPosition(50, 12); Console.Write("Empleado.......: " + emp.getNombre());
                    Console.SetCursorPosition(50, 13); Console.Write("Cliente........: " + f.getN_Cliente());
                    int fila = 17;

                    // Inicio de tabla para el detalle de la factura
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(11, fila - 1); Console.Write("Nombre Producto | Categoria | Precio   | Cantidad | Subtotal | ITBIS   ");
                    Console.ResetColor();
                    foreach (Factura_Detalle fd in AFactura_Detalle)
                    {
                        if (ID != fd.getID_Encabezado()) { continue; }
                        p = BuscarProducto(fd.getID_Producto(), Aproducto);
                        Console.SetCursorPosition(14, fila); Console.Write(p.getNombre());
                        Console.SetCursorPosition(28, fila); Console.Write(NombreCatID(Acategoria, p.getIDCategoria()));
                        Console.SetCursorPosition(37, fila); Console.Write(p.getPrecio().ToString("###,###,###.00").PadLeft(9));
                        Console.SetCursorPosition(51, fila); Console.Write(fd.getCantidad().ToString("###,###,###").PadLeft(9));
                        Console.SetCursorPosition(62, fila); Console.Write(fd.getsubTotal().ToString("###,###,###.00").PadLeft(9));
                        Console.SetCursorPosition(73, fila); Console.Write(fd.getITBIS().ToString("###,###,###.00").PadLeft(8));
                        fila++;
                    }

                    // Fin de tabla para el detalle de la factura

                    Console.SetCursorPosition(11, fila + 4); Console.Write("Total Bruto.....: " + f.getT_bruto());
                    Console.SetCursorPosition(36, fila + 4); Console.Write("Total ITBIS.....: " + f.getT_descuento());
                    Console.SetCursorPosition(61, fila + 4); Console.Write("Total Neto......: " + f.getT_neto());
                }
                else
                {
                    Console.SetCursorPosition(20, 24); Console.Write("Esta Factura no existe.");
                    Console.ReadKey();
                }

            } while (!FindF(ID, AFactura_Encabezado));
        }
        private static void ImprimirTopVentas(ArrayList AFactura_Detalle, ArrayList Aempleado, ArrayList Aproducto, ArrayList Acategoria)
        {
            Console.Clear();
            Cuadro(1, 80, 1, 6);
            Titulos("F A C T U R A");
            Limpiar(1, 79, 8, 20);
            Producto p = new Producto();
            int fila = 11;
            Console.SetCursorPosition(28, 08); Console.Write("PRODUCTOS MAS VENDIDOS");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(11, fila - 1); Console.Write("Nombre Producto | Categoria | Precio   | Cantidad ");
            Console.ResetColor();
            ArrayList TopVentas = ObtenerTopProductosVendidos(AFactura_Detalle, Aproducto);
            foreach (Factura_Detalle fd in TopVentas)
            {
                p = BuscarProducto(fd.getID_Producto(), Aproducto);
                Console.SetCursorPosition(14, fila); Console.Write(p.getNombre());
                Console.SetCursorPosition(28, fila); Console.Write(NombreCatID(Acategoria, p.getIDCategoria()));
                Console.SetCursorPosition(37, fila); Console.Write(p.getPrecio().ToString("###,###,###.00").PadLeft(9));
                Console.SetCursorPosition(51, fila); Console.Write(fd.getCantidad().ToString("###,###,##0").PadLeft(9));
                fila++;
            }
            Console.ReadKey();
        }
        public static ArrayList ObtenerTopProductosVendidos(ArrayList AFactura_Detalle, ArrayList Aproducto)
        {
            ArrayList TopProductosVendidos = new ArrayList();
            int cantidad_vendido = 0;
            int ID = 0;
            foreach (Producto p in Aproducto)
            {
                cantidad_vendido = 0;
                foreach (Factura_Detalle fd in AFactura_Detalle)
                {
                    if (p.getIDProducto() == fd.getID_Producto())
                    {
                        cantidad_vendido += fd.getCantidad();
                        ID = fd.getID();
                    }
                }
                TopProductosVendidos.Add(new Factura_Detalle(ID, p.getIDProducto(), cantidad_vendido));
            }

            TopProductosVendidos = OrdenarTopD(TopProductosVendidos);
            return TopProductosVendidos;
        }
        public static ArrayList OrdenarTopA(ArrayList TopProductosVendido)
        {
            Factura_Detalle burbuja;
            List<Factura_Detalle> TopProductosVendidos = new List<Factura_Detalle>();
            foreach (Factura_Detalle f in TopProductosVendido)
            {
                TopProductosVendidos.Add(f);
            }
            for (int indice = 1; indice < TopProductosVendidos.Count; indice++)
                for (int b = TopProductosVendidos.Count - 1; b >= indice; b--)
                {
                    if (TopProductosVendidos[b - 1].getCantidad() > TopProductosVendidos[b].getCantidad())
                    {
                        burbuja = TopProductosVendidos[b - 1];
                        TopProductosVendidos[b - 1] = TopProductosVendidos[b];
                        TopProductosVendidos[b] = burbuja;
                    }
                }
            TopProductosVendido = new ArrayList();
            foreach (Factura_Detalle f in TopProductosVendidos)
            {
                TopProductosVendido.Add(f);
            }
            return TopProductosVendido;
        }
        public static ArrayList OrdenarTopD(ArrayList TopProductosVendido)
        {
            Factura_Detalle burbuja;
            List<Factura_Detalle> TopProductosVendidos = new List<Factura_Detalle>();
            foreach (Factura_Detalle f in TopProductosVendido)
            {
                TopProductosVendidos.Add(f);
            }
            for (int indice = 0; indice < TopProductosVendidos.Count; indice++)
            {
                for (int b = 0; b < TopProductosVendidos.Count - 1; b++)
                {
                    int indiceSiguienteElemento = b + 1;
                    // Si el actual es menor que el que le sigue a la derecha...
                    if (TopProductosVendidos[b].getCantidad() < TopProductosVendidos[indiceSiguienteElemento].getCantidad())
                    {
                        burbuja = TopProductosVendidos[b];
                        TopProductosVendidos[b] = TopProductosVendidos[indiceSiguienteElemento];
                        TopProductosVendidos[indiceSiguienteElemento] = burbuja;
                    }
                }
            }
                TopProductosVendido = new ArrayList();
                foreach (Factura_Detalle f in TopProductosVendidos)
                {
                    TopProductosVendido.Add(f);
                }
                return TopProductosVendido;
            }
    }
}