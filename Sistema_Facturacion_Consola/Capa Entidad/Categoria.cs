using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Categoria
    {
        private int Id { get; set; }
        private string Nombre { get; set; }
        private string Descripcion { get; set; }
        private bool Activo = true;
        public Categoria()
        {

        }
        public Categoria(int ID, string nombre, string descripcion, bool Estado = true)
        {
            this.Id = ID;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Activo = Estado;
        }
        public int getID()
        {
            return Id;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public string getDescripcion()
        {
            return Descripcion;
        }
        public bool getEstado()
        {
            return Activo;
        } 
        public void setID(int ID)
        {
            this.Id = ID;
        }
        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }
        public void setDescripcion(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public void setEstado(bool Estado)
        {
            this.Activo = Estado;
        }

    }
}
