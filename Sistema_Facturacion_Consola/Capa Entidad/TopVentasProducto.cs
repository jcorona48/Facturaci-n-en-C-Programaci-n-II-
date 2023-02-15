using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class TopVentasProducto
    {
        private int ID;
        private int ID_Producto;
        private int Cantidad_Vendida;



        public TopVentasProducto()
        {

        }
        public TopVentasProducto(int ID, int ID_Producto, int Cantidad_Vendida)
        {
            this.ID = ID;
            this.ID_Producto = ID_Producto;
            this.Cantidad_Vendida = Cantidad_Vendida;
        }

        public int getID()
        {
            return ID;
        }
        public int getID_Producto()
        {
            return ID_Producto;
        }
        public int getCantidad_Vendida()
        {
            return Cantidad_Vendida;
        }

        public void setID(int ID)
        {
            this.ID = ID;
        }
        public void setID_Producto(int ID_Producto)
        {
            this.ID_Producto = ID_Producto;
        }
        public void setCantidad_Vendida(int Cantidad_Vendida)
        {
            this.Cantidad_Vendida = Cantidad_Vendida;
        }

    }
}
