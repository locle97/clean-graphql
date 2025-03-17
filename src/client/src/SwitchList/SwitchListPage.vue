<script setup>
    import SwitchListHeader from './SwitchListHeader.vue'
    import SwitchList from './SwitchList.vue'
    import Pagination from './Pagination.vue'
</script>

<template>
    <div class="container mx-auto px-4">
        <div class="flex flex-col items-center gap-16">
            <SwitchListHeader />
            <SwitchList />
        </div>
    </div>
</template>
