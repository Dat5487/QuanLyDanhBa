
namespace QLDanhBa
{
    partial class NhomLienHe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbtendslienhe = new System.Windows.Forms.Label();
            this.btnthemnhom = new System.Windows.Forms.Button();
            this.btnsuanhom = new System.Windows.Forms.Button();
            this.btnxoanhom = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.dgvdsnhom = new System.Windows.Forms.DataGridView();
            this.txttennhom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsnhom)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtendslienhe
            // 
            this.lbtendslienhe.AutoSize = true;
            this.lbtendslienhe.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lbtendslienhe.Location = new System.Drawing.Point(181, 18);
            this.lbtendslienhe.Name = "lbtendslienhe";
            this.lbtendslienhe.Size = new System.Drawing.Size(213, 30);
            this.lbtendslienhe.TabIndex = 17;
            this.lbtendslienhe.Text = "Quản lý nhóm liên hệ";
            // 
            // btnthemnhom
            // 
            this.btnthemnhom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnthemnhom.Location = new System.Drawing.Point(46, 84);
            this.btnthemnhom.Name = "btnthemnhom";
            this.btnthemnhom.Size = new System.Drawing.Size(77, 38);
            this.btnthemnhom.TabIndex = 19;
            this.btnthemnhom.Text = "Thêm";
            this.btnthemnhom.UseVisualStyleBackColor = true;
            this.btnthemnhom.Click += new System.EventHandler(this.btnthemnhom_Click);
            // 
            // btnsuanhom
            // 
            this.btnsuanhom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnsuanhom.Location = new System.Drawing.Point(46, 141);
            this.btnsuanhom.Name = "btnsuanhom";
            this.btnsuanhom.Size = new System.Drawing.Size(77, 38);
            this.btnsuanhom.TabIndex = 19;
            this.btnsuanhom.Text = "Sửa";
            this.btnsuanhom.UseVisualStyleBackColor = true;
            this.btnsuanhom.Click += new System.EventHandler(this.btnsuanhom_Click);
            // 
            // btnxoanhom
            // 
            this.btnxoanhom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnxoanhom.Location = new System.Drawing.Point(46, 201);
            this.btnxoanhom.Name = "btnxoanhom";
            this.btnxoanhom.Size = new System.Drawing.Size(77, 38);
            this.btnxoanhom.TabIndex = 19;
            this.btnxoanhom.Text = "Xóa";
            this.btnxoanhom.UseVisualStyleBackColor = true;
            this.btnxoanhom.Click += new System.EventHandler(this.btnxoanhom_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnthoat.Location = new System.Drawing.Point(46, 257);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(77, 38);
            this.btnthoat.TabIndex = 19;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // dgvdsnhom
            // 
            this.dgvdsnhom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdsnhom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdsnhom.Location = new System.Drawing.Point(199, 141);
            this.dgvdsnhom.Name = "dgvdsnhom";
            this.dgvdsnhom.Size = new System.Drawing.Size(301, 180);
            this.dgvdsnhom.TabIndex = 20;
            // 
            // txttennhom
            // 
            this.txttennhom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttennhom.Location = new System.Drawing.Point(199, 99);
            this.txttennhom.Name = "txttennhom";
            this.txttennhom.Size = new System.Drawing.Size(148, 23);
            this.txttennhom.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(195, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên nhóm";
            // 
            // NhomLienHe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 348);
            this.Controls.Add(this.txttennhom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvdsnhom);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxoanhom);
            this.Controls.Add(this.btnsuanhom);
            this.Controls.Add(this.btnthemnhom);
            this.Controls.Add(this.lbtendslienhe);
            this.Name = "NhomLienHe";
            this.Text = "Quản lý nhóm liên hệ";
            this.Load += new System.EventHandler(this.NhomLienHe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsnhom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtendslienhe;
        private System.Windows.Forms.Button btnthemnhom;
        private System.Windows.Forms.Button btnsuanhom;
        private System.Windows.Forms.Button btnxoanhom;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.DataGridView dgvdsnhom;
        private System.Windows.Forms.TextBox txttennhom;
        private System.Windows.Forms.Label label2;
    }
}