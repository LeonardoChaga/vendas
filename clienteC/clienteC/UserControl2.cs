using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clienteC
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        //ESTABELECENDO CONEXAO COM O BANCO DE DADOS 

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-T3ACV1N\SQLEXPRESS;Initial Catalog=cliente;User ID=sa; password=leo123");

        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;


        private void MostrarTodosProdutos()
        {
            try
            {
                cn.Open();
                cm.CommandText = "select * from produtos";
                cm.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter();

                DataTable dt = new DataTable();

                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_Mostrar.DataSource = dt;
                cn.Close();
                //DgvFunc.DataSource = null;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void manipularDados()
        {
            btn_editar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_remover.Enabled = true;
            btn_novo.Enabled = false;
            btn_salvar.Enabled = false;
            txtNome.Enabled = true;
            txtNome.Enabled = true;
            txtDesc.Enabled = true;
            txtEstoqMin.Enabled = true;
            txtQtd.Enabled = true;
            dtpValidade.Enabled = true;
            txtValor.Enabled = true;
        }

        private void DesabilitaCampos()
        {
            txtNome.Enabled = false;
            txtDesc.Enabled = false;
            txtEstoqMin.Enabled = false;
            txtQtd.Enabled = false;
            dtpValidade.Enabled = false;
            txtValor.Enabled = false;
            btn_editar.Enabled = false;
            btn_novo.Enabled = false;
            btn_remover.Enabled = false;
            btn_novo.Enabled = true;
            btn_cancelar.Enabled = false;
            btn_salvar.Enabled = false;
        }

        private void HabilitaCampos()
        {
            txtNome.Enabled = true;
            txtDesc.Enabled = true;
            txtEstoqMin.Enabled = true;
            txtQtd.Enabled = true;
            dtpValidade.Enabled = true;
            txtValor.Enabled = true;
            btn_editar.Enabled = true;
            btn_salvar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_remover.Enabled = true;
            btn_novo.Enabled = false;
            txtNome.Focus();
            txtBuscar.Text = "";
            //DgvFunc.DataSource = null;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDesc.Clear();
            txtEstoqMin.ResetText();
            txtQtd.ResetText();
            dtpValidade.ResetText();
            txtValor.ResetText();
            txtNome.Focus();

        }
        public void UserControl2_Load(object sender, EventArgs e)
        {
            DesabilitaCampos();
            MostrarTodosProdutos();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            HabilitaCampos();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DesabilitaCampos();
            LimparCampos();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Obrigatório informar o campo nome. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else if (txtValor.Text == "")
                {
                    MessageBox.Show("Obrigatório informar um valor, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor.Focus();
                }
                else if (txtQtd.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma quantidade, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtd.Focus();
                }
                else if (txtDesc.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma descrição. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesc.Focus();
                }
                else if (txtEstoqMin.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma quantidade, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEstoqMin.Focus();
                }
                else if (dtpValidade.Text == "")
                {
                    MessageBox.Show("Obrigatório informar os dias que faltam para o vencimento, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpValidade.Focus();
                }

                else
                {
                    try
                    {
                        string nome = txtNome.Text;
                        string valor = txtValor.Text;
                        string qtd = txtQtd.Text;
                        string desc = txtDesc.Text;
                        string estoqueMin = txtEstoqMin.Text;
                        string validade = dtpValidade.Text;

                        string strSql = "insert into produtos(nome,valor,qtd,descricao,estoquemin,validade)values(@nome,@valor,@qtd,@descricao,@estoquemin,@validade)";

                        cm.CommandText = strSql;
                        cm.Connection = cn;

                        cm.Parameters.Add("@nome", System.Data.SqlDbType.VarChar).Value = nome;
                        cm.Parameters.Add("@valor", System.Data.SqlDbType.Decimal).Value = valor;
                        cm.Parameters.Add("@qtd", System.Data.SqlDbType.Int).Value = qtd;
                        cm.Parameters.Add("@descricao", System.Data.SqlDbType.VarChar).Value = desc;
                        cm.Parameters.Add("@estoquemin", System.Data.SqlDbType.Int).Value = estoqueMin;
                        cm.Parameters.Add("@validade", System.Data.SqlDbType.Date).Value = validade;

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cm.Parameters.Clear(); cm.Parameters.Clear();
                        LimparCampos();
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
                        MostrarTodosProdutos();
                    }

                }
            }
        }

        private void txtValidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {
                    cn.Open();
                    cm.CommandText = "select * from produtos where nome like ('%" + txtBuscar.Text + "%')";
                    cm.Connection = cn;

                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();

                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_Mostrar.DataSource = dt;
                    cn.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MostrarTodosProdutos();
            }
        }


        private void carregaProduto()
        {
            txtNome.Text = dgv_Mostrar.SelectedRows[0].Cells[1].Value.ToString();
            txtValor.Text = dgv_Mostrar.SelectedRows[0].Cells[2].Value.ToString();
            txtQtd.Text = dgv_Mostrar.SelectedRows[0].Cells[3].Value.ToString();
            txtDesc.Text = dgv_Mostrar.SelectedRows[0].Cells[4].Value.ToString();
            txtEstoqMin.Text = dgv_Mostrar.SelectedRows[0].Cells[5].Value.ToString();
            dtpValidade.Text = dgv_Mostrar.SelectedRows[0].Cells[6].Value.ToString();
            manipularDados();
        }

        private void dgv_Mostrar_DoubleClick(object sender, EventArgs e)
        {
            carregaProduto();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Obrigatório informar o campo nome. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else if (txtValor.Text == "")
                {
                    MessageBox.Show("Obrigatório informar um valorm, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor.Focus();
                }
                else if (txtQtd.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma quantidade, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtd.Focus();
                }
                else if (txtDesc.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma descrição. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesc.Focus();
                }
                else if (txtEstoqMin.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma quantidade, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEstoqMin.Focus();
                }
                else if (dtpValidade.Text == "")
                {
                    MessageBox.Show("Obrigatório informar os dias que faltam para o vencimento, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpValidade.Focus();
                }

                else
                {
                    try
                    {
                        string nome = txtNome.Text;
                        string valor = txtValor.Text;
                        string qtd = txtQtd.Text;
                        string desc = txtDesc.Text;
                        string estoqueMin = txtEstoqMin.Text;
                        string validade = dtpValidade.Text;
                        string id = dgv_Mostrar.SelectedRows[0].Cells[0].Value.ToString();

                        string strSql = "update produtos set nome=@nome, valor=@valor, qtd=@qtd, descricao=@descricao, estoquemin=@estoquemin, validade=@validade where id=@id";

                        cm.CommandText = strSql;
                        cm.Connection = cn;

                        cm.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                        cm.Parameters.Add("@nome", System.Data.SqlDbType.VarChar).Value = nome;
                        cm.Parameters.Add("@valor", System.Data.SqlDbType.Decimal).Value = valor;
                        cm.Parameters.Add("@qtd", System.Data.SqlDbType.Int).Value = qtd;
                        cm.Parameters.Add("@descricao", System.Data.SqlDbType.VarChar).Value = desc;
                        cm.Parameters.Add("@estoquemin", System.Data.SqlDbType.Int).Value = estoqueMin;
                        cm.Parameters.Add("@validade", System.Data.SqlDbType.Date).Value = validade;


                        cn.Open();
                        cm.ExecuteNonQuery();
                        cm.Parameters.Clear();
                        LimparCampos();

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
                        MostrarTodosProdutos();
                    }

                }
            }
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Obrigatório informar o campo nome. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
                else if (txtValor.Text == "")
                {
                    MessageBox.Show("Obrigatório informar um valorm, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor.Focus();
                }
                else if (txtQtd.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma quantidade, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtd.Focus();
                }
                else if (txtDesc.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma descrição. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesc.Focus();
                }
                else if (txtEstoqMin.Text == "")
                {
                    MessageBox.Show("Obrigatório informar uma quantidade, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEstoqMin.Focus();
                }
                else if (dtpValidade.Text == "")
                {
                    MessageBox.Show("Obrigatório informar os dias que faltam para o vencimento, Porfavor informar em numeros inteiros. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpValidade.Focus();
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
                            string id = dgv_Mostrar.SelectedRows[0].Cells[0].Value.ToString();
                            cm.Connection = cn;
                            cm.CommandText = "SELECT CASE WHEN EXISTS(SELECT * FROM[item] WHERE idproduto = " + id + ") THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";

                            cm.CommandType = CommandType.Text;
                            SqlDataAdapter da = new SqlDataAdapter();
                            var ds = new DataSet();
                            da.SelectCommand = cm;
                            da.Fill(ds);
                            DataTable dtDatabases = ds.Tables[0];
                            cn.Close();

                            if (ds.Tables[0].Rows[0][0].ToString() == "True")
                            {
                                DialogResult existeCompraAv = MessageBox.Show("Não foi possivel remover produto pois eles está associado a um item", "Exclusão de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (existeCompraAv == DialogResult.OK)
                                {
                                    return;
                                }
                            }
                            else 
                            {
                                cn.Open();
                                string strSql = "delete from produtos where id=@id";
                                cm.CommandText = strSql;
                                cm.Connection = cn;
                                cm.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;


                                cm.ExecuteNonQuery();
                                cm.Parameters.Clear();
                                LimparCampos();
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
                            MostrarTodosProdutos();
                        }
                    }
                }
            }
        }

        private void dgv_Mostrar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregaProduto();
        }

        private void dgv_Mostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
