<script setup>
import { ref, computed } from 'vue';
import Header from './components/Header.vue';
import Footer from './components/Footer.vue';

</script>

<template>
    <section className="font-pt bg-[#F5F4EF] square-pattern min-h-screen">
        <Header />
        <RouterView />
        <Footer />
    </section>
</template>

<style scoped>
.square-pattern {
    width: 100%;
    height: 100%;
    --color: #EBEAE5;
    background-image: linear-gradient(0deg, transparent 24%, var(--color) 25%, var(--color) 26%, transparent 27%, transparent 74%, var(--color) 75%, var(--color) 76%, transparent 77%, transparent),
        linear-gradient(90deg, transparent 24%, var(--color) 25%, var(--color) 26%, transparent 27%, transparent 74%, var(--color) 75%, var(--color) 76%, transparent 77%, transparent);
    background-size: 65px 65px;
}

.bg-dot {
    background-size: 0.75rem 0.75rem;
}
</style>
