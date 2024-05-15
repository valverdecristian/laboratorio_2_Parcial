using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValverdeCristian._23
{
    public class PersonalMedico : Persona
    {
        List<Consulta> consultas;
        bool esResidente;

        public PersonalMedico(string nombre, string apellido, DateTime nacimiento, bool esResidente)
            :base(nombre, apellido, nacimiento)
        {
            consultas = new List<Consulta>();
            this.esResidente = esResidente;
        }

        internal override string FichaExtra()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"¿Finalizo residencia? {(esResidente ? "SI":"NO")}");
            sb.AppendLine("ATENCIONES:");
            foreach (var consulta in consultas)
            {
                sb.AppendLine(consulta.ToString());
            }

            return sb.ToString();
        }

        public static Consulta operator +(PersonalMedico medico, Paciente paciente)
        {

            if (medico.consultas is not null)
            {
                foreach (var consulta in medico.consultas)
                {
                    if(consulta.Paciente == paciente && consulta.Fecha == DateTime.Now)
                    {
                        Consulta nuevaConsulta = new Consulta(DateTime.Now, paciente);
                        medico.consultas.Add(nuevaConsulta);
                        return nuevaConsulta;
                    }
                }
            }

            return null;
        }
    }
}
