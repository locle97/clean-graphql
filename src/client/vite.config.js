import { defineConfig, loadEnv } from 'vite'
import vue from '@vitejs/plugin-vue'
import tailwindcss from '@tailwindcss/vite'


// https://vite.dev/config/
export default defineConfig(({ mode }) => {
    const env = loadEnv(mode, process.cwd(), '');
    console.log(env);

    return {
        plugins: [vue(), tailwindcss()],
        define: {
          __APP_ENV__: JSON.stringify(env.APP_ENV),
        },
    }
})
