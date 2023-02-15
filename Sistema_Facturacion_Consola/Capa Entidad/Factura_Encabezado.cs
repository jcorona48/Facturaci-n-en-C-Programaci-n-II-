using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Factura_Encabezado
    {
        private int ID;
        private string Fecha;
        private string N_Cliente;
        private int ID_Cajero;
        private double T_bruto;
        private double T_descuento;
        private double T_neto;
        private bool activo = true;


        public Factura_Encabezado()
        {

        }
        public Factura_Encabezado(int ID, string fecha, string NombreCliente, int cajero, double t_bruto, double t_descuento, double t_neto)
        {
            this.ID = ID;
            this.Fecha = fecha;
            this.N_Cliente = NombreCliente;
            this.ID_Cajero = cajero;
            this.T_bruto = t_bruto;
            this.T_descuento = t_descuento;
            this.T_neto = t_neto;
        }

        public int getID()
        {
            return ID;
        }
        public string getFecha()
        {
            return Fecha;
        }
        public string getN_Cliente()
        {
            return N_Cliente;
        }
        public int getCajero()
        {
            return ID_Cajero;
        }
        public double getT_bruto()
        {
            return T_bruto;
        }
        public double getT_descuento()
        {
            return T_descuento;
        }
        public double getT_neto()
        {
            return T_neto;
        }

        public bool getActivo()
        {
            return activo;
        }
        public void setActivo(bool estado)
        {
            this.activo = estado;
        }
        public void setID(int ID)
        {
            this.ID = ID;
        }
        public void setFecha(string fecha)
        {
            this.Fecha = fecha;
        }

        public void setN_Cliente(string N_Cliente)
        {
            this.N_Cliente= N_Cliente;
        }
        public void setCajero(int Cajero)
        {
            this.ID_Cajero = Cajero;
        }
        public void setT_bruto(double bruto)
        {
            this.T_bruto = bruto;
        }

        public void setT_descuento(double descuento)
        {
            this.T_descuento = descuento;

        }
        public void setT_neto(double neto)
        {
            this.T_neto = neto;
        }


    }



}
