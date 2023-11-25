using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda
{
    // Clase que controla la interacci�n del usuario con la agenda de contactos en la consola.
    // Proporciona m�todos para mostrar men�s, agregar, borrar, buscar contactos y mostrar informaci�n sobre el autor.
    class ControlAgenda
    {
        private Agenda _agenda; // Instancia de la agenda que se va a controlar

        // Constructor de la clase ControlAgenda.
        public ControlAgenda(Agenda agenda)
        {
            _agenda = agenda;
        }

        // M�todo que muestra los contactos en orden ascendente o descendente seg�n la elecci�n del usuario.
        public void VerContactos()
        {
            Limpiar();
            MenuMostrar();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Contactos Orden Ascendente");
                    _agenda.MostrarOrdenados();
                    break;
                case "2":
                    Console.WriteLine("Contactos Orden Descendente");
                    _agenda.MostrarOrdenadosDesc();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opci�n no v�lida");
                    break;
            }

            PresionaParaContinuar();
        }

        // M�todo para agregar un contacto a la agenda
        public void AgregarContacto()
        {
            Limpiar();
            Console.WriteLine("Nuevo Contacto");
            Contacto contacto = new Contacto();
            Console.Write("Nombre: ");
            contacto.Nombre = Console.ReadLine();
            Console.Write("Tel�fono: ");
            contacto.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            contacto.Email = Console.ReadLine();

            _agenda.AgregarContacto(contacto);
            Console.WriteLine("Contacto agregado exitosamente");
            PresionaParaContinuar();
        }

        // M�todo para borrar el �ltimo contacto de la agenda
        public void BorrarUltimoContacto()
        {
            Limpiar();
            _agenda.BorrarUltimoContacto();
            Console.WriteLine("Contacto borrado exitosamente");
            PresionaParaContinuar();
        }

        // M�todo para buscar los contactos por nombre en la agenda
        public void BuscarPorNombre()
        {
            Limpiar();
            Console.WriteLine("Buscar contacto");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Contacto contacto = _agenda.BuscarPorNombre(nombre);
            if (contacto != null)
            {
                Console.WriteLine("Datos: \n" + contacto);
            }
            else
            {
                Console.WriteLine("Contacto no encontrado");
            }

            PresionaParaContinuar();
        }

        // Muestra informaci�n sobre el autor del programa en la consola.
        public static void AcercaDe()
        {
            Limpiar();
            Console.WriteLine("Nombre: Enrique Mungu�a");

            PresionaParaContinuar();
        }

        // Muestra un men� de opciones 
        public void MenuMostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Mostrar orden ascendente");
            sb.AppendLine("2. Mostrar orden descendente");
            sb.AppendLine("3. Volver al men� principal");
            sb.Append("Seleccione una opci�n: ");

            Console.Write(sb.ToString());
        }

        // M�todo para continuar en el men�
        private static void PresionaParaContinuar()
        {
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
        }

        // M�todo para limpiar
        private static void Limpiar()
        {
            Console.Clear();
        }
    }
}