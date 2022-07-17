<template>
  <SideBar v-show="isSideMenuDisplay" />

  <div class="right-area">
    <HeadNav />
  </div>
</template>
<script setup lang="ts">
import { ref } from "vue";
import SideBar from "@/layout/SideBar.vue";
import HeadNav from "@/layout/HeadNav.vue";

const isSideMenuDisplay = ref(true);
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

  .right-area {
    height: 100%;
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    overflow: hidden;
  }
}
</style>
