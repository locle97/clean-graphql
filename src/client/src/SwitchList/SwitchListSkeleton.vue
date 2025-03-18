<script setup>
import { ref } from 'vue';

const skeletonFeatures = ref([
    { name: 'Type' },
    { name: 'Pins' },
    { name: 'Operation Force' },
    { name: 'Bottom Force' },
    { name: 'Pre-Travel' },
    { name: 'Total Travel' }
]);
</script>

<template>
    <div class="w-full flex flex-col items-center gap-4">
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8 lg:gap-4 w-full">
            <div v-for="index in 12" :key="index"
                class="flex flex-col pt-6 pb-4 px-6 items-center justify-between gap-8 border-3 border-black rounded-lg bg-yellow-50 min-h-64">
                <div class="w-full flex flex-col gap-2">
                    <div class="h-6 bg-gray-300 rounded w-1/2 mx-auto animate-pulse"></div>
                    <div class="flex flex-col justify-start w-full text-gray-600">
                        <div v-for="feature in skeletonFeatures" :key="feature.name"
                            class="flex items-center gap-2 py-1">
                            <div class="h-4 w-4 bg-gray-300 rounded animate-pulse"></div>
                            <div class="h-4 bg-gray-300 rounded w-full animate-pulse"></div>
                        </div>
                    </div>
                </div>
                <div class="w-full">
                    <div class="h-10 bg-gray-300 rounded-lg w-full animate-pulse"></div>
                </div>
            </div>
        </div>
    </div>
</template>
