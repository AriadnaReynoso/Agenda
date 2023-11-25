using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda
{
    // Documentación de la clase Agenda: Maneja la lista de contactos.
    class Agenda
    {
        // Tamaño máximo de la agenda
        private const int TAM = 10;
        private Contacto[] _contactos;
        private int _index; // Índice actual de contactos en la agenda

        // Propiedad para obtener el número de contactos actualmente en la agenda
        public int NumContactos
        {
            get
            {
                return _index;
            }
        }

        // Constructor de la clase Agenda
        // Inicializa la agenda con un tamaño predeterminado.
        public Agenda()
        {
            _index = 0;
            _contactos = new Contacto[TAM];
        }

        // Método para agregar un contacto a la agenda
        public void AgregarContacto(Contacto contacto)
        {
            if (_index < TAM)
            {
                _contactos[_index] = contacto;
                _index++;
            }
            else
            {
                Console.WriteLine("Agenda Llena");
            }
        }

        // Método para borrar el último contacto de la agenda
        public void BorrarUltimoContacto()
        {
            if (_index > 0)
            {
                _contactos[_index] = null;
                _index--;
            }
            else
            {
                Console.WriteLine("La agenda ya está vacía");
            }
        }

        // Método para verificar la existencia de contactos de la agenda
        private bool NoHayContactos()
        {
            if(_index == 0)
            {
                Console.WriteLine("No hay contactos");
                return true;
            }

            return false;
        }

        // Método para mostrar los contactos de forma ordenada la agenda
        public void MostrarOrdenados()
        {
            if (NoHayContactos()) { return; }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);

            Console.WriteLine(CadenaContactos(ordenados));
        }

        // Método para mostrar los contactos de forma descente de la agenda
        public void MostrarOrdenadosDesc()
        {
            if (NoHayContactos()) { return; }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);
            Array.Reverse(ordenados);

            Console.WriteLine(CadenaContactos(ordenados)); 
        }

        // Método para buscar los contactos por nombre en la agenda
        public Contacto BuscarPorNombre(string nombre)
        {
            foreach (Contacto contacto in _contactos)
            {
                if (contacto != null && contacto.Nombre == nombre)
                {
                    return contacto;
                }
            }

            return null;
        }

        // Método para mostrar los contactos de la agenda
        public void MostrarContactos()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return CadenaContactos(_contactos);
        }

        private string CadenaContactos(Contacto[] contactos)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _index; i++)
            {
                if(_contactos[i] == null) { continue; }

                string dato = string.Format("{0}. {1}", i + 1, contactos[i]);
                sb.AppendLine(dato);
            }

            return sb.ToString();
        }
    }
}
