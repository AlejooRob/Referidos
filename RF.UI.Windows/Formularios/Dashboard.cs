using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;

namespace RF.UI.Windows.Formularios
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn;
        private Panel LeftBorderBtn;
        private int usuarioDashId;
        private Form currentChilForm;
        public Dashboard(int usuarioId)
        {
            InitializeComponent();
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 60);
            this.usuarioDashId = usuarioId;

            panelMenu.Controls.Add(LeftBorderBtn);

            //this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            if(senderBtn != null)
            {
                Disablebutton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(195,41,41 );
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
            }
        }

        private void Disablebutton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(205, 51, 51);
                currentBtn.ForeColor = System.Drawing.Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childform)
        {
            if (currentChilForm != null)
            {
                currentChilForm.Close();
            }
            currentChilForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childform);
            panelDesktop.Tag = childform;
            childform.BringToFront();
            childform.Show();
            lblTitleChildForm.Text = childform.Text;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, System.Drawing.Color.FromArgb(255, 255, 255));
            OpenChildForm(new FrmVentas());
        }

        private void btnMnEmpleados_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, System.Drawing.Color.FromArgb(255, 255, 255));
            OpenChildForm(new FrmEmpleados());
        }

        private void btnMnUsuarios_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, System.Drawing.Color.FromArgb(255, 255, 255));
            OpenChildForm(new FrmUsuarios());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, System.Drawing.Color.FromArgb(255, 255, 255));
            OpenChildForm(new FrmRoles());
        }

        private void btnMnPagos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, System.Drawing.Color.FromArgb(255, 255, 255));
            OpenChildForm(new FrmPagos());
        }

        private void btnMnComisiones_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, System.Drawing.Color.FromArgb(255, 255, 255));
            OpenChildForm(new FrmComisiones());
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            currentChilForm.Close();
            ResetD();
        }

        private void ResetD()
        {
            Disablebutton();
            LeftBorderBtn.Visible= false;
            iconCurrentChildForm.IconChar = IconChar.HomeLg;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnnd, int wMsg, int wParam, int lParam);

        private void panelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
