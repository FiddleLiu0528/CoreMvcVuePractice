<template>
  <SideBar v-show="isSideBarDisplay" />

  <div class="right-area">
    <HeadNav />

    <ContentArea>
      <router-view v-slot="{ Component, route }">
        <template v-if="keepAliveRouteFullNameList.includes(route.path)">
          <keep-alive>
            <component :is="Component" :key="route.path" />
          </keep-alive>
        </template>
        <template v-else>
          <component :is="Component" />
        </template>
      </router-view>
    </ContentArea>
  </div>
</template>

<script setup lang="ts">
import { useStore } from "../../store/main";
import { storeToRefs } from "pinia";
import SideBar from "@/components/layout/SideBar.vue";
import HeadNav from "@/components/layout/HeadNav.vue";
import ContentArea from "@/components/layout/ContentArea.vue";

const store = useStore();
const { isSideBarDisplay } = storeToRefs(store);
const { keepAliveRouteFullNameList } = storeToRefs(store);
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
