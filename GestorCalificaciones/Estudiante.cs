using System;
using System.Collections.Generic;

namespace GestorCalificaciones
{
    public class Estudiante
    {
        public string Matricula { get; private set; }
        public string Nombre { get; private set; }

        public List<double> Calificaciones { get; private set; }

        public Estudiante(string matricula, string nombre)
        {
            Matricula = matricula;
            Nombre = nombre;
            Calificaciones = new List<double>();
        }

  
        public double CalcularPromedio()
        {
            if (Calificaciones.Count == 0)
            {
                return 0;
            }

            double suma = 0;

            foreach (double nota in Calificaciones)
            {
                suma += nota;
            }

            return suma / Calificaciones.Count;
        }

        
        public string ObtenerEstado()
        {
            if (Calificaciones.Count == 0)
            {
                return "Sin calificaciones";
            }

            if (CalcularPromedio() >= 70)
            {
                return "Aprobado";
            }
            else
            {
                return "Reprobado";
            }
        }


    }

}
