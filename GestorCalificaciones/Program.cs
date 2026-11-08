
using System;

namespace GestorCalificaciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorCalificaciones gestor = new GestorCalificaciones();

            int opcion = 0;

            while (opcion != 4)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("     GESTOR DE CALIFICACIONES");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Agregar calificacion");
                Console.WriteLine("3. Consultar estudiantes");
                Console.WriteLine("4. Salir");
                Console.WriteLine("================================");
                Console.Write("Seleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Debe ingresar un numero valido.");
                    opcion = 0;
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarEstudiante(gestor);
                        break;

                    case 2:
                        AgregarCalificacion(gestor);
                        break;

                    case 3:
                        ConsultarEstudiantes(gestor);
                        break;

                    case 4:
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void RegistrarEstudiante(GestorCalificaciones gestor)
        {
            Console.Write("\nIngrese la matricula: ");
            string matricula = Console.ReadLine() ?? "";

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(matricula) ||
                string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("La matricula y el nombre son obligatorios.");
                return;
            }

            bool registrado = gestor.RegistrarEstudiante(matricula, nombre);

            if (registrado)
            {
                Console.WriteLine("Estudiante registrado correctamente.");
            }
            else
            {
                Console.WriteLine("Esta matricula ya existe.");
            }
        }

        static void AgregarCalificacion(GestorCalificaciones gestor)
        {
            Console.Write("\nIngrese la matricula del estudiante: ");
            string matricula = Console.ReadLine() ?? "";

            Console.Write("Ingrese la calificacion (0-100): ");

            if (!double.TryParse(Console.ReadLine(), out double calificacion))
            {
                Console.WriteLine("Debe ingresar una calificacion numerica.");
                return;
            }

            bool agregada = gestor.AgregarCalificacion(matricula, calificacion);

            if (agregada)
            {
                Console.WriteLine("Calificacion agregada correctamente.");
            }
            else
            {
                Console.WriteLine("No se pudo agregar. Verifique la matricula y la calificacion.");
            }
        }

        static void ConsultarEstudiantes(GestorCalificaciones gestor)
        {
            List<Estudiante> estudiantes = gestor.ConsultarEstudiantes();

            Console.WriteLine("\n LISTADO DE ESTUDIANTES ");

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("\nMatricula: " + estudiante.Matricula);
                Console.WriteLine("Nombre: " + estudiante.Nombre);

                if (estudiante.Calificaciones.Count == 0)
                {
                    Console.WriteLine("Promedio: Sin calificaciones");
                }
                else
                {
                    Console.WriteLine("Promedio: " + estudiante.CalcularPromedio());
                }

                Console.WriteLine("Estado: " + estudiante.ObtenerEstado());
            
            }
        }

    }
}

