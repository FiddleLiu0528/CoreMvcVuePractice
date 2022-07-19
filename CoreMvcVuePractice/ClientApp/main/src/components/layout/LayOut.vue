<template>
  <SideBar v-show="isSideMenuDisplay" />

  <div class="right-area">
    <HeadNav />

    <router-view />
  </div>
</template>

<script setup lang="ts">
import { useStore } from "../../store/main";
import { storeToRefs } from "pinia";
import SideBar from "@/components/layout/SideBar.vue";
import HeadNav from "@/components/layout/HeadNav.vue";

const store = useStore();
const { isSideMenuDisplay } = storeToRefs(store);
</script>

<style lang="scss" scoped>
.right-area {
  height: 100%;
  display: flex;
  flex-direction: column;
  flex-grow: 1;
  overflow: hidden;
}
</style>
