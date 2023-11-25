using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda
{
    // Documentaci�n de la clase Contacto: Representa un contacto con nombre, tel�fono y email.
    class Contacto : IComparable<Contacto>
    {
        // Propiedades de un contacto
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Constructores de la clase Contacto
        public Contacto()
        {
        }

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        // M�todo que ompara si dos objetos Contacto son iguales.
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Contacto c = obj as Contacto;
            if (c == null)
            {
                return false;
            }

            return string.Equals(Nombre, c.Nombre) && string.Equals(Telefono, c.Telefono);
        }

        // M�todo que obtiene el c�digo hash del objeto Contacto.
        public override int GetHashCode()
        {
            unchecked
            {
                int hashNombre = (Nombre != null ? Nombre.GetHashCode() : 0);
                int hashTelefono = (Telefono != null ? Telefono.GetHashCode() : 0);
                return (hashNombre * 397) ^ (hashTelefono);
            }
        }

        // M�todo que devuelve una representaci�n en cadena del objeto Contacto.
        public override string ToString()
        {
            return string.Format("Nombre: {0}\nTel�fono: {1}\nEmail: {2}\n", Nombre, Telefono, Email);
        }

        public int CompareTo(Contacto other)
        {
            return Nombre.CompareTo(other.Nombre);
        }
    }
}