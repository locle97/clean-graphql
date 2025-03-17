<script setup>
const year = (new Date()).getFullYear();
</script>

<template>
    <div class="flex flex-col justify-end text-white mt-16 rounded-t-4xl w-full min-h-64 bg-black py-8">
        <div class="flex flex-col gap-4 text-center">
            <a href="mailto:info@keebswitches.app">info@keebswitches.app</a>
            <p>Copyright © {{ year }} by KeebSwitches</p>
        </div>
    </div>
</template>
