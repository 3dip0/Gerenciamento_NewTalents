using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento_NewTalents
{
    public partial class NewTalent : Form
    {
        MySQL instanciaMySql = new MySQL();
        string sql;
        public NewTalent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InserirDados();
        }

        private void InserirDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Talents VALUES (null, ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("telefone", txtFone.Text);
                cmd.Parameters.AddWithValue("linkedin", txtLinkedin.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("portfolio", txtPortfolio.Text);
                cmd.Parameters.AddWithValue("pretencao_salarial", txtSalario.Text);
                cmd.Parameters.AddWithValue("disponibilidade_hora", chkDisponibilidade_hora.Text);
                cmd.Parameters.AddWithValue("preferencia_horario", chkPreferencia_horario.Text);
                cmd.Parameters.AddWithValue("ionic", ionic.Text);
                cmd.Parameters.AddWithValue("reactjs", reactjs.Text);
                cmd.Parameters.AddWithValue("reactnative", reactnative.Text);
                cmd.Parameters.AddWithValue("android", android.Text);
                cmd.Parameters.AddWithValue("flutter", flutter.Text);
                cmd.Parameters.AddWithValue("swift", swift.Text);
                cmd.Parameters.AddWithValue("ios", ios.Text);
                cmd.Parameters.AddWithValue("html", html.Text);
                cmd.Parameters.AddWithValue("css", css.Text);
                cmd.Parameters.AddWithValue("bootstrap", bootstrap.Text);
                cmd.Parameters.AddWithValue("jquery", jquery.Text);
                cmd.Parameters.AddWithValue("angularjs", angularjs.Text);
                cmd.Parameters.AddWithValue("angular", angular.Text);
                cmd.Parameters.AddWithValue("java", java.Text);
                cmd.Parameters.AddWithValue("phyton", phyton.Text);
                cmd.Parameters.AddWithValue("flask", flask.Text);
                cmd.Parameters.AddWithValue("aspnetmvc", aspnetmvc.Text);
                cmd.Parameters.AddWithValue("aspnetwf", aspnetwf.Text);
                cmd.Parameters.AddWithValue("c", c.Text);
                cmd.Parameters.AddWithValue("csharp", csharp.Text);
                cmd.Parameters.AddWithValue("nodejs", nodejs.Text);
                cmd.Parameters.AddWithValue("expnodejs", expnodejs.Text);
                cmd.Parameters.AddWithValue("cake", cake.Text);
                cmd.Parameters.AddWithValue("django", django.Text);
                cmd.Parameters.AddWithValue("majento", majento.Text);
                cmd.Parameters.AddWithValue("php", php.Text);
                cmd.Parameters.AddWithValue("vue", vue.Text);
                cmd.Parameters.AddWithValue("wordpress", wordpress.Text);
                cmd.Parameters.AddWithValue("ruby", ruby.Text);
                cmd.Parameters.AddWithValue("mysqlserv", mysqlserv.Text);
                cmd.Parameters.AddWithValue("mysql", mysql.Text);
                cmd.Parameters.AddWithValue("salesforce", salesforce.Text);
                cmd.Parameters.AddWithValue("photoshop", photoshop.Text);
                cmd.Parameters.AddWithValue("illustrator", illustrator.Text);
                cmd.Parameters.AddWithValue("outras", outras.Text);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
