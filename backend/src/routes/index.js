const router = require('express').Router();

router.use('/auth',        require('./auth.routes'));
router.use('/employees',   require('./employees.routes'));
router.use('/foods',       require('./foods.routes'));
router.use('/chat',        require('./chat.routes'));
router.use('/ingredients', require('./ingredients.routes'));
router.use('/inventory',   require('./inventory.routes'));
// CRUD chung cho các node còn lại: tables, orders, payments, customers, feedback,
// attendance, salaries, leave-requests, notifications, parking, incidents, warnings, recipes
router.use('/',            require('./resources.routes'));

module.exports = router;
