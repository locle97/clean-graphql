<script setup>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
</script>

<template>
    <div class="flex flex-col lg:flex-row items-center gap-6 justify-between sticky bg-transparent px-12 py-8">
        <a href="/#">
        <h1 class="font-pt text-4xl font-bold">KeebSwitches</h1>
        </a>
        <a target="_blank" href="https://github.com/locle97/clean-graphql" class="text-xl px-4 py-2 border-2 border-black rounded-lg bg-lime-200 
                       shadow-[3px_3px_0px_black,8px_8px_0px_rgb(200,160,255)] cursor-pointer">
            Github
            <FontAwesomeIcon :icon="['fab', 'github']" class="icon alt" />
        </a>

    </div>
</template>
