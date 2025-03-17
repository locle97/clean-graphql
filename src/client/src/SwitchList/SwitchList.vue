<script setup>
import { ref, computed } from 'vue';
import SwitchListItem from './SwitchListItem.vue';

import { useQuery } from '@vue/apollo-composable'
import gql from 'graphql-tag'

const { result } = useQuery(gql`
    query getSwitches ($skip: Int, $take: Int) {
        switches (skip: $skip, take: $take) {
            items {
                id
                name
                type
                numberOfPins
                force
                bottomForce
                preTravel
                totalTravel
            }
        }
    }`, () => {
    return {
        skip: 0,
        take: 12
    }
});

const switches = computed(() => result.value?.switches ?? [])
</script>

<template>
    <div class="w-full flex flex-col items-center gap-4">
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8 lg:gap-4 w-full max-w-6xl">
            <SwitchListItem v-for="x in switches.items" v-bind:key="x.id" v-bind:switchItem="x" />
        </div>
    </div>
</template>
