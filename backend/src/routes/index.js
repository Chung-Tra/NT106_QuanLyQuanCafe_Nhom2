const router = require('express').Router();

router.use('/auth',        require('./auth.routes'));
router.use('/employees',   require('./employees.routes'));
router.use('/foods',       require('./foods.routes'));
router.use('/chat',        require('./chat.routes'));
router.use('/ingredients', require('./ingredients.routes'));
router.use('/inventory',   require('./inventory.routes'));

router.use('/attendance',   require('./attendance.routes'));


module.exports = router;
