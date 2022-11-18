using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Controls;
using System.Data.SqlClient;

namespace clienteC
{
    public partial class funcionario : UserControl
    {
        public funcionario()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-T3ACV1N\SQLEXPRESS;Initial Catalog=cliente;User ID=sa; password=leo123");


        SqlCommand cm = new SqlCommand();



        SqlDataReader dt;

        

        private void HabilitaCamposF()
        {
            txtNomeF.Enabled = true;
            txtTelefoneF.Enabled = true;
            txtCpfF.Enabled = true;
            txtEnderecoF.Enabled = true;
            editarFunc.Enabled = true;
            novoFunc.Enabled = true;
            removerFunc.Enabled = true;
            novoFunc.Enabled = false;
            cancelarFunc.Enabled = true;
            salvarFunc.Enabled = true;
            txtNomeF.Focus();
            buscaF.Text = "";
            //dgvF.DataSource = null;
        }

        private void LimparCamposF()
        {
            txtNomeF.Clear();
            txtTelefoneF.Clear();
            txtCpfF.Clear();
            txtEnderecoF.Clear();
            txtNomeF.Focus();

        }

        private void manipularDadosF()
        {
            editarFunc.Enabled = true;
            cancelarFunc.Enabled = true;
            removerFunc.Enabled = true;
            novoFunc.Enabled = false;
            salvarFunc.Enabled = false;
            txtNomeF.Enabled = true;
            txtTelefoneF.Enabled = true;
            txtCpfF.Enabled = true;
            txtEnderecoF.Enabled = true;

        }


        private void DesabilitaCamposF()
        {
            txtNomeF.Enabled = false;
            txtTelefoneF.Enabled = false;
            txtCpfF.Enabled = false;
            txtEnderecoF.Enabled = false;
            editarFunc.Enabled = false;
            novoFunc.Enabled = false;
            removerFunc.Enabled = false;
            novoFunc.Enabled = true;
            cancelarFunc.Enabled = false;
            salvarFunc.Enabled = false;
        }



