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
    public partial class cadastro : Form
    {
        public cadastro()
        {
            InitializeComponent();
        }

        //ESTABELECENDO CONEXAO COM O BANCO DE DADOS 

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-T3ACV1N\SQLEXPRESS;Initial Catalog=trab;User ID=sa; password=leo123");
        
        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl1.UserControl1_Load(sender, e);
            userControl1.BringToFront();
            button1.BringToFront();
        }

        private void btnFechar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            funcionario2.funcionario_Load_1(sender, e);
            funcionario2.BringToFront();
            button1.BringToFront();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            userControl22.UserControl2_Load(sender, e);
            userControl22.BringToFront();
            button1.BringToFront();
        }

        public void btn_cadastrarCompra_Click(object sender, EventArgs e)
        {
            compra2.compra_Load(sender,e);
            compra2.BringToFront();
            button1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            relatorio1.BringToFront();
            button1.BringToFront();
        }

        private void userControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
