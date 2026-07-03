using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class InputDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            card = new Guna2Panel();
            lblTitle = new Label();
            lbl = new Label();
            _tb = new Guna2TextBox();
            btnCancel = new Guna2Button();
            btnOk = new Guna2Button();
            card.SuspendLayout();
            SuspendLayout();
            // 
            // card
            // 
            card.BackColor = Color.Transparent;
            card.BorderRadius = 14;
            card.Controls.Add(lblTitle);
            card.Controls.Add(lbl);
            card.Controls.Add(_tb);
            card.Controls.Add(btnCancel);
            card.Controls.Add(btnOk);
            card.CustomizableEdges = customizableEdges7;
            card.Dock = DockStyle.Fill;
            card.FillColor = Color.FromArgb(31, 31, 34);
            card.Location = new Point(0, 0);
            card.Name = "card";
            card.ShadowDecoration.CustomizableEdges = customizableEdges8;
            card.Size = new Size(400, 210);
            card.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(240, 240, 245);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 25);
            lblTitle.TabIndex = 0;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Segoe UI", 9.5F);
            lbl.ForeColor = Color.FromArgb(160, 160, 166);
            lbl.Location = new Point(24, 56);
            lbl.Name = "lbl";
            lbl.Size = new Size(0, 17);
            lbl.TabIndex = 1;
            // 
            // _tb
            // 
            _tb.BorderColor = Color.FromArgb(63, 63, 70);
            _tb.BorderRadius = 8;
            _tb.CustomizableEdges = customizableEdges1;
            _tb.DefaultText = "";
            _tb.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            _tb.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            _tb.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            _tb.DisabledState.PlaceholderForeColor = Color.FromArgb(204, 204, 204);
            _tb.FillColor = Color.FromArgb(30, 30, 33);
            _tb.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            _tb.Font = new Font("Segoe UI", 9.5F);
            _tb.ForeColor = Color.FromArgb(240, 240, 245);
            _tb.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            _tb.Location = new Point(24, 76);
            _tb.Name = "_tb";
            _tb.PasswordChar = '\0';
            _tb.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            _tb.PlaceholderText = "";
            _tb.SelectedText = "";
            _tb.ShadowDecoration.CustomizableEdges = customizableEdges2;
            _tb.Size = new Size(352, 36);
            _tb.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BorderColor = Color.FromArgb(63, 63, 70);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 220, 225);
            btnCancel.HoverState.BorderColor = Color.FromArgb(103, 103, 110);
            btnCancel.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            btnCancel.Location = new Point(124, 138);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(110, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            // 
            // btnOk
            // 
            btnOk.BorderRadius = 10;
            btnOk.Cursor = Cursors.Hand;
            btnOk.CustomizableEdges = customizableEdges5;
            btnOk.FillColor = Color.FromArgb(31, 138, 154);
            btnOk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.HoverState.FillColor = Color.FromArgb(47, 154, 170);
            btnOk.Location = new Point(264, 138);
            btnOk.Name = "btnOk";
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnOk.Size = new Size(124, 40);
            btnOk.TabIndex = 4;
            btnOk.Text = "Xác nhận";
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 34);
            ClientSize = new Size(400, 210);
            Controls.Add(card);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterParent;
            card.ResumeLayout(false);
            card.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel card;
        private Label lblTitle;
        private Label lbl;
        private Guna2TextBox _tb;
        private Guna2Button btnCancel;
        private Guna2Button btnOk;
    }
}
