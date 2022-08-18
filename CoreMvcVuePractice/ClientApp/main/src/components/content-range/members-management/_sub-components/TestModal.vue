<template>
  <section v-if="CheckIsLayerDisplay(nowLayerIndex, 'TestModal')">
    <button @click="PreviousLayer()">Previous Layer</button>
  </section>
</template>

<script lang="ts">
export default {
  name: "TestModal",
};
</script>

<script lang="ts" setup>
import useInitialFeatureIndent from "@/composition-api/useInitialFeatureIndent";
import { defineProps, PropType, ref } from "vue";

const props = defineProps({
  breadcrumbList: {
    type: Array as PropType<Array<string>>,
    default: () => {
      return [];
    },
  },
  nowLayerIndex: {
    type: Number,
    default: 0,
  },
});

const nowLayerIndex = props.nowLayerIndex + 1;

const { PreviousLayer, CheckIsLayerDisplay } = useInitialFeatureIndent(
  ref(props.breadcrumbList),
  nowLayerIndex
);
</script>
