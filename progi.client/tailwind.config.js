/** @type {import('tailwindcss').Config} */
const primeui = require('tailwindcss-primeui')

export default {
    content: [
        "./index.html",
        "./src/**/*.{vue,js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {},
    },
    //disable DarkMode
    // darkMode: [
    //     'selector', '[class*="app-dark"]'
    // ],
    plugins: [primeui],
}

