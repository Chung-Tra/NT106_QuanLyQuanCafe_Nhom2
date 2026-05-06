const router = require('express').Router();
const ctrl = require('../controllers/inventory.controller');
const { verifyAndGetUser, verifyManagerRole } = require('../middlewares/auth.middleware');

router.get('/',   verifyAndGetUser,  ctrl.getAll);
router.post('/',  verifyManagerRole, ctrl.add);

module.exports = router;
