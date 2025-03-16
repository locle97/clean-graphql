<script setup>
    import { defineProps } from 'vue';

    const props = defineProps(["name"]);
</script>

<template>
    <h3>{{ props.name }}</h3>
</template>
