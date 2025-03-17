<script setup>
    import { ref } from 'vue';
    import SwitchListItem from './SwitchListItem.vue';

    const switches = ref([
        {
            id: 1,
            name: 'Akko black',
            image: 'https://akkogear.com.vn/wp-content/uploads/2021/08/akko-cs-switch-jelly-black-001-510x631.jpg'
        },
        {
            id: 2,
            name: 'Akko blue',
            image: 'https://akkogear.com.vn/wp-content/uploads/2021/04/akko-cs-switch-ocean-blue-09-510x631.jpg'
        },
        {
            id: 3,
            name: 'Akko yellow',
            image: 'https://kinesis-ergo.com/wp-content/uploads/Cherry-MX-Red-Switch_sq.png'
        }
    ]);
</script>

<template>
    <div class="w-full flex flex-col items-center gap-4">
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8 lg:gap-4 w-full max-w-6xl">
            <SwitchListItem
              v-for="x in switches"
              v-bind:key="x.id"
              v-bind:switchItem="x"/>
        </div>
    </div>
</template>
