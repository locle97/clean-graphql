<script setup>
    import SwitchListHeader from './SwitchListHeader.vue'
    import SwitchList from './SwitchList.vue'
    import Pagination from './Pagination.vue'
</script>

<template>
    <div class="container mx-auto">
        <div class="flex flex-col items-center">
            <SwitchListHeader />
            <SwitchList />
            <Pagination />
        </div>
    </div>
</template>
