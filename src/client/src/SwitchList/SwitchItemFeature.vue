<script setup>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
const props = defineProps([
    "icon", "text", "value"
]);
</script>

<template>
    <div class="flex flex-row justify-start items-center gap-4">
        <div class="w-4 text-center">
            <FontAwesomeIcon :icon="props.icon" class="icon alt" />
        </div>
        <p>{{ props.text }}: </p>
        <p>{{ props.value }}</p>
    </div>
</template>
