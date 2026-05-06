require('dotenv').config();
const app = require('./src/app');
const { info } = require('./src/utils/logger');

const PORT = process.env.PORT || 3000;

app.listen(PORT, () => {
    info(`Server đang chạy tại http://localhost:${PORT}`);
    info(`Môi trường: ${process.env.NODE_ENV || 'development'}`);
});
