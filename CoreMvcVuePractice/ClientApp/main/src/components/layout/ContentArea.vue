<template>
  <section class="content-area" v-if="isLabelExist">
    <LabelBlock />

    <section class="content-block">
      <BreadcrumbBlock :breadcrumbList="props.breadcrumbList" />
      <section class="content-range">
        <slot></slot>
      </section>
    </section>
  </section>
</template>

<script lang="ts" setup>
import LabelBlock from "@/components/layout/content-area-components/LabelBlock.vue";
import BreadcrumbBlock from "@/components/layout/content-area-components/BreadcrumbBlock.vue";

import { useStore } from "../../store/main";
import { storeToRefs } from "pinia";

import { computed, defineProps, PropType } from "vue";

const props = defineProps({
  breadcrumbList: Array as PropType<string[]>,
});

const store = useStore();
const { keepAliveRoutePathList } = storeToRefs(store);

const isLabelExist = computed(() => {
  return keepAliveRoutePathList.value.length !== 0;
});
</script>

<style lang="scss" scoped>
.content-area {
  flex-grow: 1;

  display: flex;
  flex-direction: column;
  overflow: hidden;
  padding: 10px;
  background-color: #fefefe;

  .content-block {
    flex-grow: 1;

    display: flex;
    flex-direction: column;

    padding: 10px;
    box-shadow: -2px 0px 8px #eee;
    overflow: hidden;

    .content-range {
      flex-grow: 1;

      display: flex;
      flex-direction: column;
      overflow: auto;
    }
  }
}
</style>
