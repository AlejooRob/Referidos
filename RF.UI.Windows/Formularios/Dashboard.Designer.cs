namespace RF.UI.Windows.Formularios
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblTitleChildForm = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMnEmpleados = new FontAwesome.Sharp.IconButton();
            this.btnMnUsuarios = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.btnMnPagos = new FontAwesome.Sharp.IconButton();
            this.btnMnComisiones = new FontAwesome.Sharp.IconButton();
            this.btnMnVentas = new FontAwesome.Sharp.IconButton();
            this.bntHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelShadowTitle = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.lblTitleChildForm.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bntHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelMenu.Controls.Add(this.btnMnVentas);
            this.panelMenu.Controls.Add(this.btnMnComisiones);
            this.panelMenu.Controls.Add(this.btnMnPagos);
            this.panelMenu.Controls.Add(this.iconButton3);
            this.panelMenu.Controls.Add(this.btnMnUsuarios);
            this.panelMenu.Controls.Add(this.btnMnEmpleados);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 679);
            this.panelMenu.TabIndex = 0;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Controls.Add(this.panelDesktop);
            this.lblTitleChildForm.Controls.Add(this.panelShadowTitle);
            this.lblTitleChildForm.Controls.Add(this.panelTitleBar);
            this.lblTitleChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleChildForm.Location = new System.Drawing.Point(250, 0);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(1012, 679);
            this.lblTitleChildForm.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelLogo.Controls.Add(this.bntHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // btnMnEmpleados
            // 
            this.btnMnEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnMnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMnEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMnEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnMnEmpleados.IconChar = FontAwesome.Sharp.IconChar.PersonDotsFromLine;
            this.btnMnEmpleados.IconColor = System.Drawing.Color.White;
            this.btnMnEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnEmpleados.Location = new System.Drawing.Point(0, 100);
            this.btnMnEmpleados.Name = "btnMnEmpleados";
            this.btnMnEmpleados.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMnEmpleados.Size = new System.Drawing.Size(250, 60);
            this.btnMnEmpleados.TabIndex = 1;
            this.btnMnEmpleados.Text = "Empleados";
            this.btnMnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnEmpleados.UseVisualStyleBackColor = true;
            this.btnMnEmpleados.Click += new System.EventHandler(this.btnMnEmpleados_Click);
            // 
            // btnMnUsuarios
            // 
            this.btnMnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnMnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnMnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            this.btnMnUsuarios.IconColor = System.Drawing.Color.White;
            this.btnMnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnUsuarios.Location = new System.Drawing.Point(0, 160);
            this.btnMnUsuarios.Name = "btnMnUsuarios";
            this.btnMnUsuarios.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMnUsuarios.Size = new System.Drawing.Size(250, 60);
            this.btnMnUsuarios.TabIndex = 2;
            this.btnMnUsuarios.Text = "Usuarios";
            this.btnMnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnUsuarios.UseVisualStyleBackColor = true;
            this.btnMnUsuarios.Click += new System.EventHandler(this.btnMnUsuarios_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ArrowsDownToPeople;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 220);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton3.Size = new System.Drawing.Size(250, 60);
            this.iconButton3.TabIndex = 3;
            this.iconButton3.Text = "Roles";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // btnMnPagos
            // 
            this.btnMnPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMnPagos.FlatAppearance.BorderSize = 0;
            this.btnMnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMnPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMnPagos.ForeColor = System.Drawing.Color.White;
            this.btnMnPagos.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.btnMnPagos.IconColor = System.Drawing.Color.White;
            this.btnMnPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMnPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnPagos.Location = new System.Drawing.Point(0, 280);
            this.btnMnPagos.Name = "btnMnPagos";
            this.btnMnPagos.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMnPagos.Size = new System.Drawing.Size(250, 60);
            this.btnMnPagos.TabIndex = 4;
            this.btnMnPagos.Text = "Pagos";
            this.btnMnPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnPagos.UseVisualStyleBackColor = true;
            this.btnMnPagos.Click += new System.EventHandler(this.btnMnPagos_Click);
            // 
            // btnMnComisiones
            // 
            this.btnMnComisiones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMnComisiones.FlatAppearance.BorderSize = 0;
            this.btnMnComisiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMnComisiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMnComisiones.ForeColor = System.Drawing.Color.White;
            this.btnMnComisiones.IconChar = FontAwesome.Sharp.IconChar.Percentage;
            this.btnMnComisiones.IconColor = System.Drawing.Color.White;
            this.btnMnComisiones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMnComisiones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnComisiones.Location = new System.Drawing.Point(0, 340);
            this.btnMnComisiones.Name = "btnMnComisiones";
            this.btnMnComisiones.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMnComisiones.Size = new System.Drawing.Size(250, 60);
            this.btnMnComisiones.TabIndex = 5;
            this.btnMnComisiones.Text = "Comisiones";
            this.btnMnComisiones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnComisiones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnComisiones.UseVisualStyleBackColor = true;
            this.btnMnComisiones.Click += new System.EventHandler(this.btnMnComisiones_Click);
            // 
            // btnMnVentas
            // 
            this.btnMnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMnVentas.FlatAppearance.BorderSize = 0;
            this.btnMnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMnVentas.ForeColor = System.Drawing.Color.White;
            this.btnMnVentas.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnMnVentas.IconColor = System.Drawing.Color.White;
            this.btnMnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnVentas.Location = new System.Drawing.Point(0, 400);
            this.btnMnVentas.Name = "btnMnVentas";
            this.btnMnVentas.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMnVentas.Size = new System.Drawing.Size(250, 60);
            this.btnMnVentas.TabIndex = 6;
            this.btnMnVentas.Text = "Ventas";
            this.btnMnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnVentas.UseVisualStyleBackColor = true;
            this.btnMnVentas.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // bntHome
            // 
            this.bntHome.Image = ((System.Drawing.Image)(resources.GetObject("bntHome.Image")));
            this.bntHome.Location = new System.Drawing.Point(3, 3);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(222, 91);
            this.bntHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bntHome.TabIndex = 0;
            this.bntHome.TabStop = false;
            this.bntHome.Click += new System.EventHandler(this.bntHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1012, 70);
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitlebar_MouseDown);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 42;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(17, 12);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(42, 42);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(65, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inicio";
            // 
            // panelShadowTitle
            // 
            this.panelShadowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panelShadowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadowTitle.Location = new System.Drawing.Point(0, 70);
            this.panelShadowTitle.Name = "panelShadowTitle";
            this.panelShadowTitle.Size = new System.Drawing.Size(1012, 10);
            this.panelShadowTitle.TabIndex = 1;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1012, 599);
            this.panelDesktop.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 679);
            this.Controls.Add(this.lblTitleChildForm);
            this.Controls.Add(this.panelMenu);
            this.Name = "Dashboard";
            this.Text = "Referidos";
            this.panelMenu.ResumeLayout(false);
            this.lblTitleChildForm.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bntHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel lblTitleChildForm;
        private FontAwesome.Sharp.IconButton btnMnEmpleados;
        private System.Windows.Forms.FlowLayoutPanel panelLogo;
        private FontAwesome.Sharp.IconButton btnMnVentas;
        private FontAwesome.Sharp.IconButton btnMnComisiones;
        private FontAwesome.Sharp.IconButton btnMnPagos;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton btnMnUsuarios;
        private System.Windows.Forms.PictureBox bntHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelShadowTitle;
        private System.Windows.Forms.Panel panelDesktop;
    }
}