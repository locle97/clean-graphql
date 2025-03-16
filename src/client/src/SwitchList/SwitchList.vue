<script setup>
    import { ref } from 'vue';
    import SwitchListItem from './SwitchListItem.vue';

    const switches = ref([
        {
            id: 1,
            name: 'Akko black'
        },
        {
            id: 2,
            name: 'Akko blue'
        },
        {
            id: 3,
            name: 'Akko yellow'
        }
    ]);
</script>

<template>
    <div class="w-full flex flex-col items-center">
        <h2>
            List of switches
        </h2>
        <div class="grid grid-cols-3 w-full max-w-6xl">
            <SwitchListItem
              v-for="x in switches"
              v-bind:key="x.id"
              v-bind:name="x.name"/>
        </div>
    </div>
</template>
