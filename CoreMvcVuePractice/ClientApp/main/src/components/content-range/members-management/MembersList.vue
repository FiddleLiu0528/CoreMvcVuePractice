<template>
  <div>現在位置：{{ breadcrumbList }}</div>

  <section v-if="isRootLayer">
    <div>MembersList</div>
    <input type="text" v-model="data.inputText" />
    <button @click="NextLayer('ModifyRecord')">Go to next layer</button>
  </section>

  <ModifyRecord
    v-if="CheckIsKeepAliveLayer('ModifyRecord')"
    :breadcrumbList="breadcrumbList"
    :nowLayerIndex="nowLayerIndex"
  />
</template>

<script lang="ts">
export default {
  name: "/members-management/members-list",
};
</script>

<script lang="ts" setup>
import useInitialFeature from "@/composition-api/useInitialFeature";
import useInitialFeatureIndent from "@/composition-api/useInitialFeatureIndent";
import ModifyRecord from "./_sub-components/ModifyRecord.vue";
import { onActivated, onUnmounted, reactive, ref } from "vue";
import emitter from "@/tools/Emitter";

const nowLayerIndex = 0;

const breadcrumbList = ref<string[]>([]);
const { data } = useInitialFeature({ inputText: "" });
const { NextLayer, isRootLayer, CheckIsKeepAliveLayer } =
  useInitialFeatureIndent(breadcrumbList, nowLayerIndex);

onActivated(() => {
  emitter.emit("UpdateBreadcrumb", breadcrumbList);
});
</script>

<style lang="scss" scoped></style>
