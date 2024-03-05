using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Asignaturas
    {
        public string nombre { get; set; }
        public int creditos { get; set; }
        public List<Notas> notas { get; set; }
        public Asignaturas(string nombre, int creditos)
        {
            this.nombre = nombre;
            this.creditos = creditos;
            this.notas = new List<Notas>();
        }

        public double ContarPorcentaje()
        {
            double sumatoriaPorcentaje = 0;
            foreach (Notas nota in notas)
            {
                sumatoriaPorcentaje += nota.porcentaje;
            }
            return sumatoriaPorcentaje;
        }

        public bool ValidarPorcentaje()
        {
            if (this.ContarPorcentaje() < 1) return true;
            return false;
        }

        public override string ToString()
        {
            return ($"Nombre: {this.nombre}\nCreditos: {this.creditos}");
        }

        public string verNotas()
        {
            string sb = "";
            sb += $"## {this.nombre} ##\n";
            if (notas.Count > 0)
            {
                foreach (Notas nota in notas)
                {
                    sb += nota.ToString();
                }
            }
            else sb += "No hay notas";
            return sb;
        }

        private double Promedio()
        {
            double SumatoriaNotas = 0;
            foreach (Notas nota in notas)
            {
                SumatoriaNotas += (nota.valor * nota.porcentaje);
            }
            return SumatoriaNotas;
        }

        public double notasAcomuladas()
        {
            if (this.notas.Count > 0 && this.ValidarPorcentaje())
                return this.Promedio() / this.ContarPorcentaje();
            else if (this.notas.Count > 0 && !this.ValidarPorcentaje())
                return this.Promedio();
            return 0;
        }

        public double notaDeseada(double NotaRequerida)
        {
            if (ValidarPorcentaje()) return (NotaRequerida - this.Promedio()) / (1 - this.ContarPorcentaje());
            return this.Promedio();
        }
    }
}
