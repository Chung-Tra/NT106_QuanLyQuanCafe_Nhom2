using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public class BaseDashboard
    {
        private readonly Form _targetForm;
        private readonly System.Windows.Forms.Timer _sessionTimer = new();

        // Biến dùng để kéo thả
        private bool _isDragging = false;
        private Point _startCursorPoint;
        private Point _startFormPoint;

        public BaseDashboard(Form targetForm)
        {
            _targetForm = targetForm;
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                _targetForm.Load += (s, e) => ApplyDragToAllControls(_targetForm);
                SetupSessionTimer();

                // Tự động tắt Timer khi Form đóng để dọn dẹp RAM
                _targetForm.FormClosed += (s, e) =>
                {
                    _sessionTimer.Stop();
                    _sessionTimer.Dispose();
                };
            }
        }

        //HÀM KÉO THẢ FORM 
        private void HandleFormDrag_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _startCursorPoint = Cursor.Position;
                _startFormPoint = _targetForm.Location;
            }
        }

        private void HandleFormDrag_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int diffX = Cursor.Position.X - _startCursorPoint.X;
                int diffY = Cursor.Position.Y - _startCursorPoint.Y;
                _targetForm.Location = new Point(_startFormPoint.X + diffX, _startFormPoint.Y + diffY);
            }
        }

        private void HandleFormDrag_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }

        private void ApplyDragToAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (!(c is Button || c is TextBox || c is ComboBox || c is CheckBox || c is LinkLabel))
                {
                    c.MouseDown += HandleFormDrag_MouseDown;
                    c.MouseMove += HandleFormDrag_MouseMove;
                    c.MouseUp += HandleFormDrag_MouseUp;

                    if (c.HasChildren)
                    {
                        ApplyDragToAllControls(c);
                    }
                }
            }

            if (parent == _targetForm)
            {
                _targetForm.MouseDown += HandleFormDrag_MouseDown;
                _targetForm.MouseMove += HandleFormDrag_MouseMove;
                _targetForm.MouseUp += HandleFormDrag_MouseUp;
            }
        }

        // --- HỆ THỐNG TIMER BẢO MẬT ---
        private void SetupSessionTimer()
        {
            _sessionTimer.Interval = 1000;
            _sessionTimer.Tick += SessionTimer_Tick;
            _sessionTimer.Start();
        }

        private void SessionTimer_Tick(object? sender, EventArgs e)
        {
            if (GlobalSession.ExpiryTime == DateTime.MinValue) return;

            TimeSpan remaining = GlobalSession.ExpiryTime - DateTime.Now;

            if (remaining.TotalSeconds <= 0)
            {
                _sessionTimer.Stop();
                GlobalSession.Token = "";
                GlobalSession.CurrentUser = null;
                GlobalSession.ExpiryTime = DateTime.MinValue;

                MsgBox.Show("Phiên làm việc của bạn đã hết hạn vì lý do bảo mật.\nVui lòng đăng nhập lại!", "Phiên hết hạn", MsgBox.MessageBoxType.Warning);

                bool isLoginFound = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "Login")
                    {
                        frm.Show();
                        isLoginFound = true;
                        break;
                    }
                }

                if (!isLoginFound)
                {
                    Login loginForm = new();
                    loginForm.Show();
                }

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Form? frm = Application.OpenForms[i];
                    if (frm?.Name != "Login")
                    {
                        frm!.DialogResult = DialogResult.Abort;
                        frm.Close();
                    }
                }
            }
        }
    }
}