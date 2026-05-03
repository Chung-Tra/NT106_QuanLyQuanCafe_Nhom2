// index.js: Entry point cho Firebase Cloud Functions
// Không cần admin.initializeApp() ở đây vì src/config/firebase.js đã lo liệu.

// --- MODULE: AUTH ---
const { updateUserPassword } = require("./src/api/auth/update_password");
const { sendVerificationEmail } = require("./src/api/auth/send_verification_email");
const { checkEmailExists } = require("./src/api/auth/check_email_exists");
const { generateAndSendOTP } = require("./src/api/auth/generate_otp");
const { loginEmployee } = require("./src/api/auth/login_employee");

exports.updateUserPassword = updateUserPassword;
exports.sendVerificationEmail = sendVerificationEmail;
exports.checkEmailExists = checkEmailExists;
exports.generateAndSendOTP = generateAndSendOTP;
exports.loginEmployee = loginEmployee;

// --- MODULE: EMPLOYEE ---
const { getAllEmployees } = require("./src/api/employee/get_all_employees");
const { addEmployee } = require("./src/api/employee/add_employee");
const { updateEmployee } = require("./src/api/employee/update_employee");
const { deleteEmployee } = require("./src/api/employee/delete_employee");
const { lockEmployee } = require("./src/api/employee/lock_employee");

exports.getAllEmployees = getAllEmployees;
exports.addEmployee = addEmployee;
exports.updateEmployee = updateEmployee;
exports.deleteEmployee = deleteEmployee;
exports.lockEmployee = lockEmployee;

// --- MODULE: FOOD ---
const { getAllFoods } = require("./src/api/food/get_all_foods");
const { addFood } = require("./src/api/food/add_food");
const { updateFood } = require("./src/api/food/update_food");
const { deleteFood } = require("./src/api/food/delete_food");

exports.getAllFoods = getAllFoods;
exports.addFood = addFood;
exports.updateFood = updateFood;
exports.deleteFood = deleteFood;

// --- MODULE: CHAT ---
const { saveChatMessage } = require("./src/api/chat/save_message");
const { getChatHistory } = require("./src/api/chat/get_history");

exports.saveChatMessage = saveChatMessage;
exports.getChatHistory = getChatHistory;
