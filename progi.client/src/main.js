import './assets/style.css'
import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config'
import Aura from '@primevue/themes/aura'

createApp(App).use(PrimeVue, {
	theme: {
		preset: Aura,
		options: {
			darkModeSelector: 'system'
		}
	}
}).mount('#app')
