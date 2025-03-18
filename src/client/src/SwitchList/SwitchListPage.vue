<script setup>
import { computed, watchEffect } from 'vue'
import SwitchListHeader from './SwitchListHeader.vue'
import SwitchListSkeleton from './SwitchListSkeleton.vue'
import SwitchListSearch from './SwitchListSearch.vue'
import SwitchList from './SwitchList.vue'
import Pagination from './Pagination.vue'
import { useQuery } from '@vue/apollo-composable'
import gql from 'graphql-tag'

import { useRouter, useRoute } from 'vue-router'

const take = 12
const router = useRouter()
const route = useRoute()

const page = computed({
    get() {
        return route.query.page ?? 1
    }
})

const q = computed({
    get() {
        return route.query.q ?? ""
    }
})

const skip = computed(() => (page.value - 1) * take)

const { result, loading, refetch } = useQuery(gql`
query getSwitches($skip: Int, $take: Int, $q: String) {
  switches(skip: $skip, take: $take, where: {
    name:  {
       like: $q
    }
  }) {
    items {
      id
      name
      type
      numberOfPins
      force
      bottomForce
      preTravel
      totalTravel
    }
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
  }
}`,
    () => ({ skip: skip.value, take, q: q.value })
);

watchEffect(() => {
    refetch({ skip: skip.value, take, q: q.value });
});

function scrollToTop() {
    const switchesCollection = document.getElementById("switches-collection");

    switchesCollection.scrollIntoView({
        behavior: "smooth",
        block: "start"
    });
}

const switches = computed(() => result.value?.switches?.items ?? []);
const pageInfo = computed(() => result.value?.switches?.pageInfo ?? { hasPreviousPage: false, hasNextPage: false });

</script>

<template>
    <div class="container mx-auto px-4 max-w-6xl">
        <div class="flex flex-col items-center gap-8">
            <SwitchListHeader />

            <SwitchListSearch />

            <div id="switch-list" class="w-full">
                <SwitchListSkeleton v-if="loading" />
                <SwitchList v-else :switches="switches" />
            </div>

            <Pagination :hasNextPage="pageInfo.hasNextPage" :hasPreviousPage="pageInfo.hasPreviousPage"
                @onPageChanged="scrollToTop" />
        </div>
    </div>
</template>
