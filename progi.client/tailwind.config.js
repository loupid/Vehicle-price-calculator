/** @type {import('tailwindcss').Config} */

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
    plugins: [require('tailwindcss-primeui')],
}

