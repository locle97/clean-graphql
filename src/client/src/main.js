import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import { provide, h } from 'vue';
import { DefaultApolloClient } from '@vue/apollo-composable'
import { ApolloClient, InMemoryCache } from '@apollo/client/core'
import { createRouter, createWebHistory } from 'vue-router'

import SwitchListPage from './SwitchList/SwitchListPage.vue';
import Home from './components/Home.vue';

const cache = new InMemoryCache()

const apolloClient = new ApolloClient({
    cache,
    uri: 'http://localhost:5255/graphql',
})

import { library } from "@fortawesome/fontawesome-svg-core";
import {
    faLayerGroup,
    faMapPin,
    faAngleDown,
    faAngleDoubleDown,
    faPlay,
    faForward,
    faX
} from "@fortawesome/free-solid-svg-icons";
import {
    faGithub
} from "@fortawesome/free-brands-svg-icons";

library.add(faGithub);
library.add(faLayerGroup);
library.add(faMapPin);
library.add(faAngleDown);
library.add(faAngleDoubleDown);
library.add(faPlay);
library.add(faForward);
library.add(faX);

const routes = [
  { path: '/', component: SwitchListPage },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

const app = createApp({
    setup: () => {
        provide(DefaultApolloClient, apolloClient);
    },
    render: () => h(App)
}).use(router)

app.mount('#app')
