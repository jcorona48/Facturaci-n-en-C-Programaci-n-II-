using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Producto
    {
        private int IDProducto { get; set; }
        private int Existencia { get; set; }
        private int IDCategoria { get; set; }

        private string Nombre { get; set; }
        private double Precio { get; set; }

        private bool Activo = true;

        public Producto()
        {

        }

        public Producto(int id, int idCategoria, int existencia, string nombre, double precio, bool activo = true)
        {
            this.IDProducto = id;
            this.Existencia = existencia;
            this.IDCategoria = idCategoria;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Activo = activo;

        }


        public int getIDProducto()
        {
            return IDProducto;
        }

        public int getIDCategoria()
        {
            return IDCategoria;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public double getPrecio()
        {
            return Precio;
        }

        public bool getEstado()
        {
            return Activo;
        }

        public int getExistencias()
        {
            return Existencia;
        }

        public void setIDproducto(int id)
        {
            this.IDProducto = id;
        }

        public void setIDCategoria(int IDCat)
        {
            this.IDCategoria = IDCat;
        }

        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }
        public void setPrecio(double precio)
        {
            this.Precio = precio;
        }

        public void setActivo(bool estado)
        {
            this.Activo = estado;
        }
        public void setExistencias(int stock)
        {
            this.Existencia = stock;
        }

        public void AgregarInventario(int cantidad)
        {
            if (this.Activo)
                this.Existencia += cantidad;
            else
            {
                Console.WriteLine("\n * * * No se puede agregar stock a un producto inactivo * * *");
            }
        }
        public void ReducirInventario(int cantidad)
        {
            if (this.Activo)
                this.Existencia -= cantidad;
            else
            {
                Console.WriteLine("\n * * * No se puede reducir stock a un producto inactivo * * *");
            }
        }
    }
}
