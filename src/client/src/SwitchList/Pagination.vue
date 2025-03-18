<script setup>
import { computed, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'

const props = defineProps([
    "hasPreviousPage", "hasNextPage"
]);
const emits = defineEmits(['onPageChanged'])

const router = useRouter()
const route = useRoute()

const page = computed({
    get() {
        return route.query.page ?? 1
    },
    set(value) {
        router.replace({ query: { ...route.query, page: value } })
    }
})

function onClickPrevious()
{
    if (!props.hasPreviousPage)
        return
    
    page.value--;
    emits('onPageChanged');
}

function onClickNext()
{
    if (!props.hasNextPage)
        return
    
    page.value++;
    emits('onPageChanged');
}

</script>

<template>
    <div class="w-full flex flex-row gap-2 text-center justify-end">
        <button :class="`rounded-lg 
            px-4 py-2 
            border-black border-2 
            ${props.hasPreviousPage ? 'cursor-pointer bg-blue-200 active:bg-blue-400 hover:bg-blue-300' : 'bg-gray-100 text-gray-500'}`"
            @click="onClickPrevious()">Previous</button>
        <button :class="`rounded-lg 
            px-4 py-2 
            border-black border-2 
            ${props.hasNextPage ? 'cursor-pointer bg-blue-200 active:bg-blue-400 hover:bg-blue-300' : 'bg-gray-100 text-gray-500'}`"
            @click="onClickNext()">Next</button>
    </div>
</template>
