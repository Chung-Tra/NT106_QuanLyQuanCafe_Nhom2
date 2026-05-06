const { error: logError } = require('../utils/logger');

function errorMiddleware(err, req, res, next) {
    logError('Unhandled error', err, {
        method: req.method,
        url: req.originalUrl
    });

    const status = err.status || 500;
    const message = process.env.NODE_ENV === 'production'
        ? 'Internal Server Error'
        : err.message;

    res.status(status).json({ error: message });
}

module.exports = errorMiddleware;
