<template>
  <div class="breadcrumb-block" v-if="breadcrumbList">
    <div breadcrumbList class="breadcrumb-item">
      <span class="active">{{ $t(`router.${breadcrumbList[0]}`) ?? "" }}</span>
      <img src="@/assets/images/icon_subMenu.png" />
    </div>

    <div breadcrumbList class="breadcrumb-item">
      <span>{{ $t(`router.${breadcrumbList[1]}`) ?? "" }}</span>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { computed, onBeforeMount, onUnmounted } from "vue";
import { useRoute } from "vue-router";
import emitter from "@/tools/Emitter";

function a() {
  console.log("UpdateBreadcrumb");
}

onBeforeMount(() => {
  emitter.on("UpdateBreadcrumb", a);
});

onUnmounted(() => {
  emitter.off("UpdateBreadcrumb", a);
});

const route = useRoute();

const breadcrumbList = computed(() => {
  if (route.path === "/") return null;

  const [, section1, section2] = route.path.split("/");
  return [section1, section2];
});
</script>

<style lang="scss" scoped>
.breadcrumb-block {
  display: flex;
  margin-bottom: 1rem;

  .breadcrumb-item {
    display: flex;
    align-items: center;

    span {
      cursor: pointer;
      border-radius: 50px;
      padding: 0 10px;
      text-decoration: none;
      color: #333;

      &:hover,
      &.active {
        background-color: #f5f5f5;
      }
    }

    img {
      margin-right: 5px;
    }
  }
}
</style>
