using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace ValverdeCristian._23
{
    public abstract class Persona
    {
        protected string apellido;
        protected string barrioResidencia;
        protected DateTime nacimiento;
        protected string nombre;

        public Persona(string nombre, string apellido, DateTime nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
        }

        public Persona(string nombre, string apellido, DateTime nacimiento, string barrioResidencia):this(nombre, apellido, nacimiento)
        {
            this.barrioResidencia = barrioResidencia;
        }

        public string NombreCompleto
        {
            get
            {
                return $"{apellido}, {nombre}";
            }
        }

        public int Edad
        {
            get
            {
                return DateTime.Today.AddTicks(-this.nacimiento.Ticks).Year -1;
            }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }

        public string FichaPersonal(Persona p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(NombreCompleto);
            sb.AppendLine($"EDAD: {Edad}");
            if(!string.IsNullOrEmpty (barrioResidencia))
            {
                sb.AppendLine($"BARRIO DE RESIDENCIA: {barrioResidencia}");
            }

            return sb.ToString();
        }

        internal abstract string FichaExtra();
    }
}