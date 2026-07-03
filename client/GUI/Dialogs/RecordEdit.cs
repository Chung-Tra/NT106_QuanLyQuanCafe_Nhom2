using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI
{
    // Dialog SỬA dùng chung cho mọi DataGridView dữ liệu mock/in-memory.
    // Render mỗi cột thành 1 ô nhập; cột ID/khoá bị khoá (ReadOnly) — "không sửa ID".
    // Khung ở Designer, logic dựng field + ghi ngược ở .cs.
    public partial class RecordEdit : Form
    {
        public sealed class Field
        {
            public string Key;       // = tên cột (DataGridViewColumn.Name)
            public string Label;     // nhãn hiển thị
            public string Value;     // giá trị hiện tại
            public bool ReadOnly;    // true => khoá, không cho sửa (vd cột ID)
            public Field(string key, string label, string value, bool readOnly = false)
            {
                Key = key; Label = label; Value = value; ReadOnly = readOnly;
            }
        }

        private readonly List<(string Key, Guna2TextBox Box)> _editors = new();
        private readonly HashSet<string> _readOnlyKeys = new(StringComparer.OrdinalIgnoreCase);

        // Giá trị sau khi bấm Lưu (chỉ gồm các field cho phép sửa), keyed theo tên cột.
        public Dictionary<string, string> Values { get; } = new();

        public RecordEdit(string title, IEnumerable<Field> fields)
        {
            InitializeComponent();
            WindowChrome.Apply(this, host: panel1);

            if (!string.IsNullOrWhiteSpace(title))
                lblTitle.Text = title;

            BuildFields(fields);
        }

        private void BuildFields(IEnumerable<Field> fields)
        {
            pnlScroll.SuspendLayout();
            pnlScroll.Controls.Clear();
            _editors.Clear();
            _readOnlyKeys.Clear();

            int y = 0;
            int width = pnlScroll.Width - 24;

            foreach (var f in fields)
            {
                var lbl = new Label
                {
                    AutoSize = false,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(160, 160, 166),
                    Location = new Point(0, y),
                    Size = new Size(width, 18),
                    Text = f.ReadOnly ? f.Label + "  (không sửa)" : f.Label + ":",
                };
                pnlScroll.Controls.Add(lbl);
                y += 20;

                var box = new Guna2TextBox
                {
                    BorderColor = Color.FromArgb(63, 63, 70),
                    BorderRadius = 10,
                    FillColor = f.ReadOnly ? Color.FromArgb(33, 33, 36) : Color.FromArgb(45, 45, 48),
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = f.ReadOnly ? Color.FromArgb(150, 150, 156) : Color.White,
                    Location = new Point(0, y),
                    Size = new Size(width, 40),
                    ReadOnly = f.ReadOnly,
                    Text = f.Value ?? "",
                };
                box.HoverState.BorderColor = Color.FromArgb(120, 120, 130);
                box.FocusedState.BorderColor = Color.FromArgb(31, 138, 154);
                pnlScroll.Controls.Add(box);
                y += 50;

                _editors.Add((f.Key, box));
                if (f.ReadOnly) _readOnlyKeys.Add(f.Key);
            }

            pnlScroll.ResumeLayout();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Values.Clear();
            foreach (var ed in _editors)
            {
                if (_readOnlyKeys.Contains(ed.Key)) continue; // không ghi cột ID/khoá
                Values[ed.Key] = ed.Box.Text;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Tiện ích: mở form sửa cho 1 dòng grid (in-memory) và ghi ngược kết quả.
        // readOnlyCols: tên cột khoá thêm; cột có tên/Header gợi ý ID sẽ tự khoá.
        // Trả về true nếu người dùng đã Lưu.
        public static bool EditRow(DataGridViewRow row, string title, IWin32Window? owner, params string[] readOnlyCols)
        {
            if (row?.DataGridView == null) return false;

            var ro = new HashSet<string>(readOnlyCols ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            var fields = new List<Field>();

            foreach (DataGridViewColumn col in row.DataGridView.Columns)
            {
                string key = col.Name;
                string label = !string.IsNullOrEmpty(col.HeaderText) ? col.HeaderText : col.Name;
                var cell = row.Cells[col.Index];
                string val = cell.FormattedValue?.ToString() ?? cell.Value?.ToString() ?? "";
                bool locked = ro.Contains(key) || LooksLikeId(key, label);
                fields.Add(new Field(key, label, val, locked));
            }

            using var dlg = new RecordEdit(title, fields);
            if (dlg.ShowDialog(owner) != DialogResult.OK) return false;

            foreach (var kv in dlg.Values)
            {
                DataGridViewColumn? col = row.DataGridView.Columns[kv.Key];
                if (col == null) continue;
                try { row.Cells[col.Index].Value = ConvertForCell(row.Cells[col.Index], kv.Value); }
                catch { /* giữ giá trị cũ nếu nhập sai kiểu */ }
            }
            return true;
        }

        private static bool LooksLikeId(string key, string label)
        {
            string k = (key ?? "").Replace(" ", "").ToLowerInvariant();
            string l = (label ?? "").Replace(" ", "").ToLowerInvariant();
            return k == "id" || k.EndsWith("id") || k.StartsWith("ma") || k.StartsWith("mã")
                || l == "id" || l.StartsWith("mã") || l.StartsWith("ma ");
        }

        private static object ConvertForCell(DataGridViewCell cell, string value)
        {
            Type? vt = cell.ValueType;
            if (vt == null || vt == typeof(string)) return value;
            if (string.IsNullOrWhiteSpace(value)) return DBNull.Value;
            return Convert.ChangeType(value, vt);
        }
    }
}
