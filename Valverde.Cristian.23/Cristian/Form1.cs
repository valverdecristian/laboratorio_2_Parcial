using ValverdeCristian._23;
namespace Cristian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstMedicos.Items.Add(new PersonalMedico("Gustavo", "Rivas", new DateTime(1999, 12, 12), false));
            lstMedicos.Items.Add(new PersonalMedico("Lautaro", "Galarza", new DateTime(1951, 11, 12), true));
            lstPacientes.Items.Add(new Paciente("Mathias", "Bustamante", new DateTime(1998, 6, 16), "Tigre"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Ferrini", new DateTime(1989, 1, 21), "DF"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Rodriguez", new DateTime(1912, 12, 12), "LaBoca"));
            lstPacientes.Items.Add(new Paciente("John Jairo", "Trelles", new DateTime(1978, 8, 30), "Medellin"));
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItems == null || lstPacientes.SelectedItems == null)
            {
                MessageBox.Show("Debe seleccionar un medico y un paciente para poder continuar", "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            PersonalMedico medicoSeleccionado = (PersonalMedico)lstMedicos.SelectedItem;
            Paciente pacienteSeleccionado = (Paciente)lstPacientes.SelectedItem;

            Consulta nuevaConsulta = new Consulta(DateTime.Now, pacienteSeleccionado);
            pacienteSeleccionado.Diagnostico = "Paciente curado";

            // Deseleccionar elementos en los ListBox
            lstMedicos.ClearSelected();
            lstPacientes.ClearSelected();

            // Mostrar mensaje con información de la consulta
            string mensajeConsulta = $"Fecha: {nuevaConsulta.Fecha}\n" +
                                        $"Paciente: {pacienteSeleccionado.NombreCompleto}\n" +
                                        $"Diagnóstico: {pacienteSeleccionado.Diagnostico}";
            MessageBox.Show(mensajeConsulta, "Atención finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

    }
}