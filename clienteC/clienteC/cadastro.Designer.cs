namespace clienteC
{
    partial class cadastro
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_cadastrarCompra = new System.Windows.Forms.Button();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.userControl1 = new clienteC.UserControl1();
            this.relatorio1 = new clienteC.Relatorio();
            this.funcionario2 = new clienteC.funcionario();
            this.userControl22 = new clienteC.UserControl2();
            this.compra2 = new clienteC.compra();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.btnFechar.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btn_cadastrarCompra);
            this.panel1.Controls.Add(this.btnCadastrarProduto);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Impact", 12F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 440);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 110);
            this.button3.TabIndex = 5;
            this.button3.Text = "Relatorios";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_cadastrarCompra
            // 
            this.btn_cadastrarCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cadastrarCompra.FlatAppearance.BorderSize = 0;
            this.btn_cadastrarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrarCompra.Font = new System.Drawing.Font("Impact", 12F);
            this.btn_cadastrarCompra.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrarCompra.Location = new System.Drawing.Point(0, 330);
            this.btn_cadastrarCompra.Name = "btn_cadastrarCompra";
            this.btn_cadastrarCompra.Size = new System.Drawing.Size(200, 110);
            this.btn_cadastrarCompra.TabIndex = 4;
            this.btn_cadastrarCompra.Text = "Cadastrar Compra";
            this.btn_cadastrarCompra.UseVisualStyleBackColor = true;
            this.btn_cadastrarCompra.Click += new System.EventHandler(this.btn_cadastrarCompra_Click);
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.BackColor = System.Drawing.Color.DarkRed;
            this.btnCadastrarProduto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadastrarProduto.FlatAppearance.BorderSize = 0;
            this.btnCadastrarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarProduto.Font = new System.Drawing.Font("Impact", 12F);
            this.btnCadastrarProduto.ForeColor = System.Drawing.Color.White;
            this.btnCadastrarProduto.Location = new System.Drawing.Point(0, 220);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(200, 110);
            this.btnCadastrarProduto.TabIndex = 3;
            this.btnCadastrarProduto.Text = "Cadastrar Produto";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnCadastrarProduto_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkRed;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Impact", 12F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 110);
            this.button2.TabIndex = 0;
            this.button2.Text = "Cadastrar Vendedor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnCliente
            // 
            this.btnCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.Location = new System.Drawing.Point(0, 0);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(200, 110);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Cadastrar Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.White;
            this.btnFechar.Controls.Add(this.button1);
            this.btnFechar.Controls.Add(this.userControl1);
            this.btnFechar.Controls.Add(this.relatorio1);
            this.btnFechar.Controls.Add(this.funcionario2);
            this.btnFechar.Controls.Add(this.userControl22);
            this.btnFechar.Controls.Add(this.compra2);
            this.btnFechar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFechar.Location = new System.Drawing.Point(200, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(800, 600);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Paint += new System.Windows.Forms.PaintEventHandler(this.btnFechar_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(747, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userControl1
            // 
            this.userControl1.BackColor = System.Drawing.Color.White;
            this.userControl1.Location = new System.Drawing.Point(0, 0);
            this.userControl1.Name = "userControl1";
            this.userControl1.Size = new System.Drawing.Size(800, 600);
            this.userControl1.TabIndex = 3;
            this.userControl1.Load += new System.EventHandler(this.userControl1_Load);
            // 
            // relatorio1
            // 
            this.relatorio1.BackColor = System.Drawing.Color.White;
            this.relatorio1.Location = new System.Drawing.Point(0, 0);
            this.relatorio1.Name = "relatorio1";
            this.relatorio1.Size = new System.Drawing.Size(800, 600);
            this.relatorio1.TabIndex = 1;
            // 
            // funcionario2
            // 
            this.funcionario2.BackColor = System.Drawing.Color.White;
            this.funcionario2.Location = new System.Drawing.Point(0, 0);
            this.funcionario2.Name = "funcionario2";
            this.funcionario2.Size = new System.Drawing.Size(800, 600);
            this.funcionario2.TabIndex = 5;
            // 
            // userControl22
            // 
            this.userControl22.BackColor = System.Drawing.Color.White;
            this.userControl22.Location = new System.Drawing.Point(0, 0);
            this.userControl22.Name = "userControl22";
            this.userControl22.Size = new System.Drawing.Size(800, 600);
            this.userControl22.TabIndex = 6;
            // 
            // compra2
            // 
            this.compra2.BackColor = System.Drawing.Color.White;
            this.compra2.Location = new System.Drawing.Point(0, 0);
            this.compra2.Name = "compra2";
            this.compra2.Size = new System.Drawing.Size(800, 600);
            this.compra2.TabIndex = 4;
            // 
            // cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cadastro";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.btnFechar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel btnFechar;
        private System.Windows.Forms.Button btnCliente;
        private UserControl1 userControl11;
        private System.Windows.Forms.Button button2;
        private funcionario funcionario1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private UserControl2 userControl21;
        private System.Windows.Forms.Button btn_cadastrarCompra;
        private compra compra1;
        private System.Windows.Forms.Button button3;
        private Relatorio relatorio1;
        private UserControl1 userControl1;
        private funcionario funcionario2;
        private compra compra2;
        private UserControl2 userControl22;
    }
}