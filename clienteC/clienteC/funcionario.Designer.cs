namespace clienteC
{
    partial class funcionario
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeF = new System.Windows.Forms.TextBox();
            this.txtTelefoneF = new System.Windows.Forms.TextBox();
            this.txtCpfF = new System.Windows.Forms.TextBox();
            this.txtEnderecoF = new System.Windows.Forms.TextBox();
            this.novoFunc = new System.Windows.Forms.Button();
            this.removerFunc = new System.Windows.Forms.Button();
            this.editarFunc = new System.Windows.Forms.Button();
            this.cancelarFunc = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buscaF = new System.Windows.Forms.TextBox();
            this.dgvF = new System.Windows.Forms.DataGridView();
            this.salvarFunc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvF)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(745, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 36F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(266, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 65);
            this.label1.TabIndex = 6;
            this.label1.Text = "Funcionário";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(202, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Endereço:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(202, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "CPF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(202, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Telefone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nome:";
            // 
            // txtNomeF
            // 
            this.txtNomeF.Location = new System.Drawing.Point(300, 139);
            this.txtNomeF.MaxLength = 40;
            this.txtNomeF.Name = "txtNomeF";
            this.txtNomeF.Size = new System.Drawing.Size(222, 20);
            this.txtNomeF.TabIndex = 17;
            this.txtNomeF.TextChanged += new System.EventHandler(this.txtNomeF_TextChanged);
            // 
            // txtTelefoneF
            // 
            this.txtTelefoneF.Location = new System.Drawing.Point(300, 182);
            this.txtTelefoneF.MaxLength = 14;
            this.txtTelefoneF.Name = "txtTelefoneF";
            this.txtTelefoneF.Size = new System.Drawing.Size(222, 20);
            this.txtTelefoneF.TabIndex = 18;
            this.txtTelefoneF.TextChanged += new System.EventHandler(this.txtTelefoneF_TextChanged);
            // 
            // txtCpfF
            // 
            this.txtCpfF.Location = new System.Drawing.Point(300, 224);
            this.txtCpfF.MaxLength = 13;
            this.txtCpfF.Name = "txtCpfF";
            this.txtCpfF.Size = new System.Drawing.Size(222, 20);
            this.txtCpfF.TabIndex = 19;
            // 
            // txtEnderecoF
            // 
            this.txtEnderecoF.Location = new System.Drawing.Point(300, 265);
            this.txtEnderecoF.MaxLength = 100;
            this.txtEnderecoF.Multiline = true;
            this.txtEnderecoF.Name = "txtEnderecoF";
            this.txtEnderecoF.Size = new System.Drawing.Size(222, 60);
            this.txtEnderecoF.TabIndex = 20;
            // 
            // novoFunc
            // 
            this.novoFunc.Location = new System.Drawing.Point(625, 133);
            this.novoFunc.Name = "novoFunc";
            this.novoFunc.Size = new System.Drawing.Size(100, 30);
            this.novoFunc.TabIndex = 21;
            this.novoFunc.Text = "Novo";
            this.novoFunc.UseVisualStyleBackColor = true;
            this.novoFunc.Click += new System.EventHandler(this.novoFunc_Click);
            // 
            // removerFunc
            // 
            this.removerFunc.Location = new System.Drawing.Point(625, 185);
            this.removerFunc.Name = "removerFunc";
            this.removerFunc.Size = new System.Drawing.Size(100, 30);
            this.removerFunc.TabIndex = 22;
            this.removerFunc.Text = "Remover";
            this.removerFunc.UseVisualStyleBackColor = true;
            this.removerFunc.Click += new System.EventHandler(this.removerFunc_Click);
            // 
            // editarFunc
            // 
            this.editarFunc.Location = new System.Drawing.Point(625, 237);
            this.editarFunc.Name = "editarFunc";
            this.editarFunc.Size = new System.Drawing.Size(100, 30);
            this.editarFunc.TabIndex = 23;
            this.editarFunc.Text = "Editar";
            this.editarFunc.UseVisualStyleBackColor = true;
            this.editarFunc.Click += new System.EventHandler(this.editarFunc_Click);
            // 
            // cancelarFunc
            // 
            this.cancelarFunc.Location = new System.Drawing.Point(625, 295);
            this.cancelarFunc.Name = "cancelarFunc";
            this.cancelarFunc.Size = new System.Drawing.Size(100, 30);
            this.cancelarFunc.TabIndex = 24;
            this.cancelarFunc.Text = "Cancelar";
            this.cancelarFunc.UseVisualStyleBackColor = true;
            this.cancelarFunc.Click += new System.EventHandler(this.cancelarFunc_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(0, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 36);
            this.panel2.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(104, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pesquisar Funcionários";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(192, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Digite o Nome do Funcionário:";
            // 
            // buscaF
            // 
            this.buscaF.Location = new System.Drawing.Point(195, 447);
            this.buscaF.Name = "buscaF";
            this.buscaF.Size = new System.Drawing.Size(261, 20);
            this.buscaF.TabIndex = 27;
            this.buscaF.TextChanged += new System.EventHandler(this.buscaF_TextChanged);
            // 
            // dgvF
            // 
            this.dgvF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvF.Location = new System.Drawing.Point(195, 473);
            this.dgvF.MultiSelect = false;
            this.dgvF.Name = "dgvF";
            this.dgvF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvF.Size = new System.Drawing.Size(530, 124);
            this.dgvF.TabIndex = 28;
            this.dgvF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvF_CellContentClick);
            this.dgvF.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvF_MouseDoubleClick);
            // 
            // salvarFunc
            // 
            this.salvarFunc.Location = new System.Drawing.Point(300, 335);
            this.salvarFunc.Name = "salvarFunc";
            this.salvarFunc.Size = new System.Drawing.Size(75, 23);
            this.salvarFunc.TabIndex = 29;
            this.salvarFunc.Text = "Salvar";
            this.salvarFunc.UseVisualStyleBackColor = true;
            this.salvarFunc.Click += new System.EventHandler(this.salvarFunc_Click);
            // 
            // funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.salvarFunc);
            this.Controls.Add(this.dgvF);
            this.Controls.Add(this.buscaF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelarFunc);
            this.Controls.Add(this.editarFunc);
            this.Controls.Add(this.removerFunc);
            this.Controls.Add(this.novoFunc);
            this.Controls.Add(this.txtEnderecoF);
            this.Controls.Add(this.txtCpfF);
            this.Controls.Add(this.txtTelefoneF);
            this.Controls.Add(this.txtNomeF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "funcionario";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.funcionario_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeF;
        private System.Windows.Forms.TextBox txtTelefoneF;
        private System.Windows.Forms.TextBox txtCpfF;
        private System.Windows.Forms.TextBox txtEnderecoF;
        private System.Windows.Forms.Button novoFunc;
        private System.Windows.Forms.Button removerFunc;
        private System.Windows.Forms.Button editarFunc;
        private System.Windows.Forms.Button cancelarFunc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox buscaF;
        private System.Windows.Forms.DataGridView dgvF;
        private System.Windows.Forms.Button salvarFunc;
        private System.Windows.Forms.Button button1;
    }
}
