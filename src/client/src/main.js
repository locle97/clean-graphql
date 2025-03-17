import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import { provide, h } from 'vue';
import { DefaultApolloClient } from '@vue/apollo-composable'
import { ApolloClient, InMemoryCache } from '@apollo/client/core'

const cache = new InMemoryCache()

const apolloClient = new ApolloClient({
    cache,
    uri: 'https://rickandmortyapi.com/graphql',
})

import { library } from "@fortawesome/fontawesome-svg-core";
import {
    faGithub
} from "@fortawesome/free-brands-svg-icons";

library.add(faGithub);

const app = createApp({
    setup: () => {
        provide(DefaultApolloClient, apolloClient);
    },
    render: () => h(App)
})

app.mount('#app')
