/* eslint-env node */
module.exports = {
    root: true,
    'extends': [
        'plugin:vue/vue3-essential',
        'eslint:recommended'
    ],
    plugins: [require('tailwindcss')],
    parserOptions: {
        ecmaVersion: 'latest'
    }
}
