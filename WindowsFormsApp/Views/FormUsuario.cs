using System;
using System.Windows.Forms;
using WindowsFormsApp.Models;
using WindowsFormsApp.Services;

namespace WindowsFormsApp.Views
{
    public partial class FormUsuario : Form
    {
        UbicacionService ub = new UbicacionService();
        EmpleadoService emp = new EmpleadoService();
        UbicacionService ubserv = new UbicacionService();
        UsuarioService usuarioserv = new UsuarioService();
        public FormUsuario()
        {
            InitializeComponent();
        }
        #region Metodos
        private void BotonesCampos(bool nuevo, bool guardar, bool actualizar, bool cancelar, bool campos, bool grid)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnActualizar.Enabled = actualizar;
            btnCancelar.Enabled = cancelar;
            txtNombreCompleto.Enabled = campos;
            txtUsuario.Enabled = campos;
            txtPwd.Enabled = campos;
            dtpFechaIngreso.Enabled = campos;
            cmbRol.Enabled = campos;
            cmbUbicacion.Enabled = campos;
            dataGridView1.Enabled = grid;
        }
        private void Limpiar()
        {
            txtNombreCompleto.Clear();
            txtUsuario.Clear();
            txtPwd.Clear();
            dtpFechaIngreso.ResetText();
            cmbRol.SelectedIndex = -1;
            cmbUbicacion.SelectedIndex = -1;
            lblIdUsuario.Text = "";
            lblIdEmpleado.Text = "";
            txtNombreCompleto.Focus();
        }
        private void CargarDatosEmpleadosGrid()
        {
            dataGridView1.DataSource = emp.ObtenerEmpleados();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["IdUsuario"].Visible = false;
            dataGridView1.Columns["IdUbicacion"].Visible = false;
        }
        private void CargarComboUbicacion()
        {
            cmbUbicacion.DataSource = ub.ObtenerUbicaciones();
            cmbUbicacion.DisplayMember = "UbicacionN";
            cmbUbicacion.ValueMember = "IdUbicacion";
            cmbUbicacion.SelectedIndex = -1;
        }
        #endregion
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            BotonesCampos(true, false, false, false, false, true);
            CargarDatosEmpleadosGrid();
            CargarComboUbicacion();
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BotonesCampos(false, true, false, true, true, false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            BotonesCampos(true, false, false, false, false, true);
        }
        #region Guardar Usuario
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensajeError = ValidarEntradasUsuario();
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!GuardarUsuario())
            {
                MessageBox.Show("Error al guardar el usuario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Limpiar();
            CargarDatosEmpleadosGrid();
            BotonesCampos(true, false, false, false, false, true);
        }
        private string ValidarEntradasUsuario()
        {
            if (string.IsNullOrEmpty(txtNombreCompleto.Text))
            {
                return "Nombre completo es requerido.";
            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                return "Usuario es requerido.";
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                return "Contraseña es requerida.";
            }

            if (string.IsNullOrEmpty(dtpFechaIngreso.Text))
            {
                return "Fecha de ingreso es requerida.";
            }

            if (string.IsNullOrEmpty(cmbRol.Text))
            {
                return "Rol es requerido.";
            }

            if (cmbUbicacion.SelectedIndex == -1)
            {
                return "Ubicación es requerida.";
            }

            return null; // Sin errores
        }

        private bool GuardarUsuario()
        {
            try
            {
                string nombreCompleto = txtNombreCompleto.Text;
                string usuario = txtUsuario.Text;
                string pwd = txtPwd.Text;
                string rol = cmbRol.Text;
                DateTime ingreso = dtpFechaIngreso.Value.Date;
                int ubicacion = Convert.ToInt32(cmbUbicacion.SelectedValue);

                Usuario us = new Usuario
                {
                    UsuarioN = usuario,
                    NombreCompleto = nombreCompleto,
                    Pwd =usuarioserv.HashPassword(pwd),
                    IdUbicacion = ubicacion,
                    Rol = rol
                };

                int idusersave = usuarioserv.InsertarUsuario(us);

                // Verifica si la inserción del usuario fue exitosa
                if (idusersave <= 0)
                {
                    // Asume que idusersave <= 0 indica un error de unicidad u otro error
                    MessageBox.Show("Error al guardar el usuario. El nombre de usuario puede estar duplicado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Empleado empleado = new Empleado
                {
                    NombreCompleto = nombreCompleto,
                    FechaIngreso = ingreso,
                    IdUsuario = idusersave
                };

                int empGuardado = emp.InsertarEmpleado(empleado);
                if (empGuardado <= 0)
                {
                    MessageBox.Show("Error al guardar el empleado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //metodo para actualizar el idusuario en la tabla empleado cuando se guarda el empleado
                emp.ActualizarEmpleadoIdUsuario(empGuardado, idusersave);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNombreCompleto.Text = row.Cells["Nombre Completo"].Value.ToString();
                dtpFechaIngreso.Value = Convert.ToDateTime(row.Cells["Ingreso"].Value);
                txtUsuario.Text = Convert.ToString(row.Cells["Usuario"].Value);
                cmbRol.Text = Convert.ToString(row.Cells["Rol"].Value);
                cmbUbicacion.SelectedValue = row.Cells["IdUbicacion"].Value;
                lblIdEmpleado.Text = Convert.ToString(row.Cells["Id"].Value);
                lblIdUsuario.Text = Convert.ToString(row.Cells["IdUsuario"].Value);
            }
            BotonesCampos(false, false, true, true, true, true);
        }

        #region Actualizar Usuario
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string mensajeError = ValidarEntradasUsuarioParaActualizar();
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ActualizarUsuario())
            {
                MessageBox.Show("Error al actualizar el usuario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Limpiar();
            CargarDatosEmpleadosGrid();
            BotonesCampos(true, false, false, false, false, true);
        }
        private string ValidarEntradasUsuarioParaActualizar()
        {
            if (string.IsNullOrEmpty(txtNombreCompleto.Text))
            {
                return "Nombre completo es requerido.";
            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                return "Usuario es requerido.";
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                return "Contraseña es requerida.";
            }

            if (string.IsNullOrEmpty(dtpFechaIngreso.Text))
            {
                return "Fecha de ingreso es requerida.";
            }

            if (string.IsNullOrEmpty(cmbRol.Text))
            {
                return "Rol es requerido.";
            }

            if (cmbUbicacion.SelectedIndex == -1)
            {
                return "Ubicación es requerida.";
            }

            if (!int.TryParse(lblIdEmpleado.Text, out _))
            {
                return "ID de empleado no válido.";
            }

            if (!int.TryParse(lblIdUsuario.Text, out _))
            {
                return "ID de usuario no válido.";
            }

            return null; // Sin errores
        }

        private bool ActualizarUsuario()
        {
            try
            {
                int idempleado = int.Parse(lblIdEmpleado.Text);
                string nombreCompleto = txtNombreCompleto.Text;
                DateTime ingreso = dtpFechaIngreso.Value.Date;

                int idusuario = int.Parse(lblIdUsuario.Text);
                string usuario = txtUsuario.Text;
                string pwd = txtPwd.Text;
                string rol = cmbRol.Text;
                int ubicacion = Convert.ToInt32(cmbUbicacion.SelectedValue);

                Empleado updateEmpleado = emp.ObtenerEmpleadoPorId(idempleado);
                Usuario updateUsuario = usuarioserv.ObtenerUsuarioPorId(idusuario);

                if (updateEmpleado == null || updateUsuario == null)
                {
                    MessageBox.Show("No se encontró el empleado o usuario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                updateEmpleado.NombreCompleto = nombreCompleto;
                updateEmpleado.FechaIngreso = ingreso;

                updateUsuario.UsuarioN = usuario;
                updateUsuario.Pwd = usuarioserv.HashPassword(pwd);
                updateUsuario.Rol = rol;
                updateUsuario.IdUbicacion = ubicacion;

                emp.ActualizarEmpleado(updateEmpleado);
                usuarioserv.ActualizarUsuario(updateUsuario);

                return true; // Actualización exitosa
            }
            catch (Exception ex)
            {
                // Registra el error (por ejemplo, en un archivo de registro)
                MessageBox.Show("Error al actualizar, " + ex, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region Ubicacion
        private void LimpiarU()
        {
            txtUbicacion.Clear();
            txtUbicacion.Focus();
        }
        private void BotonesCamposU(bool nuevo, bool guardar, bool actualizar, bool cancelar, bool campos, bool grid)
        {
            btnNuevoUbicacion.Enabled = nuevo;
            btnGuardarUbicacion.Enabled = guardar;
            btnActualizarUbicacion.Enabled = actualizar;
            btnCancelarUbicacion.Enabled = cancelar;
            txtUbicacion.Enabled = campos;
            dataGridViewU.Enabled = grid;
        }
        private void CargarDatosUGrid()
        {
            dataGridViewU.DataSource = ubserv.ObtenerUbicaciones();
            dataGridViewU.Columns["IdUbicacion"].Visible = false;
        }
        private void btnNuevoUbicacion_Click(object sender, EventArgs e)
        {
            LimpiarU();
            BotonesCamposU(false, true, false, true, true, false);

        }
        private void radioButtonAgregarUbicacion_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAgregarUbicacion.Checked)
            {
                groupBoxUbicacion.Visible = true;
                CargarDatosUGrid();
                BotonesCamposU(true, false, false, true, false, true);
            }
        }
        private void btnCancelarUbicacion_Click(object sender, EventArgs e)
        {
            LimpiarU();
            CargarComboUbicacion();
            radioButtonAgregarUbicacion.Checked = false;
            groupBoxUbicacion.Visible = false;
        }
        private void dataGridViewU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewU.Rows[e.RowIndex];
                txtUbicacion.Text = row.Cells["UbicacionN"].Value.ToString();
                lblIdUbicacion.Text = Convert.ToString(row.Cells["IdUbicacion"].Value);
            }
            BotonesCamposU(false, false, true, true, true, true);
        }
        private void btnActualizarUbicacion_Click(object sender, EventArgs e)
        {
            string mensajeError = ValidarEntradaUbicacionActualizar();
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ActualizarUbicacion())
            {
                MessageBox.Show("Error al actualizar la ubicación.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimpiarU();
            CargarDatosUGrid();
            CargarComboUbicacion();
            BotonesCamposU(true, false, false, true, false, true);
        }
        private string ValidarEntradaUbicacionActualizar()
        {
            if (string.IsNullOrEmpty(txtUbicacion.Text))
            {
                return "El campo Ubicación es requerido.";
            }

            if (!int.TryParse(lblIdUbicacion.Text, out _))
            {
                return "ID de ubicación no válido.";
            }

            return null; // Sin errores
        }

        private bool ActualizarUbicacion()
        {
            try
            {
                int idUbicacion = int.Parse(lblIdUbicacion.Text);
                string ubicacion = txtUbicacion.Text;

                Ubicacion nueva = new Ubicacion();
                nueva.IdUbicacion = idUbicacion;
                nueva.UbicacionN = ubicacion;

                return ubserv.ActualizarUbicacion(nueva);
            }
            catch (Exception ex)
            {
                // Registra el error (por ejemplo, en un archivo de registro)
                MessageBox.Show("Error al actualizar ubicacion, " + ex, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnGuardarUbicacion_Click(object sender, EventArgs e)
        {
            string mensajeError = ValidarEntradaUbicacion();
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!GuardarUbicacion())
            {
                MessageBox.Show("Error al guardar la ubicación.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimpiarU();
            CargarDatosUGrid();
            CargarComboUbicacion();
            BotonesCamposU(true, false, false, false, false, true);
        }
        private string ValidarEntradaUbicacion()
        {
            if (string.IsNullOrEmpty(txtUbicacion.Text))
            {
                return "El campo Ubicación es requerido.";
            }
            return null; // Sin errores
        }

        private bool GuardarUbicacion()
        {
            try
            {
                string ubicacion = txtUbicacion.Text;
                Ubicacion ub = new Ubicacion()
                {
                    UbicacionN = ubicacion,
                };
                return ubserv.GuardarUbicacion(ub);
            }
            catch (Exception ex)
            {
                // Registra el error (por ejemplo, en un archivo de registro)
                MessageBox.Show("Error al guardar ubicacion, " + ex, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
