<template>
  <slot :key="key"></slot>
</template>

<script lang="ts" setup>
import { ref, watch, defineProps } from "vue";
import { useStore } from "@/store/main";
import { storeToRefs } from "pinia";

const store = useStore();
const { refreshPage } = storeToRefs(store);
const props = defineProps({
  refreshPageName: String,
});

const key = ref(Date.now());

watch(refreshPage, (newValue) => {
  if (newValue !== props.refreshPageName) return;
  key.value = Date.now();
  refreshPage.value = null;
});
</script>
