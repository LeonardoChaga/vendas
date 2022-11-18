
namespace clienteC
{
    partial class Relatorio
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_view = new System.Windows.Forms.DataGridView();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.cb_selecionar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_termino = new System.Windows.Forms.DateTimePicker();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_view)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 36F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(268, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "Relatorio";
            // 
            // dgv_view
            // 
            this.dgv_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_view.Location = new System.Drawing.Point(14, 203);
            this.dgv_view.Name = "dgv_view";
            this.dgv_view.Size = new System.Drawing.Size(773, 384);
            this.dgv_view.TabIndex = 3;
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(14, 152);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(355, 20);
            this.dtp.TabIndex = 4;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // cb_selecionar
            // 
            this.cb_selecionar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.cb_selecionar.FormattingEnabled = true;
            this.cb_selecionar.Location = new System.Drawing.Point(14, 118);
            this.cb_selecionar.Name = "cb_selecionar";
            this.cb_selecionar.Size = new System.Drawing.Size(773, 28);
            this.cb_selecionar.TabIndex = 9;
            this.cb_selecionar.SelectedIndexChanged += new System.EventHandler(this.cb_selecionar_SelectedIndexChanged);
            this.cb_selecionar.TextUpdate += new System.EventHandler(this.cb_selecionar_TextUpdate);
            this.cb_selecionar.TextChanged += new System.EventHandler(this.cb_selecionar_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.label2.Location = new System.Drawing.Point(386, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "até";
            // 
            // dtp_termino
            // 
            this.dtp_termino.Location = new System.Drawing.Point(432, 152);
            this.dtp_termino.Name = "dtp_termino";
            this.dtp_termino.Size = new System.Drawing.Size(355, 20);
            this.dtp_termino.TabIndex = 11;
            this.dtp_termino.ValueChanged += new System.EventHandler(this.dtp_termino_ValueChanged);
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Location = new System.Drawing.Point(166, 178);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(498, 23);
            this.btn_pesquisar.TabIndex = 12;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = true;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.dtp_termino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_selecionar);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.dgv_view);
            this.Controls.Add(this.panel1);
            this.Name = "Relatorio";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.Relatorio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_view;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.ComboBox cb_selecionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_termino;
        private System.Windows.Forms.Button btn_pesquisar;
    }
}
