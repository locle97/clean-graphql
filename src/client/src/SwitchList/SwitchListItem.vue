<script setup>
import SwitchItemFeature from './SwitchItemFeature.vue';
import { ref } from 'vue';

const props = defineProps(["switchItem"]);
const features = ref([
    {
        name: "Type",
        icon: ["fas", "layer-group"],
        value: props.switchItem.type
    },
    {
        name: "Pins",
        icon: ["fas", "map-pin"],
        value: props.switchItem.numberOfPins ?? "_"
    },
    {
        name: "Operation Force",
        icon: ["fas", "angle-down"],
        value: props.switchItem.force 
            ? `${props.switchItem.force.toFixed(2)}g` 
            : '_'
    },
    {
        name: "Bottom Force",
        icon: ["fas", "angles-down"],
        value: props.switchItem.bottomForce 
            ? `${props.switchItem.bottomForce.toFixed(2)}g` 
            : '_'
    },
    {
        name: "Pre-Travel",
        icon: ["fas", "play"],
        value: props.switchItem.preTravel 
            ? `${props.switchItem.preTravel.toFixed(2)}mm` 
            : '_'
    },
    {
        name: "Total Travel",
        icon: ["fas", "forward"],
        value: props.switchItem.totalTravel 
            ? `${props.switchItem.totalTravel.toFixed(2)}mm` 
            : '_'
    }
]);

</script>

<template>
    <div class="flex flex-col pt-6 pb-4 px-6 items-center justify-between gap-8 border-3 border-black rounded-lg bg-yellow-200 min-h-64">
        <div class="w-full flex flex-col gap-2">
            <h3 class="text-center text-lg font-libre">{{ props.switchItem.name }}</h3>
            <div class="flex flex-col justify-start w-full text-gray-600">
                <SwitchItemFeature v-for="feature in features" :text="feature.name" :icon="feature.icon"
                    :value="feature.value" />
            </div>
        </div>
        <div class="w-full">
            <div class="cursor-pointer text-center bg-black text-white hover:text-black hover:bg-lime-200 active:bg-lime-300 active:text-black px-4 py-3 rounded-lg w-full">
                <p>View Details</p>
            </div>
        </div>
    </div>
</template>
