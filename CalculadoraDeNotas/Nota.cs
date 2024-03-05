using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Notas
    {
        public string nombre
        {
            get; set;
        }
        public double porcentaje
        {
            get; set;
        }
        public double valor
        {
            get; set;
        }
        public Notas(string Nombre, double Valor, double Porcentaje)
        {
            this.nombre = Nombre;
            this.valor = Valor;
            this.porcentaje = (Porcentaje / 100);
        }
        public override string ToString()
        {
            return ($"Nombre: {this.nombre}\nNota: {this.valor}\nPorcentaje: {this.porcentaje * 100}%\n");
        }
    }

}