import App from './App.vue'
import {createApp} from 'vue';
import PrimeVue from 'primevue/config';
import "./assets/tailwind.css";
import "./style.css"

const app = createApp(App);
app.use(PrimeVue, {
    theme: 'none'
}).mount('#app')
