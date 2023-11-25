using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda
{
    // Clase que controla la interacción del usuario con la agenda de contactos en la consola.
    // Proporciona métodos para mostrar menús, agregar, borrar, buscar contactos y mostrar información sobre el autor.
    class ControlAgenda
    {
        private Agenda _agenda; // Instancia de la agenda que se va a controlar

        // Constructor de la clase ControlAgenda.
        public ControlAgenda(Agenda agenda)
        {
            _agenda = agenda;
        }

        // Método que muestra los contactos en orden ascendente o descendente según la elección del usuario.
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
                    Console.WriteLine("Opción no válida");
                    break;
            }

            PresionaParaContinuar();
        }

        // Método para agregar un contacto a la agenda
        public void AgregarContacto()
        {
            Limpiar();
            Console.WriteLine("Nuevo Contacto");
            Contacto contacto = new Contacto();
            Console.Write("Nombre: ");
            contacto.Nombre = Console.ReadLine();
            Console.Write("Teléfono: ");
            contacto.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            contacto.Email = Console.ReadLine();

            _agenda.AgregarContacto(contacto);
            Console.WriteLine("Contacto agregado exitosamente");
            PresionaParaContinuar();
        }

        // Método para borrar el último contacto de la agenda
        public void BorrarUltimoContacto()
        {
            Limpiar();
            _agenda.BorrarUltimoContacto();
            Console.WriteLine("Contacto borrado exitosamente");
            PresionaParaContinuar();
        }

        // Método para buscar los contactos por nombre en la agenda
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

        // Muestra información sobre el autor del programa en la consola.
        public static void AcercaDe()
        {
            Limpiar();
            Console.WriteLine("Nombre: Enrique Munguía");

            PresionaParaContinuar();
        }

        // Muestra un menú de opciones 
        public void MenuMostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Mostrar orden ascendente");
            sb.AppendLine("2. Mostrar orden descendente");
            sb.AppendLine("3. Volver al menú principal");
            sb.Append("Seleccione una opción: ");

            Console.Write(sb.ToString());
        }

        // Método para continuar en el menú
        private static void PresionaParaContinuar()
        {
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
        }

        // Método para limpiar
        private static void Limpiar()
        {
            Console.Clear();
        }
    }
}