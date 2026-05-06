# Apps Script cho Google Sheets Timeline / Gantt

File CSV import vào Google Sheets: `docs/project-timeline-google-sheets.csv`

## Cấu trúc sheet đề xuất

Tạo 4 sheet:

- `Timeline_Gantt`: import CSV timeline chính.
- `Feature_Backlog`: gom tính năng theo role.
- `Reports_KPI`: doanh thu, lợi nhuận, chi phí, thất thoát, feedback.
- `Notification_Flow`: luồng thông báo Admin/Manager.

## Công thức nên thêm trong Google Sheets

Nếu dùng ngày thật thay cho `W1`, `W2`:

```text
Days = End - Start + 1
Profit = Revenue - IngredientCost - UtilityCost - Payroll - LossCost
BadFeedbackRate = BadFeedback / (GoodFeedback + BadFeedback)
Payroll = BaseSalary + Bonus - Penalty
```

## Apps Script tô màu status + tạo menu

Trong Google Sheets:

1. Vào `Extensions` -> `Apps Script`
2. Dán code dưới đây
3. Save
4. Reload Google Sheets
5. Menu `QLCafe Timeline` sẽ xuất hiện

```javascript
function onOpen() {
  SpreadsheetApp.getUi()
    .createMenu('QLCafe Timeline')
    .addItem('Format Timeline', 'formatTimeline')
    .addItem('Create KPI Sheets', 'createKpiSheets')
    .addToUi();
}

function formatTimeline() {
  const sheet = SpreadsheetApp.getActive().getSheetByName('Timeline_Gantt')
    || SpreadsheetApp.getActiveSheet();

  const range = sheet.getDataRange();
  const values = range.getValues();
  if (values.length < 2) return;

  const headers = values[0];
  const priorityCol = headers.indexOf('Priority') + 1;
  const progressCol = headers.indexOf('Progress') + 1;
  const statusCol = headers.indexOf('Status') + 1;

  sheet.setFrozenRows(1);
  sheet.getRange(1, 1, 1, headers.length)
    .setFontWeight('bold')
    .setBackground('#1f2937')
    .setFontColor('#ffffff');

  sheet.autoResizeColumns(1, headers.length);
  sheet.getDataRange().setVerticalAlignment('middle');

  for (let r = 2; r <= values.length; r++) {
    const priority = priorityCol ? sheet.getRange(r, priorityCol).getValue() : '';
    const status = statusCol ? sheet.getRange(r, statusCol).getValue() : '';

    if (priority === 'P0') {
      sheet.getRange(r, 1, 1, headers.length).setBackground('#fff7ed');
    } else if (priority === 'P1') {
      sheet.getRange(r, 1, 1, headers.length).setBackground('#eff6ff');
    }

    if (status === 'Done') {
      sheet.getRange(r, 1, 1, headers.length).setFontColor('#166534');
    } else if (status === 'Blocked') {
      sheet.getRange(r, 1, 1, headers.length).setFontColor('#b91c1c');
    } else if (status === 'Doing') {
      sheet.getRange(r, 1, 1, headers.length).setFontColor('#1d4ed8');
    }
  }

  if (progressCol) {
    const progressRange = sheet.getRange(2, progressCol, values.length - 1, 1);
    const rule = SpreadsheetApp.newDataValidation()
      .requireValueInList(['0%', '10%', '20%', '30%', '40%', '50%', '60%', '70%', '80%', '90%', '100%'], true)
      .build();
    progressRange.setDataValidation(rule);
  }
}

function createKpiSheets() {
  const ss = SpreadsheetApp.getActive();
  createSheetIfMissing_(ss, 'Feature_Backlog', [
    ['Module', 'Role', 'Feature', 'Priority', 'Status', 'Note'],
    ['Admin', 'Admin', 'Dashboard revenue/profit/cost/loss', 'P0', 'Todo', 'Chart by day/month/year'],
    ['Admin', 'Admin', 'Notification audit log', 'P0', 'Todo', 'Manager sensitive actions require reason'],
    ['Manager', 'Manager', 'Resolve bad feedback', 'P0', 'Todo', 'Must enter resolution'],
    ['POS', 'Order Staff', 'Order + bill + QR feedback', 'P0', 'Todo', 'Main demo flow'],
    ['KDS', 'Barista', 'Realtime kitchen screen', 'P1', 'Todo', 'SignalR suggested'],
    ['Warehouse', 'Stockkeeper', 'Smart restock algorithm', 'P2', 'Todo', 'Buffer based on sales'],
    ['Security', 'Security', 'Parking + SOS', 'P2', 'Todo', 'Simple shell acceptable']
  ]);

  createSheetIfMissing_(ss, 'Reports_KPI', [
    ['Period', 'Revenue', 'IngredientCost', 'UtilityCost', 'Payroll', 'LossCost', 'Profit', 'GoodFeedback', 'BadFeedback', 'BadFeedbackRate'],
    ['2026-05', 0, 0, 0, 0, 0, '=B2-C2-D2-E2-F2', 0, 0, '=IFERROR(I2/(H2+I2),0)']
  ]);

  createSheetIfMissing_(ss, 'Notification_Flow', [
    ['Event', 'Sender', 'Receiver', 'Required Reason', 'Action When Clicked', 'Status'],
    ['Manager leave request', 'Manager', 'Admin', 'Leave reason', 'Open detail form: Accept / Reject / Chat', 'Unread'],
    ['Sensitive ingredient edit', 'Manager', 'Admin', 'Edit reason', 'Open audit detail then navigate ingredient page', 'Unread'],
    ['Bad feedback unresolved', 'Customer/System', 'Admin', 'Resolution missing', 'Open chat with Manager', 'Red'],
    ['Bad feedback resolved', 'Manager', 'Admin', 'Resolution filled', 'Show feedback and resolution', 'Green']
  ]);
}

function createSheetIfMissing_(ss, name, rows) {
  let sheet = ss.getSheetByName(name);
  if (!sheet) {
    sheet = ss.insertSheet(name);
  }
  sheet.clear();
  sheet.getRange(1, 1, rows.length, rows[0].length).setValues(rows);
  sheet.setFrozenRows(1);
  sheet.getRange(1, 1, 1, rows[0].length)
    .setFontWeight('bold')
    .setBackground('#1f2937')
    .setFontColor('#ffffff');
  sheet.autoResizeColumns(1, rows[0].length);
}
```

## Gợi ý import CSV

1. Mở Google Sheets mới.
2. `File` -> `Import` -> `Upload`.
3. Chọn `docs/project-timeline-google-sheets.csv`.
4. Đổi tên sheet thành `Timeline_Gantt`.
5. Chạy Apps Script `formatTimeline()`.

