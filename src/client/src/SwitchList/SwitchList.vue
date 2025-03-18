<script setup>
import { ref, computed, watchEffect } from 'vue';
import SwitchListItem from './SwitchListItem.vue';

const props = defineProps(['switches'])
</script>

<template>
    <div class="w-full flex flex-col items-center gap-4">
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8 lg:gap-4 w-full">
            <SwitchListItem v-for="x in switches" v-bind:key="x.id" v-bind:switchItem="x" />
        </div>
    </div>
</template>
