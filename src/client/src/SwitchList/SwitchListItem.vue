<script setup>
const props = defineProps(["switchItem"]);
</script>

<template>
    <div class="flex flex-col py-6 gap-4 items-center border-3 border-black rounded-lg bg-yellow-200 min-h-64">
        <h3 class="text-center text-xl font-libre font-bold">{{ props.switchItem.name }}</h3>
        <div class="px-4 w-full text-gray-800">
            Description
        </div>
    </div>
</template>
