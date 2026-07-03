const router = require('express').Router();
const ctrl = require('../controllers/auth.controller');

router.post('/login', ctrl.login);
router.post('/check-email', ctrl.checkEmailExists);
router.post('/otp/generate', ctrl.generateOTP);
router.post('/otp/verify', ctrl.verifyOTP);
router.put('/password', ctrl.updatePassword);
router.put('/change-password', ctrl.changePassword);

module.exports = router;
