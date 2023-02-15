using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Empleado
    {
        private int ID;
        private string Nombre;
        private int edad;
        private string ocupacion;
        private string sexo;
        private string user;
        private string clave;
        private bool Activo = true;
        public Empleado()
        {

        }
        public Empleado(int ID, string nombre, int edad, string ocupacion, string sexo, string clave, string user)
        {
            this.ID = ID;
            this.Nombre = nombre;
            this.edad = edad;
            this.ocupacion = ocupacion;
            this.sexo = sexo;
            this.user = user;
            this.clave = clave;
        }

        public int getID()
        {
            return ID;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public int getEdad()
        {
            return edad;
        }
        public bool getEstado()
        {
            return Activo;
        }
        public string getOcupacion()
        {
            return ocupacion;
        }
        public string getSexo()
        {
            return sexo;
        }
        public string getUser()
        {
            return user;
        }
        public string getPass()
        {
            return clave;
        }

        public void setID(int ID)
        {
            this.ID = ID;
        }
        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }
        public void setEdad(int edad)
        {
            this.edad = edad;
        }
        public void setOcupacion(string ocupacion)
        {
            this.ocupacion = ocupacion;
        }
        public void setSexo(string sexo)
        {
            this.sexo = sexo;
        }
        public void setEstado(bool Estado)
        {
            this.Activo = Estado;
        }
        public void setPass(string pass)
        {
            this.clave = pass;
        }
        public void setUser(string sexo)
        {
            this.sexo = sexo;
        }

    }
}
