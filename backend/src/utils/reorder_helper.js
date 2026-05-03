const { db } = require("../config/firebase");

/**
 * Helper: reorderSequence
 */
async function reorderSequence(nodePath, prefix) {
    const ref = db.ref(nodePath);
    const snapshot = await ref.once('value');
    if (!snapshot.exists()) return;

    const data = snapshot.val();
    const items = Object.keys(data).sort().map(key => data[key]);

    const newData = {};
    items.forEach((item, index) => {
        const newId = `${prefix}${(index + 1).toString().padStart(3, '0')}`;
        newData[newId] = item;
    });

    await ref.set(newData);
}

module.exports = {
    reorderSequence
};
