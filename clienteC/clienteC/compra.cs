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
    public partial class compra : UserControl
    {
        public compra()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-T3ACV1N\SQLEXPRESS;Initial Catalog=cliente;User ID=sa; password=leo123");
        SqlCommand cq = new SqlCommand();
        string idcompra { get; set; }


        SqlDataReader dt;

        private void HabilitaCamposC()
        {
            cb_cliente.Enabled = true;
            cb_vendedor.Enabled = true;
            btn_cadastrar.Enabled = true;
            btn_novo.Enabled = false;
            btn_editar.Enabled = false;
            btn_remover.Enabled = true;
            btn_cancelar.Enabled = true;


            //dgvF.DataSource = null;
        }


        private void manipularDadosC()
        {
            btn_editar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_remover.Enabled = true;
            btn_cadastrar.Enabled = false;
            btn_novo.Enabled = false;
            cb_cliente.Enabled = true;
            cb_vendedor.Enabled = true;


        }


        private void DesabilitaCamposC()
        {
            cb_cliente.Enabled = false;
            cb_vendedor.Enabled = false;
            btn_editar.Enabled = false;
            btn_remover.Enabled = false;
            btn_novo.Enabled = true;
            btn_cancelar.Enabled = false;
            btn_cadastrar.Enabled = false;
        }

        private void DesabilitaCamposItem()
        {
            cb_produto.Enabled = false;
            txt_qtd.Enabled = false;
            btn_adicionar.Enabled = false;
            btn_removerProduto.Enabled = false;
            cb_cartao.Enabled = false;
            cb_dinheiro.Enabled = false;
            cb_pacelas.Enabled = false;
            btn_pagar.Enabled = false;
        }

        private void HabilitarCamposItem()
        {
            cb_produto.Enabled = true;
            txt_qtd.Enabled = true;
            btn_adicionar.Enabled = true;
            cb_cartao.Enabled = true;
            cb_dinheiro.Enabled = true;
        }

        private void cb_pacelas_TextChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string valoritem = txt_valoritem.Text;
            cq.Connection = cn;
            string strSql = "select sum(valoritem) from item where idcompra like ('%" + idcompra + "%')";
            cq.CommandText = strSql;

            cq.CommandType = CommandType.Text;
            cq.Parameters.Add("@valoritem", System.Data.SqlDbType.Int).Value = valoritem;
            cq.Parameters.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter();
            var ds2 = new DataSet();
            da2.SelectCommand = cq;
            da2.Fill(ds2);
            DataTable dtDatabases3 = ds2.Tables[0];
            txt_valortotal.Text = ds2.Tables[0].Rows[0][0].ToString();
            int valortotaltint = Convert.ToInt32(ds2.Tables[0].Rows[0][0]) ;
            if (cb_pacelas.Text == "1")
            {
                txt_valortotal.Text = ds2.Tables[0].Rows[0][0].ToString();
                cq.ExecuteNonQuery();
                cq.Parameters.Clear();
                cn.Close();
            }
            else if (cb_pacelas.Text == "2")
            {
                txt_valortotal.Text = Convert.ToString(valortotaltint / 2);
                cq.ExecuteNonQuery();
                cq.Parameters.Clear();
                cn.Close();
            }
            else if (cb_pacelas.Text == "3")
            {
                txt_valortotal.Text = Convert.ToString(valortotaltint / 3);
                cq.ExecuteNonQuery();
                cq.Parameters.Clear();
                cn.Close();
            }
        }
        private void btn_pagar_Click(object sender, EventArgs e)
        {

           
            
                try
                {
                cn.Open();
                string valortotal = txt_valortotal.Text;
                   


                    string strSql = "update compra set valortotal = (select isnull(sum(valoritem), 0) from item where compra.id = item.idcompra), pago='Sim' from compra where id like ('%" + idcompra + "%')";

                    cq.CommandText = strSql;
                    cq.Connection = cn;

                    cq.Parameters.Add("@valortotal", System.Data.SqlDbType.Int).Value = valortotal;
                    

                    
                    cq.ExecuteNonQuery();
                    cq.Parameters.Clear();

                    MessageBox.Show("Sua Compra foi realizada com sucesso!. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    cn.Close();
                }

                finally
                {
                    cn.Close();
                    MostrarTodasCompras();
                }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_vendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarregarIdcliente() {

        }

        private void cb_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

     
        private void MostrarTodasCompras()
        {
            try
            {
                cn.Close();
                cn.Open();
                cq.CommandText = "select id as 'Id da Venda',idcliente as 'Id do Cliente',idfuncionarios as 'Id do Vendedor',formapagamento as 'Forma de Pagamento', pago as 'Compra Paga ?',valortotal = case when valortotal <= 1000 then  valortotal - (valortotal * 0.03) when valortotal > 1000 then valortotal - (valortotal * 0.05) else valortotal end, datacompra 'Data Da Compra' from compra";
                cq.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter();

                DataTable dt = new DataTable();

                da.SelectCommand = cq;
                da.Fill(dt);
                dgv_compras.DataSource = dt;
                cn.Close();
                //DgvFunc.DataSource = null;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void MostrarTodoCarrinho()
        {
            try
            {
                cn.Close();
                cn.Open();
                cq.CommandText = "select item.[id] as 'ID Item', idproduto as 'ID Produto', idcompra as 'ID Compra', qtditem as 'Quantidade', valoritem as 'Valor' from item where idcompra like ('%" + idcompra + "%')";
                cq.Connection = cn;
                SqlDataAdapter da3 = new SqlDataAdapter();

                DataTable dt3 = new DataTable();

                da3.SelectCommand = cq;
                da3.Fill(dt3);
                dgv_carrinho.DataSource = dt3;
                cn.Close();
                //DgvFunc.DataSource = null;
                //HabilitarCamposItem();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }



        private void preencherCBCliente()
        {
            //ComboBox Cliente
            cb_cliente.Items.Clear();
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandType = CommandType.Text;
            cq.CommandText = "select * from cliente";
            SqlDataAdapter da = new SqlDataAdapter();

            var ds = new DataSet();

            da.SelectCommand = cq;
            da.Fill(ds);
            DataTable dtDatabases = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cb_cliente.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                cn.Close();
            }
        }

        private void textboxClienteID()
        {
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandType = CommandType.Text;
            cq.CommandText = "select * from cliente";
            SqlDataAdapter da = new SqlDataAdapter();

            var ds = new DataSet();

            da.SelectCommand = cq;
            da.Fill(ds);
            DataTable dtDatabases = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (cb_cliente.Text == ds.Tables[0].Rows[i][1].ToString())
                {
                    txt_idcliente.Text = ds.Tables[0].Rows[i][0].ToString();
                }
                cn.Close();
            }
        }

        private void LimparCamposCompras()
        {
            cb_cliente.Text = "";
            cb_vendedor.Text = "";
            txt_idcliente.Clear();
            txt_idvendedor.Clear();
        }


        private void preencherCBFuncionario()
        {
            //ComboBox Funcionário
            cb_vendedor.Items.Clear();
         
            cq.Connection = cn;
            cq.CommandText = "select * from funcionarios";
            cq.CommandType = CommandType.Text;
            SqlDataAdapter da1 = new SqlDataAdapter();
            var ds1 = new DataSet();
            da1.SelectCommand = cq;
            da1.Fill(ds1);
            DataTable dtDatabases2 = ds1.Tables[0];
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                cb_vendedor.Items.Add(ds1.Tables[0].Rows[i][1].ToString());
                cn.Close();
            }
        }

        private void textboxFuncionarioID()
        {
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandText = "select * from funcionarios";
            cq.CommandType = CommandType.Text;
            SqlDataAdapter da1 = new SqlDataAdapter();
            var ds1 = new DataSet();
            da1.SelectCommand = cq;
            da1.Fill(ds1);
            DataTable dtDatabases2 = ds1.Tables[0];
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (cb_vendedor.Text == ds1.Tables[0].Rows[i][1].ToString())
                {
                    txt_idvendedor.Text = ds1.Tables[0].Rows[i][0].ToString();
                }
                cn.Close();
            }
        }

        private void preencherCBProduto()
        {
            //ComboBox Produto
            cb_produto.Items.Clear();
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandText = "select * from produtos";
            cq.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter();
            var ds2 = new DataSet();
            da2.SelectCommand = cq;
            da2.Fill(ds2);
            DataTable dtDatabases3 = ds2.Tables[0];
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                cb_produto.Items.Add(ds2.Tables[0].Rows[i][1].ToString());
                cn.Close();
            }
        }

        private void textboxProdutoIDeValor()
        {
            //ComboBox Produto
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandText = "select * from produtos";
            cq.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter();
            var ds2 = new DataSet();
            da2.SelectCommand = cq;
            da2.Fill(ds2);
            DataTable dtDatabases3 = ds2.Tables[0];
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                if (cb_produto.Text == ds2.Tables[0].Rows[i][1].ToString())
                {
                    txt_valorunidade.Text = ds2.Tables[0].Rows[i][2].ToString();
                    txt_produtoID.Text = ds2.Tables[0].Rows[i][0].ToString();
                }
                cn.Close();
            }
        }

        public void preencherParcela()
        {
            cb_pacelas.Items.Clear();
            cb_pacelas.Items.Add(1);
            cb_pacelas.Items.Add(2);
            cb_pacelas.Items.Add(3);
        }

        public void compra_Load(object sender, EventArgs e)
        {
            preencherParcela();
            preencherCBProduto();
            preencherCBFuncionario();
            preencherCBCliente();
            DesabilitaCamposC();
            DesabilitaCamposItem();
            MostrarTodasCompras();
            //MostrarTodoCarrinho();

        }



        private void cb_produto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            HabilitaCamposC();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DesabilitaCamposC();
            DesabilitaCamposItem();
            MostrarTodasCompras();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (cb_cliente.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Cliente. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_cliente.Focus();
            }
            else if (cb_vendedor.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Vendedor. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_vendedor.Focus();
            }

            else
            {
                try
                {
                    string cliente = txt_idcliente.Text;
                    string funcionarios = txt_idvendedor.Text;


                    string strSql = "insert into compra(idcliente,idfuncionarios)values(@cliente, @funcionarios)";

                    cq.CommandText = strSql;
                    cq.Connection = cn;

                    cq.Parameters.Add("@cliente", System.Data.SqlDbType.Int).Value = cliente;
                    cq.Parameters.Add("@funcionarios", System.Data.SqlDbType.Int).Value = funcionarios;

                    cn.Open();
                    cq.ExecuteNonQuery();
                    cq.Parameters.Clear();

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
                    MostrarTodasCompras();
                }

            }
        }

        private void txt_idcliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgv_idcliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_cliente_Click(object sender, EventArgs e)
        {
        }

        private void cb_cliente_TextChanged(object sender, EventArgs e)
        {
            textboxClienteID();
        }

        private void cb_vendedor_TextChanged(object sender, EventArgs e)
        {
            textboxFuncionarioID();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textboxProdutoValorTotal() 
        {
            //ComboBox Produto
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandText = "select * from item";
            cq.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            var ds = new DataSet();
            da.SelectCommand = cq;
            da.Fill(ds);
            DataTable dtDatabases = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (cb_produto.Text == ds.Tables[0].Rows[i][1].ToString())
                {
                    txt_valoritem.Text = ds.Tables[0].Rows[i][0].ToString();
                }
                cn.Close();
            }
        }

        private void cb_produto_TextChanged(object sender, EventArgs e)
        {
            textboxProdutoIDeValor();
            textboxProdutoValorTotal();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (cb_cliente.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Cliente. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_cliente.Focus();
            }
            else if (cb_vendedor.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Vendedor. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_vendedor.Focus();
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
                        string id = dgv_compras.SelectedRows[0].Cells[0].Value.ToString();
                        cq.Connection = cn;
                        cq.CommandText = "SELECT CASE WHEN EXISTS(SELECT * FROM[item] WHERE idcompra = " + id + ") THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";

                        cq.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter();
                        var ds = new DataSet();
                        da.SelectCommand = cq;
                        da.Fill(ds);
                        DataTable dtDatabases = ds.Tables[0];
                        cn.Close();

                        if (ds.Tables[0].Rows[0][0].ToString() == "True")
                        {
                            DialogResult existeCompraAv = MessageBox.Show("Não foi possivel remover Compra pois eles está associado a um item", "Exclusão de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (existeCompraAv == DialogResult.OK)
                            {
                                return;
                            }
                        }
                        else 
                        {
                            cn.Open();
                            string strSql = "delete from compra where id=@id";
                            cq.CommandText = strSql;
                            cq.Connection = cn;
                            cq.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;


                            cq.ExecuteNonQuery();
                            cq.Parameters.Clear();
                            LimparCamposCompras();
                            MessageBox.Show("Os dados foram removidos com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                       
                    }

                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                        cn.Close();
                    }

                    finally
                    {
                        cn.Close();
                        MostrarTodasCompras();
                    }

                }
            }
        }

        private void dgv_compras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void carregaCompra()
        {
            txt_idcliente.Text = dgv_compras.SelectedRows[0].Cells[1].Value.ToString();
            txt_idvendedor.Text = dgv_compras.SelectedRows[0].Cells[2].Value.ToString();
            idcompra = dgv_compras.SelectedRows[0].Cells[0].Value.ToString();
            manipularDadosC();

            HabilitarCamposItem();
            MostrarTodoCarrinho();
        }
        private void dgv_compras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DesabilitaCamposC();
            carregaCompra();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (cb_cliente.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Cliente. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_cliente.Focus();
            }
            else if (cb_vendedor.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Vendedor. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_vendedor.Focus();
            }

            else
            {
                try
                {
                    string idcliente = txt_idcliente.Text;
                    string idfuncionarios = txt_idvendedor.Text;
                    string id = dgv_compras.SelectedRows[0].Cells[0].Value.ToString();

                    string strSql = "update compra set idcliente=@idcliente, idfuncionarios=@idfuncionarios where id=@id ";

                    cq.CommandText = strSql;
                    cq.Connection = cn;

                    cq.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                    cq.Parameters.Add("@idcliente", System.Data.SqlDbType.VarChar).Value = idcliente;
                    cq.Parameters.Add("@idfuncionarios", System.Data.SqlDbType.VarChar).Value = idfuncionarios;


                    cn.Open();
                    cq.ExecuteNonQuery();
                    cq.Parameters.Clear();
                    LimparCamposCompras();
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
                    HabilitaCamposC();
                    MostrarTodasCompras();
                }

            }
        }

        private void txt_pesquisarCompra_TextChanged(object sender, EventArgs e)
        {
            {
                if (txt_pesquisarCompra.Text != "")
                {
                    try
                    {
                        cn.Open();
                        cq.CommandText = "select * from compra where id like ('%" + txt_pesquisarCompra.Text + "%')";
                        cq.Connection = cn;

                        SqlDataAdapter da = new SqlDataAdapter();

                        DataTable dt = new DataTable();

                        da.SelectCommand = cq;
                        da.Fill(dt);
                        dgv_compras.DataSource = dt;
                        cn.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MostrarTodasCompras();
                }
            }
        }

        private void txt_pesquisarCompra_Click(object sender, EventArgs e)
        {
            txt_pesquisarCompra.Text = "";
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (cb_produto.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Produto. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_cliente.Focus();
            }
            else if (txt_qtd.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Quantidade. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_vendedor.Focus();
            }

            else
            {
                try
                {
                    cn.Close();
                    cn.Open();

                    string idproduto = txt_produtoID.Text;
                    string quantidade = txt_qtd.Text;
                    string valoritem = txt_valoritem.Text;



                    string strSql = "BEGIN insert into item(idproduto,idcompra,qtditem,valoritem)values(@idproduto, @idcompra, @qtditem, @valoritem); update produtos set qtd=(qtd - qtditem) from produtos, item where produtos.id like ('%" + idproduto + "%') END ";
                    cq.CommandText = strSql;

                    cq.Connection = cn;
                  
                    cq.Parameters.Add("@idproduto", System.Data.SqlDbType.Int).Value = idproduto;
                    cq.Parameters.Add("@idcompra", System.Data.SqlDbType.Int).Value = idcompra;
                    cq.Parameters.Add("@qtditem", System.Data.SqlDbType.Int).Value = quantidade;
                    cq.Parameters.Add("@valoritem", System.Data.SqlDbType.Int).Value = valoritem;



                    cq.ExecuteNonQuery();
                    cq.Parameters.Clear();

                    MessageBox.Show("Os dados foram salvos com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    cn.Close();
                }

                finally
                {
                    cn.Close();
                    MostrarTodoCarrinho();
                }

            }
        }

        private void cb_dinheiro_Click(object sender, EventArgs e)
        {
            if (cb_dinheiro.Checked)
            {
                btn_pagar.Enabled = true;
                cb_cartao.Checked = false;
                cb_pacelas.Enabled = false;

                cn.Close();
                cn.Open();
                string formapagamento = "Dinheiro";
                string id = dgv_compras.SelectedRows[0].Cells[0].Value.ToString();

                string strSql = "update compra set formapagamento = 'Dinheiro' from compra, cliente where compra.id like ('%" + idcompra + "%') ";
                cq.Parameters.Add("@formapagamento", System.Data.SqlDbType.VarChar).Value = formapagamento;
                cq.CommandText = strSql;
                cq.Connection = cn;

                
             
               

                cq.ExecuteNonQuery();
                cq.Parameters.Clear();
                cn.Close();
            }
            else
            {
                btn_pagar.Enabled = false;
            }
        }

        private void cb_cartao_Click(object sender, EventArgs e)
        {
            if (cb_cartao.Checked)
            {
                
                btn_pagar.Enabled = true;
                cb_dinheiro.Checked = false;
                cb_pacelas.Enabled = true;

                cn.Close();
                cn.Open();
                string formapagamento = "Cartão";
                string id = dgv_compras.SelectedRows[0].Cells[0].Value.ToString();

                string strSql = "update compra set formapagamento = 'Cartão' from compra, cliente where compra.id like ('%" + idcompra + "%') ";
                cq.Parameters.Add("@formapagamento", System.Data.SqlDbType.VarChar).Value = formapagamento;
                cq.CommandText = strSql;
                cq.Connection = cn;





             
                cq.ExecuteNonQuery();
                cq.Parameters.Clear();
                cn.Close();
            }
            else
            {
                cb_pacelas.Enabled = false;
                btn_pagar.Enabled = false;
                cq.ExecuteNonQuery();
                cq.Parameters.Clear();
                cn.Close();
            }
        }

        private void manipularDadosCarrinho()
        {
            btn_removerProduto.Enabled = true;

        }
        private void carregacarrinho()
        {
            txt_produtoID.Text = dgv_carrinho.SelectedRows[0].Cells[1].Value.ToString();
            txt_qtd.Text = dgv_carrinho.SelectedRows[0].Cells[3].Value.ToString();
            txt_valoritem.Text = dgv_carrinho.SelectedRows[0].Cells[4].Value.ToString();
            manipularDadosCarrinho();

            // PRODUTO LOGICA PARA MOSTRAR O NOME DO CLIENTE ATRAVES DO ID DELE

            int vrprodutoID;
            int.TryParse(txt_produtoID.Text, out vrprodutoID);
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandType = CommandType.Text;
            cq.CommandText = "select * from produtos";
            SqlDataAdapter da = new SqlDataAdapter();

            var ds = new DataSet();


            da.SelectCommand = cq;
            da.Fill(ds);

            DataTable dtDatabases = ds.Tables[0];
            string nomeProduto = (from DataRow dr in dtDatabases.Rows
                                  where (int)dr["id"] == vrprodutoID
                                  select (string)dr["nome"]).FirstOrDefault();
            cb_produto.Text = nomeProduto;
            cn.Close();
        }
        private void dgv_carrinho_DoubleClick(object sender, EventArgs e)
        {
            carregacarrinho();
        }

        private void txt_valortotal_TextChanged(object sender, EventArgs e)
        {

        }

   

        private void cb_dinheiro_CheckedChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string valoritem = txt_valoritem.Text;
            cq.Connection = cn;
            string strSql =  "select sum(valoritem) from item where idcompra like ('%" + idcompra + "%')";
            cq.CommandText = strSql;
            
            cq.CommandType = CommandType.Text;
            cq.Parameters.Add("@valoritem", System.Data.SqlDbType.Int).Value =valoritem;
            cq.Parameters.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter();
            var ds2 = new DataSet();
            da2.SelectCommand = cq;
            da2.Fill(ds2);
            DataTable dtDatabases3 = ds2.Tables[0];
            txt_valortotal.Text = ds2.Tables[0].Rows[0][0].ToString();
            
            //DgvFunc.DataSource = null;
            
        }

        private void btn_removerProduto_Click(object sender, EventArgs e)
        {
            if (cb_produto.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Produto. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_cliente.Focus();
            }
            else if (txt_qtd.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo Quantidade. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_vendedor.Focus();
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
                        string id = dgv_carrinho.SelectedRows[0].Cells[0].Value.ToString();
                        cn.Open();
                        string strSql = "delete from item where id=@id";
                        cq.CommandText = strSql;
                        cq.Connection = cn;
                        cq.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;


                        cq.ExecuteNonQuery();
                        cq.Parameters.Clear();
                        LimparCamposCompras();
                        MessageBox.Show("Os dados foram removidos com sucesso. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                        cn.Close();
                        MostrarTodoCarrinho();
                    }

                    finally
                    {
                        cn.Close();
                        MostrarTodoCarrinho();
                    }

                }
            }
        }

        private void txt_qtd_ValueChanged(object sender, EventArgs e)
        {
            if (txt_valorunidade.Text == "Valor Unidade")
            {

            }
            else
            {
                int calculoValorItem = Convert.ToInt32(txt_valorunidade.Text) * Convert.ToInt32(txt_qtd.Value);
                string calculoValorItemString = calculoValorItem.ToString();
                txt_valoritem.Text = calculoValorItemString; ;
            }
        }

        private void txt_qtd_Click(object sender, EventArgs e)
        {

        }

        private void cb_cartao_CheckedChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandText = "select sum(valoritem) from item where idcompra like ('%" + idcompra + "%')";
            cq.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter();
            var ds2 = new DataSet();
            da2.SelectCommand = cq;
            da2.Fill(ds2);
            DataTable dtDatabases3 = ds2.Tables[0];
            txt_valortotal.Text = ds2.Tables[0].Rows[0][0].ToString();
 
            cq.Parameters.Clear();
            cn.Close();
            //DgvFunc.DataSource = null;
            HabilitarCamposItem();
            
        }

        private void txt_produtoID_TextChanged(object sender, EventArgs e)
        {

        }



        private void dgv_compras_MouseClick(object sender, MouseEventArgs e)
        {
            // Cliente LOGICA PARA MOSTRAR O NOME DO CLIENTE ATRAVES DO ID DELE
            int vrIDfuncionario;
            int.TryParse(txt_idvendedor.Text, out vrIDfuncionario);
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandType = CommandType.Text;
            cq.CommandText = "select * from funcionarios";
            SqlDataAdapter daf = new SqlDataAdapter();

            var dsf = new DataSet();


            daf.SelectCommand = cq;
            daf.Fill(dsf);

            DataTable dtDatabasesf = dsf.Tables[0];
            string nomeFuncionario = (from DataRow dr1 in dtDatabasesf.Rows
                                      where (int)dr1["id"] == vrIDfuncionario
                                      select (string)dr1["nome"]).FirstOrDefault();
            cb_vendedor.Text = nomeFuncionario;
            cn.Close();
            


            //////////////////////////////////////////////////////////////////////
           
          // fUNCIONARIO LOGICA PARA MOSTRAR O NOME DO FUNCIONARIO ATRAVES DO ID DELE


            int vrIDcliente;
            int.TryParse(txt_idcliente.Text, out vrIDcliente);
            cn.Close();
            cn.Open();
            cq.Connection = cn;
            cq.CommandType = CommandType.Text;
            cq.CommandText = "select * from cliente";
            SqlDataAdapter da = new SqlDataAdapter();

            var ds = new DataSet();


            da.SelectCommand = cq;
            da.Fill(ds);

            DataTable dtDatabases = ds.Tables[0];
            string nomeCliente = (from DataRow dr in dtDatabases.Rows
                                  where (int)dr["id"] == vrIDcliente
                                  select (string)dr["nome"]).FirstOrDefault();
            cb_cliente.Text = nomeCliente;
            cn.Close();


        }

        private void txt_valoritem_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_pacelas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
