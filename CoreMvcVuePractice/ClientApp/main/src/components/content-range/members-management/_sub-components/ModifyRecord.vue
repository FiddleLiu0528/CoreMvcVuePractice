<template>
  <section v-if="CheckIsLayerDisplay(nowLayerIndex, 'ModifyRecord')">
    <div>ModifyRecord({{ nowLayerIndex }})</div>
    <input type="text" v-model="inputText" />
    <button @click="PreviousLayer()">Previous Layer</button>
    <button @click="NextLayer('TestModal')">Next Layer</button>
    <hr />
    <button @click="NextLayer('ModifyRecord')">Next Layer</button>
  </section>

  <ModifyRecord
    v-if="CheckIsKeepAliveLayer('ModifyRecord')"
    :breadcrumbList="breadcrumbList"
    :nowLayerIndex="nowLayerIndex"
  />

  <TestModal
    v-if="CheckIsKeepAliveLayer('TestModal')"
    :breadcrumbList="breadcrumbList"
    :nowLayerIndex="nowLayerIndex"
  />
</template>

<script lang="ts">
export default {
  name: "ModifyRecord",
};
</script>

<script lang="ts" setup>
import TestModal from "./TestModal.vue";
import useInitialFeatureIndent from "@/composition-api/useInitialFeatureIndent";
import { defineProps, PropType, ref } from "vue";

const props = defineProps({
  nowLayerIndex: {
    type: Number,
    default: 0,
  },
  breadcrumbList: {
    type: Array as PropType<Array<string>>,
    default: () => {
      return [];
    },
  },
});

const nowLayerIndex = props.nowLayerIndex + 1;

const { PreviousLayer, NextLayer, CheckIsLayerDisplay, CheckIsKeepAliveLayer } =
  useInitialFeatureIndent(ref(props.breadcrumbList), nowLayerIndex);

const inputText = ref("");
</script>

<style lang="scss" scoped></style>
