using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clases
{
    public class Operaciones: Conexion
    {
        private Conexion conexion = new Conexion();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leerFilas;
        public int Acceso;
        public static Object rol, id, nombre, correo, telefono, sexo, edad, cod, fecha, examen,Facnum;
        
        //Esta Funcion Valida que el Usuario existe
        public bool Login(string usuario, string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Usuarios WHERE UserName='{0}' AND Password='{1}'", usuario, password),cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Bienvenido", "Autenticacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rol = dt.Rows[0][3];
                    return true;
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña es Incorrecta");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        //---Doctores---

        //Esta Funcion Sirve para ingresar un nuevo doctor
        public void IngresarDoctor(String identidad, String nombre, int telefono, String email, String clinica)
        {
            Operaciones proc = new Operaciones();
            int Consultar = proc.Verificar_ExistenciaD(identidad);
            if (Consultar == 1)
            {
                MessageBox.Show("Doctor ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarMedicos] @identidadMed = '{0}', @NombreMe = '{1}', @TelefonoMe = '{2}', @EmailMe = '{3}', @NombreClinicaMe = '{4}' ,@EstadoMe=1", identidad, nombre, telefono, email, clinica), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se Inserto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Esta Funcion Sirve para mostrar la lista de doctores
        public DataTable MostrarDoctor()
        {
            SqlCommand comando = new SqlCommand("select IdentidadMe as 'Identidad',NombreMe as 'Nombre del Medico', TelefonoMe as 'Telefono', EmailMe as 'E-mail',NombreClinicaMe as 'Clinica' from Medicos Where EstadoMe = 1 ", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            return tabla;
        }

        //Esta funcion sirve para Editar un doctor
        public void EditarDoctor(String identidad, String nombre, int telefono, String email, String clinica)
        {
            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[ActualizarMedico] @identidadMed = '{0}', @NombreMe = '{1}', @TelefonoMe = {2}, @EmailMe = '{3}', @NombreClinicaMe = '{4}',@EstadoMe=1", identidad, nombre, telefono, email, clinica), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Edito Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Esta funcion sirve para Eliminar un doctor
        public void EliminarDoctor(String id)
        {
            
            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[EliminarMedico] @EstadoMe = 0,@IdentidadMed='{0}'",id), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Elimino Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DataTable cbMedFac()
        {

            SqlCommand comando = new SqlCommand("Select IdentidadMe from Medicos where EstadoMe = 1", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);


            return tabla;


        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        //---Pacientes---

        public void IngresarPaciente(String identidad, String nombre,  String email, int telefono,int sexo, DateTime fechanac)
        {
            Operaciones proc = new Operaciones();
            int Consultar = proc.Verificar_ExistenciaP(identidad);
            if (Consultar == 1)
            {
                MessageBox.Show("Paciente ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarPaciente] @identidadPa = '{0}', @NombrePa = '{1}', @EmailPa = '{2}', @TelefonoPa = '{3}', @SexoPa ='{4}', @FechaNacPa='{5}', @EstadoPa = 1", identidad, nombre, email, telefono, sexo, fechanac.ToString("dd-MM-yyyy hh:m:s")), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se Inserto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public DataTable MostrarPaciente()
        {
            SqlCommand comando = new SqlCommand("select IdentidadPa as 'Identidad',NombrePa as 'Nombre del Paciente',  EmailPa as 'E-mail',TelefonoPa as 'Telefono',Cast(SexoPa as varchar) as 'Sexo',FechaNacPa as 'Fecha De Nacimiento' from Pacientes Where EstadoPa = 1 ", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            

            return tabla;
        }

        public void EditarPaciente(String identidad, String nombre, String email, int telefono, int sexo, DateTime fechanac)
        {
            SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[ActualizarPacientee] @identidadPa = '{0}', @NombrePa = '{1}', @EmailPa = '{2}', @TelefonoPa = '{3}', @SexoPa ='{4}', @FechaNacPa='{5}', @EstadoPa = 1", identidad, nombre, email, telefono, sexo, fechanac), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Actualizo Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarPaciente(String id)
        {

            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[EliminarPaciente] @EstadoPa = 0,@IdentidadPa='{0}'", id), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Elimino Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool cargarpacfac(String ide)
        {
            SqlCommand comando = new SqlCommand("select * from Pacientes where Identidadpa = '" + ide + "' ", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            if (tabla.Rows.Count == 1)
            {
                
                id = tabla.Rows[0][0];
                nombre = tabla.Rows[0][1];
                correo = tabla.Rows[0][2];
                telefono = tabla.Rows[0][3];
                sexo = tabla.Rows[0][4];
                edad = tabla.Rows[0][5];
                
                return true;
            }
           
            return false;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        //Usuarios

        public DataTable MostrarUsuario()
        {
            SqlCommand comando = new SqlCommand("select UserName as 'Usuario',Password as 'Contraseña',cast(Estado as int) as 'Estado',B.DescripRol as 'Rol',EmailUsu as 'E-mail' from Usuarios as A Join Rol as B On A.IdRol = B.IdRol Where Estado = 1 ", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);



            return tabla;
        }

        public void IngresarUsuario(String usuario, String pass, int rol, String email)
        {
            Operaciones proc = new Operaciones();
            int Consultar = proc.Verificar_Existencia(usuario);
            if (Consultar == 1)
            {
                MessageBox.Show("Usuario ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarUsuarios] @UserName = '{0}', @Password = '{1}', @Estado = 1, @IdRol = '{2}', @EmailUsu ='{3}'", usuario, pass, rol, email), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se Inserto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void EditarUsuario(String user, String pass, int rol, String email)
        {
            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[ActualizarUsuarios]  @UserName = '{0}', @Password = '{1}', @Estado = 1, @IdRol = '{2}', @EmailUsu = '{3}'", user,pass,rol,email), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Edito Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarUsuario(String user)
        {

            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[EliminarUsuario] @Estado = 0,@UserName='{0}'", user), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Elimino Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------

        //Bitacora

        public DataTable MostrarBitacora()
        {
            SqlCommand comando = new SqlCommand("select IdBit,UserName as 'Usuario',Descripcion,Fecha from Bitacora", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);



            return tabla;
        }

        public void IngresarBitacora(String usuario,int ac)
        {
            string descrip="";

            if (ac == 1)
            {
                descrip = "Se ha loggueado";
            }
            else if (ac == 2)
            {
                descrip = "Ha Insertado Un Registro";
            }
            else if (ac == 3)
            {
                descrip = "Ha Modificado Un Registro";
            }
            else if (ac ==4)
            {
                descrip = "Ha Eliminado Un Registro";
            }
            SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarBitacora] @UserName = '{0}',  @Descripcion = '{1}', @Fecha = '{2}'", usuario,descrip,DateTime.Now.ToString("dd-MM-yyyy hh:m:s")), cn);
            cmd.ExecuteNonQuery();
            
        }

 
        //-----------------------------------------------------------------------------------------------------------------------------------

        //Examenes

        public DataTable MostrarExamenes()
        {
            SqlCommand comando = new SqlCommand("select IdExamen,NombreExamen as 'Nombre Examen',cast(EstadoExamen as int) as 'Estado',PrecioExamen as 'Precio', RangoExamen as 'Rango' from Examenes Where EstadoExamen = 1 ", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);



            return tabla;
        }

        public void IngresarExamen(String nombre, String rango, decimal precio)
        {
            Operaciones proc = new Operaciones();
            int Consultar = proc.Verificar_ExistenciaE(nombre);
            if (Consultar == 1)
            {
                MessageBox.Show("Tipo de examen ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarExamen] @NombreExamen = '{0}', @EstadoExamen = 1, @PrecioExamen = '{1}', @RangoExamen = '{2}'", nombre, precio, rango), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se Inserto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void EditarExamen(String nombre, String rango, Decimal precio, int id)
        {
            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[ActualizarExamen]  @IdExamen = '{0}', @NombreExamen = '{1}', @EstadoExamen = 1, @PrecioExamen = '{2}', @RangoExamen = '{3}'", id,nombre,precio,rango), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Edito Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarExamen(int id)
        {

            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[EliminarExamen] @EstadoExamen = 0,@IdExamen='{0}'", id), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Elimino Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------

        //CAI

        public DataTable MostrarCai()
        {
            SqlCommand comando = new SqlCommand("select CaiNum as 'Numero CAI',RangoInicial as 'Rango Inicial', RangoFinal as 'Rango Final', FechaLimite as 'Fecha Limite' from Cai Where EstadoCai = 1 ", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);



            return tabla;
        }

        public void IngresarCai(String num, String rangoa,String rangof, DateTime fechalim)
        {
            SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarCai] @CaiNum = '{0}',@RangoInicial = '{1}',@RangoFinal = '{2}',@FechaLimite = '{3}',@EstadoCai=1", num,rangoa,rangof,fechalim.ToString("dd-MM-yyyy hh:m:s")), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Inserto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EditarCai(String cainum, String rangoI,String rangoF,DateTime fecha)
        {
            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[ActualizarCai]  @CaiNum = '{0}', @RangoInicial = '{1}', @RangoFinal = '{2}', @FechaLimite = '{3}', @EstadoCai = 1'", cainum,rangoI,rangoF,fecha.ToString("MM-dd-yyyy hh:m:s")), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Edito Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarCai(String numcai)
        {

            SqlCommand cmd = new SqlCommand(string.Format("execute [dbo].[EliminarCai] @EstadoCai = 0,@CaiNum='{0}'", numcai), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Elimino Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DataTable cbCaiFac()
        {
          
            SqlCommand comando = new SqlCommand("Select CaiNum from Cai where EstadoCai = 1", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
           

            return tabla;


        }

        //----------------------------------------------------------------------------------------------------------------------------------------

        //Factura

        public void IngresarFactura(String FacNum, String idpa,int factipo,float facdesc,String facCai, String idme,int []v,Double[] p)
         {
             SqlCommand cmd = new SqlCommand(String.Format("execute [dbo].[IngresarFactura] @FacNum = '{0}',@IdentidadPa = '{1}',@FacFecha = '{2}',@FacTipo = '{3}',@FacDesc='{4}',@FacEstado=0,@FacCai='{5}',@IdentidadMe='{6}'",FacNum,idpa, DateTime.Now.ToString("MM-dd-yyyy hh:m:s"),factipo,facdesc,facCai,idme), cn);
             cmd.ExecuteNonQuery();
             MessageBox.Show("Se Inserto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int codex;
            Double precio;
            for (int i = 0; i < 99; i++)
            {
                codex = v[i];
                precio = p[i];
                if (codex != 0)
                {
                    SqlCommand cmd2 = new SqlCommand(String.Format("execute [dbo].[IngresarFacturaDetalle] @FacNum = '{0}',@IdExamen = '{1}',@Resultado = '',@FacEstadoDe = 0,@PrecioExamen='{2}'", FacNum,codex,precio), cn);
                    cmd2.ExecuteNonQuery();
                }
            }
         }

        public string  numfac()
        {
            SqlCommand comando = new SqlCommand("select top (1) * from Factura where FacFecha <= getdate()", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            if (tabla.Rows.Count == 0)
            {
                SqlCommand cmd = new SqlCommand("select top (1) * from Cai", cn);
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                DataTable Num = new DataTable();
                adap.Fill(Num);

                Facnum = Num.Rows[0][1];
                
            }
            else
            {
                Facnum = tabla.Rows[0][0];
            }

            return Facnum.ToString();
        }

        //Resultados

        public DataTable MostrarFacturasResult()
        {
            SqlCommand comando = new SqlCommand("SELECT dbo.FacturaDetalle.iddetalle,dbo.Factura.FacNum, dbo.Examenes.NombreExamen, dbo.Factura.FacEstado, dbo.Factura.FacFecha, dbo.FacturaDetalle.Resultado FROM     dbo.Factura INNER JOIN dbo.FacturaDetalle ON dbo.Factura.FacNum = dbo.FacturaDetalle.FacNum INNER JOIN dbo.Examenes ON dbo.FacturaDetalle.IdExamen = dbo.Examenes.IdExamen", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);



            return tabla;
        }

        public void EditarResult(string result, int cod)
        {
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE[dbo].[FacturaDetalle] SET [Resultado] = '{0}' WHERE iddetalle = {1}", result,cod), cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se Ingreso Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        //-----//VALIDACIONES-------


        //funcion para veridicar la extencia de un alumno
        public int Verificar_Existencia(String filtro)
        {
            int Resultado = 0;
            comando.Connection = cn;
            comando.CommandText = "Verificar_Existencia_ID_Usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@filtro", filtro);
            leerFilas = comando.ExecuteReader();
            if (leerFilas.Read())
            {
                Resultado = 1;
            }
            else
            {
                Resultado = 0;
            }
            leerFilas.Close();
            comando.Parameters.Clear();

            return Resultado;

        }

        //funcion para veridicar la extencia de un Paciente
        public int Verificar_ExistenciaP(String filtro)
        {
            int Resultado = 0;
            comando.Connection = cn;
            comando.CommandText = "Verificar_Existencia_ID_Paciente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@filtro", filtro);
            leerFilas = comando.ExecuteReader();
            if (leerFilas.Read())
            {
                Resultado = 1;
            }
            else
            {
                Resultado = 0;
            }
            leerFilas.Close();
            comando.Parameters.Clear();

            return Resultado;

        }

        //funcion para veridicar la extencia de un Doctor
        public int Verificar_ExistenciaD(String filtro)
        {
            int Resultado = 0;
            comando.Connection = cn;
            comando.CommandText = "Verificar_Existencia_ID_Doctor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@filtro", filtro);
            leerFilas = comando.ExecuteReader();
            if (leerFilas.Read())
            {
                Resultado = 1;
            }
            else
            {
                Resultado = 0;
            }
            leerFilas.Close();
            comando.Parameters.Clear();

            return Resultado;

        }

        //funcion para veridicar la extencia de un examen
        public int Verificar_ExistenciaE(String filtro)
        {
            int Resultado = 0;
            comando.Connection = cn;
            comando.CommandText = "Verificar_Existencia_ID_Examen";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@filtro", filtro);
            leerFilas = comando.ExecuteReader();
            if (leerFilas.Read())
            {
                Resultado = 1;
            }
            else
            {
                Resultado = 0;
            }
            leerFilas.Close();
            comando.Parameters.Clear();

            return Resultado;

        }




    }
}
