<template>
  <svg class="svgIcon" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
    <title>{{ title }}</title>
    <use :xlink:href="iconFullName" />
  </svg>
</template>

<script lang="ts" setup>
import { toRef, defineProps, computed } from "vue";

const props = defineProps({
  iconType: {
    type: String,
    default: "free",
  },

  iconName: {
    type: String,
  },
  title: {
    type: String,
  },
});

// Props
let iconType = toRef(props, "iconType");
let iconName = toRef(props, "iconName");

let iconFullName = computed(() => {
  if (iconType.value === "brand")
    return `#${iconType.value}_cib-${iconName.value}`;
  else if (iconType.value === "flag")
    return `#${iconType.value}_cif-${iconName.value}`;
  else if (iconType.value === "free")
    return `#${iconType.value}_cil-${iconName.value}`;
  else if (iconType.value === "custom")
    return `#${iconType.value}_c-${iconName.value}`;
  return "";
});
</script>
