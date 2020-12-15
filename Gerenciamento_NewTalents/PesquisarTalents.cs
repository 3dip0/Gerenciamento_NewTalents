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
    public partial class PesquisarTalents : Form
    {
        public PesquisarTalents()
        {
            InitializeComponent();
        }

        MySQL instanciaMySql = new MySQL();
        string sql;

        private void PesquisarTalents_Load(object sender, EventArgs e)
        {
            CarregarDados();
            PreencherComboBoxPesquisa();
        }
        private void CarregarDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT id AS ID," +
                    " email AS \"E-Mail\"," +
                    " nome AS \"Nome\"," +
                    " telefone AS \"Telefone\"," +
                    " linkedin AS \"Linkedin\"," +
                    " cidade AS \"Cidade\"," +
                    " estado AS \"Estado\"," +
                    " portfolio AS \"Portfolio\" " +
                    " FROM Talents";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTalents.DataSource = dt;
                
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

        private void ExcluirDados(int id)
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "DELETE FROM Talents WHERE id=@id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Talent excluído com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void PreencherComboBoxPesquisa()
        {
            foreach (DataGridViewColumn coluna in dgvTalents.Columns)
            {
                cbPesquisar.Items.Add(coluna.HeaderText);
            }
        }

        private void dgvTalents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CadastroTalents cadastroTalents = new CadastroTalents();
            
            
            cadastroTalents.txtId.Text = dgvTalents.SelectedCells[0].Value.ToString();
            cadastroTalents.txtEmail.Text = dgvTalents.SelectedCells[1].Value.ToString();
            cadastroTalents.txtNome.Text = dgvTalents.SelectedCells[2].Value.ToString();
            cadastroTalents.txtFone.Text = dgvTalents.SelectedCells[3].Value.ToString();
            cadastroTalents.txtLinkedin.Text = dgvTalents.SelectedCells[4].Value.ToString();
            cadastroTalents.txtCidade.Text = dgvTalents.SelectedCells[5].Value.ToString();
            cadastroTalents.txtEstado.Text = dgvTalents.SelectedCells[6].Value.ToString();
            cadastroTalents.txtPortfolio.Text = dgvTalents.SelectedCells[7].Value.ToString();
            
            cadastroTalents.ShowDialog();

            CarregarDados();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            (dgvTalents.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);

        }

      

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvTalents.SelectedRows.Count > 0)
            {
                
                    int id = (int)dgvTalents.SelectedCells[0].Value;
                    string talent = dgvTalents.SelectedCells[2].Value.ToString();

                    if (MessageBox.Show($"Confirma a exclusão do talent: {id} - {talent}?",
                        "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        ExcluirDados(id);
                        CarregarDados();

                    }
                
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CadastroTalents cadastroTalents = new CadastroTalents();


            cadastroTalents.txtId.Text = dgvTalents.SelectedCells[0].Value.ToString();
            cadastroTalents.txtEmail.Text = dgvTalents.SelectedCells[1].Value.ToString();
            cadastroTalents.txtNome.Text = dgvTalents.SelectedCells[2].Value.ToString();
            cadastroTalents.txtFone.Text = dgvTalents.SelectedCells[3].Value.ToString();
            cadastroTalents.txtLinkedin.Text = dgvTalents.SelectedCells[4].Value.ToString();
            cadastroTalents.txtCidade.Text = dgvTalents.SelectedCells[5].Value.ToString();
            cadastroTalents.txtEstado.Text = dgvTalents.SelectedCells[6].Value.ToString();
            cadastroTalents.txtPortfolio.Text = dgvTalents.SelectedCells[7].Value.ToString();

            cadastroTalents.ShowDialog();

            CarregarDados();
        }
    }
}
