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
    public partial class CadastroTalents : Form
    {
        MySQL instanciaMySql = new MySQL();
        string sql;
        public CadastroTalents()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (string.IsNullOrEmpty(txtId.Text))
                    InserirDados();
                else
                    AlterarDados();

          
        }

        private void InserirDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                int quatro = 0;
                int quatroaseis = 0;
                int seisaoito = 0;
                int acimaoito = 0;
                int finaisSemana = 0;
                int manha = 0;
                int tarde = 0;
                int noite = 0;
                int madrugada = 0;
                int comercial = 0;

                if (chkQuatro.Checked)
                {
                    quatro = 1;
                }
                if (chkQuatroaSeis.Checked)
                {
                    quatroaseis = 1;
                }
                if (chkSeisaOito.Checked)
                {
                    seisaoito = 1;
                }
                if (chkAcimaOito.Checked)
                {
                    acimaoito = 1;
                }
                if (chkFinaisSemana.Checked)
                {
                    finaisSemana = 1;
                }


                if (chkManha.Checked)
                {
                    manha = 1;
                }
                if (chkTarde.Checked)
                {
                    tarde = 1;
                }
                if (chkNoite.Checked)
                {
                    noite = 1;
                }
                if (chkMadrugada.Checked)
                {
                    madrugada = 1;
                }
                if (chkComercial.Checked)
                {
                    comercial = 1;
                }



                sql = "INSERT INTO Talents VALUES " +
                    "(null, ?,?,?,?,?,?,?,?,?,?," +
                    "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                    "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                    "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("telefone", txtFone.Text);
                cmd.Parameters.AddWithValue("linkedin", txtLinkedin.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("portfolio", txtPortfolio.Text);
                cmd.Parameters.AddWithValue("pretencao_salarial", txtSalario.Text);

                cmd.Parameters.AddWithValue("quatro", quatro.ToString());
                cmd.Parameters.AddWithValue("quatroaseis", quatroaseis.ToString());
                cmd.Parameters.AddWithValue("seisaoitro", seisaoito.ToString());
                cmd.Parameters.AddWithValue("acimaoito", acimaoito.ToString());
                cmd.Parameters.AddWithValue("finaisSemana", finaisSemana.ToString());

                cmd.Parameters.AddWithValue("manha", manha.ToString());
                cmd.Parameters.AddWithValue("tarde", tarde.ToString());
                cmd.Parameters.AddWithValue("noite", noite.ToString());
                cmd.Parameters.AddWithValue("madrugada", madrugada.ToString());
                cmd.Parameters.AddWithValue("comercial", comercial.ToString());
                
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
                cmd.Parameters.AddWithValue("python", python.Text);
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
                cmd.Parameters.AddWithValue("laravel", laravel.Text);
                cmd.Parameters.AddWithValue("seo", seo.Text);
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


        private void AlterarDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "UPDATE Talents " +
                    " SET email=@email," +
                    " nome=@nome," +
                    " telefone=@telefone," +
                    " linkedin=@linkedin," +
                    " cidade=@cidade," +
                    " estado=@estado," +
                    " portfolio=@portfolio," +
                    " pretencao_salarial=@pretencao_salarial," +
                    " quatro=@quatro," +
                    " quatroaseis=@quatroaseis," +
                    " seisaoito=@seisaoito," +
                    " acimaoito=@acimaoito," +
                    " finaisSemana=@finaisSemana," +
                    " manha=@manha," +
                    " tarde=@tarde," +
                    " noite=@noite," +
                    " madrugada=@madrugada," +
                    " comercial=@comercial," +
                    " ionic=@ionic," +
                    " reactjs=@reactjs," +
                    " reactnative=@reactnative," +
                    " android=@android," +
                    " flutter=@flutter," +
                    " swift=@swift," +
                    " ios=@ios," +
                    " html=@html," +
                    " css=@css," +
                    " bootstrap=@bootstrap," +
                    " jquery=@jquery," +
                    " angularjs=@angularjs," +
                    " angular=@angular," +
                    " java=@java," +
                    " python=@python," +
                    " flask=@flask," +
                    " aspnetmvc=@aspnetmvc," +
                    " aspnetwf=@aspnetwf," +
                    " c=@c," +
                    " csharp=@csharp," +
                    " nodejs=@nodejs," +
                    " expnodejs=@expnodejs," +
                    " cake=@cake," +
                    " django=@django," +
                    " majento=@majento," +
                    " php=@php," +
                    " vue=@vue," +
                    " wordpress=@wordpress," +
                    " ruby=@ruby," +
                    " mysqlserv=@mysqlserv," +
                    " mysql=@mysql," +
                    " salesforce=@salesforce," +
                    " photoshop=@photoshop," +
                    " illustrator=@illustrator," +
                    " laravel=@laravel," +
                    " seo=@seo," +
                    " outras=@outras" +
                    " WHERE id=@id";

                int quatro = 0;
                int quatroaseis = 0;
                int seisaoito = 0;
                int acimaoito = 0;
                int finaisSemana = 0;
                int manha = 0;
                int tarde = 0;
                int noite = 0;
                int madrugada = 0;
                int comercial = 0;

                if (chkQuatro.Checked)
                {
                    quatro = 1;
                }
                if (chkQuatroaSeis.Checked)
                {
                    quatroaseis = 1;
                }
                if (chkSeisaOito.Checked)
                {
                    seisaoito = 1;
                }
                if (chkAcimaOito.Checked)
                {
                    acimaoito = 1;
                }
                if (chkFinaisSemana.Checked)
                {
                    finaisSemana = 1;
                }


                if (chkManha.Checked)
                {
                    manha = 1;
                }
                if (chkTarde.Checked)
                {
                    tarde = 1;
                }
                if (chkNoite.Checked)
                {
                    noite = 1;
                }
                if (chkMadrugada.Checked)
                {
                    madrugada = 1;
                }
                if (chkComercial.Checked)
                {
                    comercial = 1;
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", txtId.Text);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("telefone", txtFone.Text);
                cmd.Parameters.AddWithValue("linkedin", txtLinkedin.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("portfolio", txtPortfolio.Text);
                cmd.Parameters.AddWithValue("pretencao_salarial", txtSalario.Text);

                cmd.Parameters.AddWithValue("quatro", quatro.ToString());
                cmd.Parameters.AddWithValue("quatroaseis", quatroaseis.ToString());
                cmd.Parameters.AddWithValue("seisaoito", seisaoito.ToString());
                cmd.Parameters.AddWithValue("acimaoito", acimaoito.ToString());
                cmd.Parameters.AddWithValue("finaisSemana", finaisSemana.ToString());

                cmd.Parameters.AddWithValue("manha", manha.ToString());
                cmd.Parameters.AddWithValue("tarde", tarde.ToString());
                cmd.Parameters.AddWithValue("noite", noite.ToString());
                cmd.Parameters.AddWithValue("madrugada", madrugada.ToString());
                cmd.Parameters.AddWithValue("comercial", comercial.ToString());

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
                cmd.Parameters.AddWithValue("python", python.Text);
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
                cmd.Parameters.AddWithValue("laravel", laravel.Text);
                cmd.Parameters.AddWithValue("seo", seo.Text);
                cmd.Parameters.AddWithValue("outras", outras.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro alterado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CadastroTalents_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                MySqlConnection conn = instanciaMySql.GetConnection();
                int quatro = 0;
                int quatroaseis = 0;
                int seisaoito = 0;
                int acimaoito = 0;
                int finaisSemana = 0;
                int manha = 0;
                int tarde = 0;
                int noite = 0;
                int madrugada = 0;
                int comercial = 0;

               
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    sql = "select *from Talents " +
                        $" where id= {txtId.Text}";
                       

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader leitor = cmd.ExecuteReader();
                    if(leitor.HasRows)
                    {
                    leitor.Read();
                        txtSalario.Text = leitor["pretencao_salarial"].ToString();
                        quatro = Convert.ToInt32(leitor["quatro"].ToString());
                        quatroaseis = Convert.ToInt32(leitor["quatroaseis"].ToString());                      
                        seisaoito = Convert.ToInt32(leitor["seisaoito"].ToString());
                        acimaoito = Convert.ToInt32(leitor["acimaoito"].ToString());
                        finaisSemana = Convert.ToInt32(leitor["finaisSemana"].ToString());
                        manha = Convert.ToInt32(leitor["manha"].ToString());
                        tarde = Convert.ToInt32(leitor["tarde"].ToString());
                        noite = Convert.ToInt32(leitor["noite"].ToString());
                        madrugada = Convert.ToInt32(leitor["madrugada"].ToString());
                        comercial = Convert.ToInt32(leitor["comercial"].ToString());

                        if (quatro == 1)
                        {
                            chkQuatro.Checked = true;
                        }
                        if (quatroaseis == 1)
                        {
                            chkQuatroaSeis.Checked = true;
                        }
                        if (seisaoito == 1)
                        {
                            chkSeisaOito.Checked = true;
                        }
                        if (acimaoito == 1)
                        {
                            chkAcimaOito.Checked = true;
                        }
                        if (finaisSemana == 1)
                        {
                            chkFinaisSemana.Checked = true;
                        }

                        if (manha == 1)
                        {
                            chkManha.Checked = true;
                        }
                        if (tarde == 1)
                        {
                            chkTarde.Checked = true;
                        }
                        if (noite == 1)
                        {
                            chkNoite.Checked = true;
                        }
                        if (madrugada == 1)
                        {
                            chkMadrugada.Checked = true;
                        }
                        if (comercial == 1)
                        {
                            chkComercial.Checked = true;
                        }

                        ionic.Text = leitor["ionic"].ToString();
                        reactjs.Text = leitor["reactjs"].ToString();
                        reactnative.Text = leitor["reactnative"].ToString();
                        android.Text = leitor["android"].ToString();
                        flutter.Text = leitor["flutter"].ToString();
                        swift.Text = leitor["swift"].ToString();
                        ios.Text = leitor["ios"].ToString();
                        html.Text = leitor["html"].ToString();
                        css.Text = leitor["css"].ToString();
                        bootstrap.Text = leitor["bootstrap"].ToString();
                        jquery.Text = leitor["jquery"].ToString();
                        angularjs.Text = leitor["angularjs"].ToString();
                        angular.Text = leitor["angular"].ToString();
                        java.Text = leitor["java"].ToString();
                        python.Text = leitor["python"].ToString();
                        flask.Text = leitor["flask"].ToString();
                        aspnetmvc.Text = leitor["aspnetmvc"].ToString();
                        aspnetwf.Text = leitor["aspnetwf"].ToString();
                        c.Text = leitor["c"].ToString();
                        csharp.Text = leitor["csharp"].ToString();
                        nodejs.Text = leitor["nodejs"].ToString();
                        expnodejs.Text = leitor["expnodejs"].ToString();
                        cake.Text = leitor["cake"].ToString();
                        django.Text = leitor["django"].ToString();
                        majento.Text = leitor["majento"].ToString();
                        php.Text = leitor["php"].ToString();
                        vue.Text = leitor["vue"].ToString();
                        wordpress.Text = leitor["wordpress"].ToString();
                        ruby.Text = leitor["ruby"].ToString();
                        mysqlserv.Text = leitor["mysqlserv"].ToString();
                        mysql.Text = leitor["mysql"].ToString();
                        salesforce.Text = leitor["salesforce"].ToString();
                        photoshop.Text = leitor["photoshop"].ToString();
                        illustrator.Text = leitor["illustrator"].ToString();
                        outras.Text = leitor["outras"].ToString();
                        laravel.Text = leitor["laravel"].ToString();
                        seo.Text = leitor["seo"].ToString();

                    }

                    if (leitor != null)
                    leitor.Close(); 
                    
                

                   
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
}