        private void MostrarTodosFuncionarios()
        {
            try
            {
                cn.Open();
                cm.CommandText = "select funcionarios.id, nome, funcionarios.endereco, funcionarios.cpf, funcionarios.telefone, sum(valortotal) as valortotal, salario = case when sum(valortotal) <= 10000 then salario +(salario * 0.05) when sum(valortotal) > 10000 then salario +(salario * 0.07) else salario end from compra, funcionarios where compra.idfuncionarios = funcionarios.id group by funcionarios.id, nome, endereco,cpf,telefone, salario,valortotal"; ;
                cm.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter();


                DataTable dt = new DataTable();

                da.SelectCommand = cm;
                da.Fill(dt);
                dgvF.DataSource = dt;
                cn.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void novoFunc_Click(object sender, EventArgs e)
        {
            HabilitaCamposF();
        }

        private void removerFunc_Click(object sender, EventArgs e)
        {
            if (txtNomeF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeF.Focus();
            }
            else if (txtEnderecoF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo endereço. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEnderecoF.Focus();
            }
            else if (txtTelefoneF.Text.Length < 13)
            {
                MessageBox.Show("O número de Telefone está errado, Porfavor informar os 14 digitos. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefoneF.Focus();
            }
            else if (txtCpfF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CPF. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfF.Focus();
            }
            else if (txtCpfF.Text.Length < 12)
            {
                MessageBox.Show("O CPF está errado, Porfavor informar os 12 digitos. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfF.Focus();
            }
            else
            {
                DialogResult exclusao = MessageBox.Show("Você tem certeza que deseja remover esse registro?", "Exclusão de Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (exclusao == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        cn.Open();
                        string id = dgvF.SelectedRows[0].Cells[0].Value.ToString();
                        cm.Connection = cn;
                        cm.CommandText = "SELECT CASE WHEN EXISTS(SELECT * FROM[compra] WHERE idfuncionarios = " + id + ") THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";

                        cm.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter();
                        var ds = new DataSet();
                        da.SelectCommand = cm;
                        da.Fill(ds);
                        DataTable dtDatabases = ds.Tables[0];
                        cn.Close();

                        if (ds.Tables[0].Rows[0][0].ToString() == "True")
                        {
                            DialogResult existeCompraAv = MessageBox.Show("Não foi possivel remover funcionario pois eles está associado a uma compra", "Exclusão de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (existeCompraAv == DialogResult.OK)
                            {
                                return;
                            }
                        }
                        else 
                        {
                            cn.Open();
                            string strSql = "delete from funcionarios where id=@id";
                            cm.CommandText = strSql;
                            cm.Connection = cn;
                            cm.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;


                            cm.ExecuteNonQuery();
                            cm.Parameters.Clear();
                            LimparCamposF();
                            MessageBox.Show("Os dados foram removidos com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                        cn.Close();
                    }
                    finally
                    {
                        cn.Close();
                        MostrarTodosFuncionarios();
                    }
                }
            }
        }



        private void editarFunc_Click(object sender, EventArgs e)
        {
            if (txtNomeF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeF.Focus();
            }
            else if (txtEnderecoF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo endereço. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEnderecoF.Focus();
            }
            else if (txtTelefoneF.Text.Length < 14)
            {
                MessageBox.Show("O número de Telefone está errado, Porfavor informar os 14 digitos. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefoneF.Focus();
            }
            else if (txtCpfF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CPF. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfF.Focus();
            }
            else if (txtCpfF.Text.Length < 12)
            {
                MessageBox.Show("O CPF está errado, Porfavor informar os 12 digitos. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfF.Focus();
            }

            else
            {
                try
                {
                    string nome = txtNomeF.Text;
                    string telefone = txtTelefoneF.Text;
                    string cpf = txtCpfF.Text;
                    string endereco = txtEnderecoF.Text;
                    string id = dgvF.SelectedRows[0].Cells[0].Value.ToString();


                    string strSql = "update funcionarios set nome=@nome, telefone=@telefone, cpf=@cpf, endereco=@endereco where id=@id ";

                    cm.CommandText = strSql;
                    cm.Connection = cn;

                    cm.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                    cm.Parameters.Add("@nome", System.Data.SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@telefone", System.Data.SqlDbType.VarChar).Value = telefone;
                    cm.Parameters.Add("@cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                    cm.Parameters.Add("@endereco", System.Data.SqlDbType.VarChar).Value = endereco;


                    cn.Open();
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();
                    LimparCamposF();
                    MessageBox.Show("Os dados foram alterados com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    cn.Close();
                }

                finally
                {
                    cn.Close();
                    MostrarTodosFuncionarios();
                }

            }
        }

        private void cancelarFunc_Click(object sender, EventArgs e)
        {
            DesabilitaCamposF();
            LimparCamposF();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            carregaFuncionario();
        }

        private void txtNomeF_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefoneF_TextChanged(object sender, EventArgs e)
        {

        }

        private void salvarFunc_Click(object sender, EventArgs e)
        {
            if (txtNomeF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeF.Focus();
            }
            else if (txtEnderecoF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo endereço. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEnderecoF.Focus();
            }
            else if (txtTelefoneF.Text.Length < 14)
            {
                MessageBox.Show("O número de Telefone está errado, Porfavor informar os 14 digitos. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefoneF.Focus();
            }
            else if (txtCpfF.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CPF. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfF.Focus();
            }
            else if (txtCpfF.Text.Length < 12)
            {
                MessageBox.Show("O CPF está errado, Porfavor informar os 12 digitos. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfF.Focus();
            }

            else
            {
                try
                {
                    string nome = txtNomeF.Text;
                    string telefone = txtTelefoneF.Text;
                    string cpf = txtCpfF.Text;
                    string endereco = txtEnderecoF.Text;

                    string strSql = "insert into funcionarios(nome,telefone,cpf,endereco)values(@nome,@telefone,@cpf,@endereco)";

                    cm.CommandText = strSql;
                    cm.Connection = cn;

                    cm.Parameters.Add("@nome", System.Data.SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@telefone", System.Data.SqlDbType.VarChar).Value = telefone;
                    cm.Parameters.Add("@cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                    cm.Parameters.Add("@endereco", System.Data.SqlDbType.VarChar).Value = endereco;

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();

                    LimparCamposF();
                    MessageBox.Show("Os dados foram salvos com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    cn.Close();
                }

                finally
                {
                    cn.Close();
                    MostrarTodosFuncionarios();
                }

            }
        }

  

        private void buscaF_TextChanged(object sender, EventArgs e)
        {
            {
                if (buscaF.Text != "")
                {
                    try
                    {
                        cn.Open();
                        cm.CommandText = "select * from funcionarios where nome like ('%" + buscaF.Text + "%')";
                        cm.Connection = cn;

                        SqlDataAdapter da = new SqlDataAdapter();

                        DataTable dt = new DataTable();

                        da.SelectCommand = cm;
                        da.Fill(dt);
                        dgvF.DataSource = dt;
                        cn.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MostrarTodosFuncionarios();
                }
            }
        }

         private void carregaFuncionario()
        {
            manipularDadosF();
            txtNomeF.Text = dgvF.SelectedRows[0].Cells[1].Value.ToString();
            txtTelefoneF.Text = dgvF.SelectedRows[0].Cells[2].Value.ToString();
            txtCpfF.Text = dgvF.SelectedRows[0].Cells[3].Value.ToString();
            txtEnderecoF.Text = dgvF.SelectedRows[0].Cells[4].Value.ToString();
            
            
        }

        public void funcionario_Load_1(object sender, EventArgs e)
        {
            DesabilitaCamposF();
            MostrarTodosFuncionarios();
        }

        private void dgvF_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregaFuncionario();
        }
    }
}
