using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Factura_Detalle
    {
        private int ID;
        private int ID_Encabezado;
        private int ID_Producto;
        private int Cantidad;
        private double subTotal;
        private double ITBIS;
        private bool activo = true;

        public Factura_Detalle()
        {

        }

        public Factura_Detalle(int iD, int iD_Encabezado, int iD_Producto, double subTotal, double iTBIS, int Cantidad, bool activo = true)
        {
            this.ID = iD;
            this.ID_Encabezado = iD_Encabezado;
            this.ID_Producto = iD_Producto;
            this.subTotal = subTotal;
            this.ITBIS = iTBIS;
            this.Cantidad = Cantidad;
            this.activo = activo;
        }

        public Factura_Detalle(int ID, int ID_Producto, int Cantidad_Vendida)
        {
            this.ID = ID;
            this.ID_Producto = ID_Producto;
            this.Cantidad = Cantidad_Vendida;
        }

        public int getID()
        {
            return ID;
        }
        public int getID_Encabezado()
        {
            return ID_Encabezado;
        }
        public int getID_Producto()
        {
            return ID_Producto;
        }
        public double getsubTotal()
        {
            return subTotal;
        }
        public double getITBIS()
        {
            return ITBIS;
        }
        public int getCantidad()
        {
            return Cantidad;
        }
        public bool getEstado()
        {
            return activo;
        }

        public void setID(int ID)
        {
           this.ID = ID;
        }
        public void setID_Encabezado(int ID)
        {
           this.ID_Encabezado = ID;
        }
        public void setID_Producto(int ID)
        {
           this.ID_Producto = ID;
        }
        public void setsubTotal(double precio)
        {
           this.subTotal = precio;
        }
        public void setITBIS(double precio)
        {
           this.ITBIS = precio;
        }
        public void setEstado(bool estado)
        {
           this.activo = estado;
        }

    }
}
