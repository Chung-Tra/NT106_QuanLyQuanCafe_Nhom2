using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    partial class PaymentDialog
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
            cardRoot = new Guna2Panel();
            lblHeader = new Label();
            lblSub = new Label();
            totalCard = new Guna2Panel();
            lblTotalCaption = new Label();
            lblTotalValue = new Label();
            _btnCash = new Guna2Button();
            _btnCard = new Guna2Button();
            _btnQr = new Guna2Button();
            detailHost = new Panel();
            // Cash sub-panel
            _pnlCash = new Panel();
            _lblReceivedCap = new Label();
            _txtReceived = new Guna2TextBox();
            _btnQk0 = new Guna2Button();
            _btnQk1 = new Guna2Button();
            _btnQk2 = new Guna2Button();
            _btnQk3 = new Guna2Button();
            _btnQk4 = new Guna2Button();
            _lblChange = new Label();
            // Card sub-panel
            _pnlCard = new Panel();
            _cardBox = new Guna2Panel();
            _lblCardIcon = new Label();
            _lblCardPrompt = new Label();
            _lblCardWait = new Label();
            // QR sub-panel
            _pnlQr = new Panel();
            _qrBox = new Panel();
            _lblQrTitle = new Label();
            _lblQrInfo = new Label();
            _lblQrAmount = new Label();
            _lblQrSupport = new Label();
            // Footer
            btnCancel = new Guna2Button();
            _btnConfirm = new Guna2Button();

            cardRoot.SuspendLayout();
            totalCard.SuspendLayout();
            detailHost.SuspendLayout();
            _pnlCash.SuspendLayout();
            _pnlCard.SuspendLayout();
            _cardBox.SuspendLayout();
            _pnlQr.SuspendLayout();
            SuspendLayout();
            //
            // cardRoot
            //
            cardRoot.BackColor = Color.Transparent;
            cardRoot.BorderRadius = 14;
            cardRoot.Controls.Add(lblHeader);
            cardRoot.Controls.Add(lblSub);
            cardRoot.Controls.Add(totalCard);
            cardRoot.Controls.Add(_btnCash);
            cardRoot.Controls.Add(_btnCard);
            cardRoot.Controls.Add(_btnQr);
            cardRoot.Controls.Add(detailHost);
            cardRoot.Controls.Add(btnCancel);
            cardRoot.Controls.Add(_btnConfirm);
            cardRoot.Dock = DockStyle.Fill;
            cardRoot.FillColor = Color.FromArgb(31, 31, 34);
            cardRoot.Location = new Point(0, 0);
            cardRoot.Name = "cardRoot";
            cardRoot.Size = new Size(560, 470);
            cardRoot.TabIndex = 0;
            //
            // lblHeader
            //
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(240, 240, 245);
            lblHeader.Location = new Point(24, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(150, 28);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Thanh toán";
            //
            // lblSub
            //
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("Segoe UI", 9.5F);
            lblSub.ForeColor = Color.FromArgb(160, 160, 166);
            lblSub.Location = new Point(26, 52);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(0, 17);
            lblSub.TabIndex = 1;
            //
            // totalCard
            //
            totalCard.BackColor = Color.Transparent;
            totalCard.BorderRadius = 12;
            totalCard.Controls.Add(lblTotalCaption);
            totalCard.Controls.Add(lblTotalValue);
            totalCard.FillColor = Color.FromArgb(24, 24, 27);
            totalCard.Location = new Point(322, 18);
            totalCard.Name = "totalCard";
            totalCard.Size = new Size(214, 64);
            totalCard.TabIndex = 2;
            //
            // lblTotalCaption
            //
            lblTotalCaption.AutoSize = true;
            lblTotalCaption.BackColor = Color.Transparent;
            lblTotalCaption.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTotalCaption.ForeColor = Color.FromArgb(160, 160, 166);
            lblTotalCaption.Location = new Point(14, 10);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.Size = new Size(120, 13);
            lblTotalCaption.TabIndex = 0;
            lblTotalCaption.Text = "TỔNG THANH TOÁN";
            //
            // lblTotalValue
            //
            lblTotalValue.AutoSize = true;
            lblTotalValue.BackColor = Color.Transparent;
            lblTotalValue.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalValue.Location = new Point(12, 28);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(0, 31);
            lblTotalValue.TabIndex = 1;
            //
            // _btnCash
            //
            _btnCash.BorderRadius = 10;
            _btnCash.Cursor = Cursors.Hand;
            _btnCash.FillColor = Color.FromArgb(24, 24, 27);
            _btnCash.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnCash.ForeColor = Color.FromArgb(220, 220, 225);
            _btnCash.Location = new Point(24, 100);
            _btnCash.Name = "_btnCash";
            _btnCash.Size = new Size(168, 44);
            _btnCash.TabIndex = 3;
            _btnCash.Text = "Tiền mặt";
            //
            // _btnCard
            //
            _btnCard.BorderRadius = 10;
            _btnCard.Cursor = Cursors.Hand;
            _btnCard.FillColor = Color.FromArgb(24, 24, 27);
            _btnCard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnCard.ForeColor = Color.FromArgb(220, 220, 225);
            _btnCard.Location = new Point(196, 100);
            _btnCard.Name = "_btnCard";
            _btnCard.Size = new Size(168, 44);
            _btnCard.TabIndex = 4;
            _btnCard.Text = "Thẻ";
            //
            // _btnQr
            //
            _btnQr.BorderRadius = 10;
            _btnQr.Cursor = Cursors.Hand;
            _btnQr.FillColor = Color.FromArgb(24, 24, 27);
            _btnQr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnQr.ForeColor = Color.FromArgb(220, 220, 225);
            _btnQr.Location = new Point(368, 100);
            _btnQr.Name = "_btnQr";
            _btnQr.Size = new Size(168, 44);
            _btnQr.TabIndex = 5;
            _btnQr.Text = "VietQR";
            //
            // detailHost — hosts _pnlCash / _pnlCard / _pnlQr (one visible at a time)
            //
            detailHost.BackColor = Color.Transparent;
            detailHost.Controls.Add(_pnlCash);
            detailHost.Controls.Add(_pnlCard);
            detailHost.Controls.Add(_pnlQr);
            detailHost.Location = new Point(24, 158);
            detailHost.Name = "detailHost";
            detailHost.Size = new Size(512, 226);
            detailHost.TabIndex = 6;
            //
            // ── CASH SUB-PANEL ────────────────────────────────────────────────
            //
            _pnlCash.BackColor = Color.Transparent;
            _pnlCash.Controls.Add(_lblReceivedCap);
            _pnlCash.Controls.Add(_txtReceived);
            _pnlCash.Controls.Add(_btnQk0);
            _pnlCash.Controls.Add(_btnQk1);
            _pnlCash.Controls.Add(_btnQk2);
            _pnlCash.Controls.Add(_btnQk3);
            _pnlCash.Controls.Add(_btnQk4);
            _pnlCash.Controls.Add(_lblChange);
            _pnlCash.Dock = DockStyle.Fill;
            _pnlCash.Name = "_pnlCash";
            //
            // _lblReceivedCap
            //
            _lblReceivedCap.AutoSize = true;
            _lblReceivedCap.BackColor = Color.Transparent;
            _lblReceivedCap.Font = new Font("Segoe UI", 9.5F);
            _lblReceivedCap.ForeColor = Color.FromArgb(160, 160, 166);
            _lblReceivedCap.Location = new Point(2, 4);
            _lblReceivedCap.Name = "_lblReceivedCap";
            _lblReceivedCap.Text = "Khách đưa";
            //
            // _txtReceived
            //
            _txtReceived.BorderColor = Color.FromArgb(63, 63, 70);
            _txtReceived.BorderRadius = 8;
            _txtReceived.FillColor = Color.FromArgb(30, 30, 33);
            _txtReceived.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            _txtReceived.ForeColor = Color.FromArgb(240, 240, 245);
            _txtReceived.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
            _txtReceived.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
            _txtReceived.Location = new Point(2, 28);
            _txtReceived.Name = "_txtReceived";
            _txtReceived.PlaceholderForeColor = Color.FromArgb(110, 110, 120);
            _txtReceived.PlaceholderText = "0";
            _txtReceived.Size = new Size(300, 36);
            //
            // Quick-amount buttons (_btnQk0 → Đủ tiền, _btnQk1 → 50K, …)
            //
            _btnQk0.BorderColor = Color.FromArgb(63, 63, 70);
            _btnQk0.BorderRadius = 10;
            _btnQk0.BorderThickness = 1;
            _btnQk0.Cursor = Cursors.Hand;
            _btnQk0.FillColor = Color.Transparent;
            _btnQk0.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnQk0.ForeColor = Color.FromArgb(220, 220, 225);
            _btnQk0.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            _btnQk0.Location = new Point(2, 76);
            _btnQk0.Name = "_btnQk0";
            _btnQk0.Size = new Size(94, 36);
            _btnQk0.Text = "Đủ tiền";

            _btnQk1.BorderColor = Color.FromArgb(63, 63, 70);
            _btnQk1.BorderRadius = 10;
            _btnQk1.BorderThickness = 1;
            _btnQk1.Cursor = Cursors.Hand;
            _btnQk1.FillColor = Color.Transparent;
            _btnQk1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnQk1.ForeColor = Color.FromArgb(220, 220, 225);
            _btnQk1.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            _btnQk1.Location = new Point(102, 76);
            _btnQk1.Name = "_btnQk1";
            _btnQk1.Size = new Size(94, 36);
            _btnQk1.Text = "50K";

            _btnQk2.BorderColor = Color.FromArgb(63, 63, 70);
            _btnQk2.BorderRadius = 10;
            _btnQk2.BorderThickness = 1;
            _btnQk2.Cursor = Cursors.Hand;
            _btnQk2.FillColor = Color.Transparent;
            _btnQk2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnQk2.ForeColor = Color.FromArgb(220, 220, 225);
            _btnQk2.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            _btnQk2.Location = new Point(202, 76);
            _btnQk2.Name = "_btnQk2";
            _btnQk2.Size = new Size(94, 36);
            _btnQk2.Text = "100K";

            _btnQk3.BorderColor = Color.FromArgb(63, 63, 70);
            _btnQk3.BorderRadius = 10;
            _btnQk3.BorderThickness = 1;
            _btnQk3.Cursor = Cursors.Hand;
            _btnQk3.FillColor = Color.Transparent;
            _btnQk3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnQk3.ForeColor = Color.FromArgb(220, 220, 225);
            _btnQk3.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            _btnQk3.Location = new Point(302, 76);
            _btnQk3.Name = "_btnQk3";
            _btnQk3.Size = new Size(94, 36);
            _btnQk3.Text = "200K";

            _btnQk4.BorderColor = Color.FromArgb(63, 63, 70);
            _btnQk4.BorderRadius = 10;
            _btnQk4.BorderThickness = 1;
            _btnQk4.Cursor = Cursors.Hand;
            _btnQk4.FillColor = Color.Transparent;
            _btnQk4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnQk4.ForeColor = Color.FromArgb(220, 220, 225);
            _btnQk4.HoverState.FillColor = Color.FromArgb(45, 45, 50);
            _btnQk4.Location = new Point(402, 76);
            _btnQk4.Name = "_btnQk4";
            _btnQk4.Size = new Size(94, 36);
            _btnQk4.Text = "500K";
            //
            // _lblChange
            //
            _lblChange.AutoSize = true;
            _lblChange.BackColor = Color.Transparent;
            _lblChange.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblChange.ForeColor = Color.FromArgb(160, 160, 166);
            _lblChange.Location = new Point(2, 132);
            _lblChange.Name = "_lblChange";
            _lblChange.Text = "Tiền thối:  0 đ";
            //
            // ── CARD SUB-PANEL ────────────────────────────────────────────────
            //
            _pnlCard.BackColor = Color.Transparent;
            _pnlCard.Controls.Add(_cardBox);
            _pnlCard.Dock = DockStyle.Fill;
            _pnlCard.Name = "_pnlCard";
            _pnlCard.Visible = false;
            //
            // _cardBox
            //
            _cardBox.BackColor = Color.Transparent;
            _cardBox.BorderRadius = 12;
            _cardBox.Controls.Add(_lblCardIcon);
            _cardBox.Controls.Add(_lblCardPrompt);
            _cardBox.Controls.Add(_lblCardWait);
            _cardBox.FillColor = Color.FromArgb(24, 24, 27);
            _cardBox.Location = new Point(2, 6);
            _cardBox.Name = "_cardBox";
            _cardBox.Size = new Size(508, 200);
            //
            // _lblCardIcon
            //
            _lblCardIcon.AutoSize = true;
            _lblCardIcon.BackColor = Color.Transparent;
            _lblCardIcon.Font = new Font("Segoe UI", 36F);
            _lblCardIcon.ForeColor = Color.FromArgb(31, 138, 154);
            _lblCardIcon.Location = new Point(222, 30);
            _lblCardIcon.Name = "_lblCardIcon";
            _lblCardIcon.Text = "💳";
            //
            // _lblCardPrompt
            //
            _lblCardPrompt.AutoSize = true;
            _lblCardPrompt.BackColor = Color.Transparent;
            _lblCardPrompt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblCardPrompt.ForeColor = Color.FromArgb(240, 240, 245);
            _lblCardPrompt.Location = new Point(150, 110);
            _lblCardPrompt.Name = "_lblCardPrompt";
            _lblCardPrompt.Text = "Quẹt / chạm thẻ trên máy POS";
            //
            // _lblCardWait
            //
            _lblCardWait.AutoSize = true;
            _lblCardWait.BackColor = Color.Transparent;
            _lblCardWait.Font = new Font("Segoe UI", 9F);
            _lblCardWait.ForeColor = Color.FromArgb(160, 160, 166);
            _lblCardWait.Location = new Point(160, 140);
            _lblCardWait.Name = "_lblCardWait";
            _lblCardWait.Text = "Hệ thống chờ xác nhận từ máy quẹt thẻ…";
            //
            // ── QR SUB-PANEL ──────────────────────────────────────────────────
            //
            _pnlQr.BackColor = Color.Transparent;
            _pnlQr.Controls.Add(_qrBox);
            _pnlQr.Controls.Add(_lblQrTitle);
            _pnlQr.Controls.Add(_lblQrInfo);
            _pnlQr.Controls.Add(_lblQrAmount);
            _pnlQr.Controls.Add(_lblQrSupport);
            _pnlQr.Dock = DockStyle.Fill;
            _pnlQr.Name = "_pnlQr";
            _pnlQr.Visible = false;
            //
            // _qrBox (Paint handler wired in .cs)
            //
            _qrBox.BackColor = Color.White;
            _qrBox.Location = new Point(2, 6);
            _qrBox.Name = "_qrBox";
            _qrBox.Size = new Size(170, 170);
            //
            // _lblQrTitle
            //
            _lblQrTitle.AutoSize = true;
            _lblQrTitle.BackColor = Color.Transparent;
            _lblQrTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblQrTitle.ForeColor = Color.FromArgb(240, 240, 245);
            _lblQrTitle.Location = new Point(196, 12);
            _lblQrTitle.Name = "_lblQrTitle";
            _lblQrTitle.Text = "VietQR động";
            //
            // _lblQrInfo (full text set in .cs — includes bank name + reference number)
            //
            _lblQrInfo.AutoSize = true;
            _lblQrInfo.BackColor = Color.Transparent;
            _lblQrInfo.Font = new Font("Segoe UI", 9.5F);
            _lblQrInfo.ForeColor = Color.FromArgb(220, 220, 225);
            _lblQrInfo.Location = new Point(196, 44);
            _lblQrInfo.Name = "_lblQrInfo";
            _lblQrInfo.Text = "Ngân hàng:  Vietcombank\r\nChủ TK:  QUAN CAFE NHOM2\r\nSố TK:  0123 456 789\r\nNội dung:  TT";
            //
            // _lblQrAmount (text set in .cs with actual total)
            //
            _lblQrAmount.AutoSize = true;
            _lblQrAmount.BackColor = Color.Transparent;
            _lblQrAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblQrAmount.ForeColor = Color.FromArgb(34, 197, 94);
            _lblQrAmount.Location = new Point(196, 134);
            _lblQrAmount.Name = "_lblQrAmount";
            _lblQrAmount.Text = "Số tiền:  —";
            //
            // _lblQrSupport
            //
            _lblQrSupport.AutoSize = true;
            _lblQrSupport.BackColor = Color.Transparent;
            _lblQrSupport.Font = new Font("Segoe UI", 8.5F);
            _lblQrSupport.ForeColor = Color.FromArgb(160, 160, 166);
            _lblQrSupport.Location = new Point(2, 182);
            _lblQrSupport.Name = "_lblQrSupport";
            _lblQrSupport.Text = "Hỗ trợ Momo · VNPay · 40+ ngân hàng";
            //
            // ── FOOTER ────────────────────────────────────────────────────────
            //
            btnCancel.BorderColor = Color.FromArgb(63, 63, 70);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderThickness = 1;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 220, 225);
            btnCancel.Location = new Point(300, 402);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 42);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            //
            // _btnConfirm
            //
            _btnConfirm.BorderRadius = 10;
            _btnConfirm.Cursor = Cursors.Hand;
            _btnConfirm.FillColor = Color.FromArgb(34, 197, 94);
            _btnConfirm.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnConfirm.ForeColor = Color.White;
            _btnConfirm.Location = new Point(428, 402);
            _btnConfirm.Name = "_btnConfirm";
            _btnConfirm.Size = new Size(132, 42);
            _btnConfirm.TabIndex = 8;
            _btnConfirm.Text = "Xác nhận";
            _btnConfirm.Click += Confirm_Click;
            //
            // PaymentDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 34);
            ClientSize = new Size(560, 470);
            Controls.Add(cardRoot);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PaymentDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PaymentDialog";

            cardRoot.ResumeLayout(false);
            cardRoot.PerformLayout();
            totalCard.ResumeLayout(false);
            totalCard.PerformLayout();
            detailHost.ResumeLayout(false);
            _pnlCash.ResumeLayout(false);
            _pnlCash.PerformLayout();
            _pnlCard.ResumeLayout(false);
            _cardBox.ResumeLayout(false);
            _cardBox.PerformLayout();
            _pnlQr.ResumeLayout(false);
            _pnlQr.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel cardRoot;
        private Label lblHeader;
        private Label lblSub;
        private Guna2Panel totalCard;
        private Label lblTotalCaption;
        private Label lblTotalValue;
        private Guna2Button _btnCash;
        private Guna2Button _btnCard;
        private Guna2Button _btnQr;
        private Panel detailHost;
        // Cash
        private Panel _pnlCash;
        private Label _lblReceivedCap;
        private Guna2TextBox _txtReceived;
        private Guna2Button _btnQk0;
        private Guna2Button _btnQk1;
        private Guna2Button _btnQk2;
        private Guna2Button _btnQk3;
        private Guna2Button _btnQk4;
        private Label _lblChange;
        // Card
        private Panel _pnlCard;
        private Guna2Panel _cardBox;
        private Label _lblCardIcon;
        private Label _lblCardPrompt;
        private Label _lblCardWait;
        // QR
        private Panel _pnlQr;
        private Panel _qrBox;
        private Label _lblQrTitle;
        private Label _lblQrInfo;
        private Label _lblQrAmount;
        private Label _lblQrSupport;
        // Footer
        private Guna2Button btnCancel;
        private Guna2Button _btnConfirm;
    }
}
