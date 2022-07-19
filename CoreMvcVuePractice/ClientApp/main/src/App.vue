<template>
  <router-view />
</template>

<script setup lang="ts">
import useInitialSettings from "@/composition-api/useInitialSettings";
useInitialSettings();
</script>

<style lang="scss">
html,
body {
  height: 100%;
  width: 100%;
}

body {
  margin: 0;
  font-family: Arial, "Microsoft JhengHei";
}

#app {
  height: 100%;
  width: 100%;
  display: flex;
  overflow: hidden;
}
</style>
