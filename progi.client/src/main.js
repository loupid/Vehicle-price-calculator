import App from './App.vue'
import {createApp} from 'vue';
import PrimeVue from 'primevue/config';
import "./assets/tailwind.css";
import Aura from '@primevue/themes/aura';

const app = createApp(App);
app.use(PrimeVue, {
    theme: {
        preset: Aura,
        options: {
            cssLayout: {
                name: 'primevue',
                order: 'tailwind-base, primevue, tailwind-utilities'
            }
        }
    }
}).mount('#app')
