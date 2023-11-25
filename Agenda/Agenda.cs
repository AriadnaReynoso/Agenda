using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda
{
    // Documentaci�n de la clase Agenda: Maneja la lista de contactos.
    class Agenda
    {
        // Tama�o m�ximo de la agenda
        private const int TAM = 10;
        private Contacto[] _contactos;
        private int _index; // �ndice actual de contactos en la agenda

        // Propiedad para obtener el n�mero de contactos actualmente en la agenda
        public int NumContactos
        {
            get
            {
                return _index;
            }
        }

        // Constructor de la clase Agenda
        // Inicializa la agenda con un tama�o predeterminado.
        public Agenda()
        {
            _index = 0;
            _contactos = new Contacto[TAM];
        }

        // M�todo para agregar un contacto a la agenda
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

        // M�todo para borrar el �ltimo contacto de la agenda
        public void BorrarUltimoContacto()
        {
            if (_index > 0)
            {
                _contactos[_index] = null;
                _index--;
            }
            else
            {
                Console.WriteLine("La agenda ya est� vac�a");
            }
        }

        // M�todo para verificar la existencia de contactos de la agenda
        private bool NoHayContactos()
        {
            if(_index == 0)
            {
                Console.WriteLine("No hay contactos");
                return true;
            }

            return false;
        }

        // M�todo para mostrar los contactos de forma ordenada la agenda
        public void MostrarOrdenados()
        {
            if (NoHayContactos()) { return; }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);

            Console.WriteLine(CadenaContactos(ordenados));
        }

        // M�todo para mostrar los contactos de forma descente de la agenda
        public void MostrarOrdenadosDesc()
        {
            if (NoHayContactos()) { return; }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);
            Array.Reverse(ordenados);

            Console.WriteLine(CadenaContactos(ordenados)); 
        }

        // M�todo para buscar los contactos por nombre en la agenda
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

        // M�todo para mostrar los contactos de la agenda
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
