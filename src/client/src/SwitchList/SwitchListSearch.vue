<script setup>
import { ref, computed, watchEffect } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

const route = useRoute()
const router = useRouter()

const q = ref("")

watchEffect(() => {
    q.value = route.query?.q || "";
});

const search = () => {
    if (!q.value || q.value == "")
        router.replace({ query: { ...route.query, q: undefined, page: 1 } })
    else
        router.replace({ query: { ...route.query, q: q.value, page: 1 } })
};

const clear = () => {
    q.value = '';
    search();
};
</script>

<template>
    <div class="flex flex-col sm:flex-row w-full mx-auto gap-2">
        <div class="relative w-full">
            <input v-model="q" class="w-full 
            bg-white 
            px-8
            py-4
            rounded-2xl
            border-black 
            border-3" type="text" placeholder="Search switches..." @keyup.enter="search()" />
            <button 
            @click="clear()"
            class="w-12 cursor-pointer 
                   text-gray-300 
                   hover:text-gray-500 active:text-black 
                   absolute h-full top-0 right-2">
                <FontAwesomeIcon :icon="['fas', 'x']" class="icon alt" />
            </button>
        </div>
        <button @click="search()" class="cursor-pointer 
            border-3 
            border-black 
            bg-teal-200 
            hover:bg-teal-300 
            active:bg-teal-400
            text-black 
            px-8 py-4 
            rounded-2xl 
            font-bold">Search</button>
    </div>
</template>
