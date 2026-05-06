module.exports = {
    testEnvironment: 'node',
    testMatch: ['**/tests/**/*.test.js'],
    collectCoverageFrom: [
        'src/**/*.js',
        '!src/config/**',
    ],
    coverageDirectory: 'coverage',
    testTimeout: 10000,
};
