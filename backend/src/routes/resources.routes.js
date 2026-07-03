const express = require('express');
const { makeResource } = require('../controllers/resources.controller');
const { verifyAndGetUser } = require('../middlewares/auth.middleware');

// endpoint -> [node RTDB, prefix id] — khớp DTO client (client/DTO/*.cs)
const RESOURCES = {
    'tables':         ['ban',        'ban_'],
    'orders':         ['don_hang',   'dh_'],
    'payments':       ['thanh_toan', 'tt_'],
    'customers':      ['khach_hang', 'kh_'],
    'feedback':       ['feedback',   'fb_'],
    'attendance':     ['cham_cong',  'cc_'],
    'salaries':       ['luong',      'luong_'],
    'leave-requests': ['xin_nghi',   'xn_'],
    'notifications':  ['thong_bao',  'tb_'],
    'parking':        ['bai_xe',     'bx_'],
    'incidents':      ['su_co',      'sc_'],
    'warnings':       ['canh_bao',   'cb_'],
    'recipes':        ['cong_thuc',  'ct_'],
};

const router = express.Router();

for (const [path, [node, prefix]] of Object.entries(RESOURCES)) {
    const ctrl = makeResource(node, prefix);
    const r = express.Router();
    r.get('/', verifyAndGetUser, ctrl.getAll);
    r.post('/', verifyAndGetUser, ctrl.add);
    r.put('/:id', verifyAndGetUser, ctrl.update);
    r.delete('/:id', verifyAndGetUser, ctrl.remove);
    router.use(`/${path}`, r);
}

module.exports = router;
