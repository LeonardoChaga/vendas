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
    public partial class Relatorio : UserControl
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-T3ACV1N\SQLEXPRESS;Initial Catalog=cliente;User ID=sa; password=leo123");

        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;

        public Relatorio()
        {
            InitializeComponent();
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            dtp.Visible = false;
            dtp_termino.Visible = false;
            label2.Visible = false;
            btn_pesquisar.Visible = false;
            cb_selecionar.Items.Add("clientes que realizaram compras");
            cb_selecionar.Items.Add("compras realizadas em período selecionado");
            cb_selecionar.Items.Add("produtos abaixo do estoque mínimo");
            cb_selecionar.Items.Add("folha de pagamento dos salários dos funcionários vendedores");
        }

        private void cb_selecionar_TextUpdate(object sender, EventArgs e)
        {
        }

        private void ClienteQueCompram()
        {
            if (cb_selecionar.Text == "clientes que realizaram compras")
            {
                dgv_view.DataSource = null;
                try
                {
                    cn.Close();
                    cn.Open();
                    cm.CommandText = "SELECT compra.id as 'ID Da Compra', compra.idcliente as 'ID do Cliente', cliente.nome as 'Nome do Cliente', cliente.telefone as 'Telefone', cliente.cpf as 'CPF', cliente.endereco as 'Endereço' FROM compra INNER JOIN cliente ON compra.idcliente = cliente.id";
                    cm.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();

                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_view.DataSource = dt;
                    cn.Close();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Cliente Realizou Compras");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void FolhaDePagamento()
        {
            if (cb_selecionar.Text == "folha de pagamento dos salários dos funcionários vendedores")
            {
                dgv_view.DataSource = null;
                try
                {
                    cn.Close();
                    cn.Open();
                    cm.CommandText = "select funcionarios.id as 'ID Funcionario', nome as 'Nome do Funcionario',sum(valortotal) as 'Total de Vendas', salario = case when sum(valortotal) <= 10000 then salario +(salario * 0.05) when sum(valortotal) > 10000 then salario +(salario * 0.07) else salario end from compra, funcionarios where compra.idfuncionarios = funcionarios.id group by funcionarios.id, nome, endereco,cpf,telefone, salario,valortotal";
                    cm.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();

                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_view.DataSource = dt;
                    cn.Close();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Não Há Funcionarios");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void EstoqueMinimo()
        {
            if (cb_selecionar.Text == "produtos abaixo do estoque mínimo")
            {
                dgv_view.DataSource = null;
                try
                {
                    cn.Close();
                    cn.Open();
                    cm.CommandText = "SELECT id as 'ID Produto', nome as 'Nome do Produto', qtd as 'Quantidade', estoquemin as 'Estoque Minimo' FROM produtos WHERE qtd < estoquemin  ";
                    cm.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();

                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_view.DataSource = dt;
                    cn.Close();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Não Há Produtos Abaixo do Estoque");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void ComprasRealizadasEmPeriodo()
        {
            dgv_view.DataSource = null;

                try
                {
                    cn.Close();
                    cn.Open();
                    cm.CommandText = "SELECT * FROM compra WHERE datacompra BETWEEN '" + dtp.Value.ToString("dd/MM/yyyy") + "' AND '" + dtp_termino.Value.ToString("dd/MM/yyyy") + "' ";
                    cm.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();

                    da.SelectCommand = cm;
                    da.Fill(dt);
                    dgv_view.DataSource = dt;
                    cn.Close();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Não Há Compras nesse Periodo");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
           
        }

            private void mostrarDatas()
        {
            if (cb_selecionar.Text == "compras realizadas em período selecionado")
            {
                dgv_view.DataSource = null;
                label2.Visible = true;
                dtp.Visible = true;
                dtp_termino.Visible = true;
                btn_pesquisar.Visible = true;
            }
            else
            {
                dtp.Visible = false;
                dtp_termino.Visible = false;
                label2.Visible = false;
                btn_pesquisar.Visible = false;
            }
        }
            private void cb_selecionar_TextChanged(object sender, EventArgs e)
        {

            ClienteQueCompram();
            FolhaDePagamento();
            EstoqueMinimo();
            mostrarDatas();

        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtp_termino_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            ComprasRealizadasEmPeriodo();
        }

        private void cb_selecionar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
