
using System;
using System.Collections.Generic;

namespace GestorCalificaciones
{
    public class GestorCalificaciones
    {
        private List<Estudiante> estudiantes;

        public GestorCalificaciones()
        {
            estudiantes = new List<Estudiante>();
        }

        public bool RegistrarEstudiante(string matricula, string nombre)
        {
            if (BuscarEstudiante(matricula) != null)
            {
                return false;
            }

            Estudiante nuevo = new Estudiante(matricula, nombre);
            estudiantes.Add(nuevo);

            return true;
        }

        public Estudiante? BuscarEstudiante(string matricula)
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.Matricula == matricula)
                {
                    return estudiante;
                }
            }

            return null;
        }

        public bool AgregarCalificacion(string matricula, double calificacion)
        {
            Estudiante? estudiante = BuscarEstudiante(matricula);

            if (estudiante == null)
            {
                return false;
            }

            if (calificacion < 0 || calificacion > 100)
            {
                return false;
            }

            estudiante.Calificaciones.Add(calificacion);

            return true;
        }

        public List<Estudiante> ConsultarEstudiantes()
        {
            return new List<Estudiante>(estudiantes);
        }
    }
}
