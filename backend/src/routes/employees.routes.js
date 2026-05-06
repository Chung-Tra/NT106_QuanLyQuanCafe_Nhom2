const router = require('express').Router();
const ctrl = require('../controllers/employees.controller');
const { verifyAndGetUser, verifyManagerRole } = require('../middlewares/auth.middleware');

router.get('/', verifyAndGetUser, ctrl.getAll);
router.post('/', verifyManagerRole, ctrl.add);
router.put('/:id', verifyManagerRole, ctrl.update);
router.delete('/:id', verifyManagerRole, ctrl.remove);
router.patch('/:id/lock', verifyManagerRole, ctrl.lock);

module.exports = router;
