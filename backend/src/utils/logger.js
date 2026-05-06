const winston = require('winston');
const path = require('path');

/**
 * logger.js
 * Hệ thống log ĐA NĂNG:
 * 1. LOCAL: Ghi file chi tiết tại thư mục backend/logs/
 * 2. CLOUD: Xuất JSON chuẩn Google Cloud Logging khi chạy trên Server
 */

// Định dạng log dành cho file Local (Dễ đọc cho người)
const localFormat = winston.format.combine(
    winston.format.timestamp({ format: 'YYYY-MM-DD HH:mm:ss' }),
    winston.format.printf(({ timestamp, level, message, ...metadata }) => {
        let msg = `[${timestamp}] [${level.toUpperCase()}]: ${message} `;
        if (Object.keys(metadata).length > 0 && level !== 'error') {
            msg += JSON.stringify(metadata);
        }
        return msg;
    })
);

// Định dạng log dành cho Google Cloud (Cấu trúc JSON)
const cloudFormat = winston.format.combine(
    winston.format.timestamp(),
    winston.format.json()
);

const logger = winston.createLogger({
    level: 'info',
    transports: [
        // 1. Ghi log ra FILE tại máy Local (Chi tiết nhất)
        new winston.transports.File({ 
            filename: path.join(__dirname, '../../logs/error.log'), 
            level: 'error',
            format: localFormat 
        }),
        new winston.transports.File({ 
            filename: path.join(__dirname, '../../logs/combined.log'),
            format: localFormat
        }),

        // 2. Xuất log ra CONSOLE (Để Google Cloud thu thập)
        new winston.transports.Console({
            format: process.env.NODE_ENV === 'production' ? cloudFormat : winston.format.combine(winston.format.colorize(), localFormat)
        })
    ]
});

// Hàm hỗ trợ ghi log tùy chỉnh
const info = (message, data = {}) => logger.info(message, data);
const warn = (message, data = {}) => logger.warn(message, data);
const error = (message, err = null, data = {}) => {
    logger.error(message, {
        error: err ? err.message : null,
        stack: err ? err.stack : null,
        ...data
    });
};

module.exports = { info, warn, error };
