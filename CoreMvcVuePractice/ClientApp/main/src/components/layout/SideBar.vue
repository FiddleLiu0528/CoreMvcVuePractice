<template>
  <div class="side-bar-block">
    <div
      class="web-site-title"
      @click="
        router.push('/');
        store.EmptyRouteTokeepAliveRoutePathList();
      "
    >
      <span>{{ $t(`backstageManagement`) }}</span>
    </div>

    <div v-for="layer1 in sideBarObject" :key="layer1.path" class="layer-1">
      <div
        class="layer-1-button"
        :class="{ active: layer1.path === Layer1ExpandPath }"
        @click="SetLayer1ExpandPath(layer1.path)"
      >
        {{ $t(`router.${layer1.path}`) }}
        <SvgIcon
          width="15"
          height="15"
          iconType="custom"
          iconName="arrow-margin"
          class="arrow-margin"
        />
      </div>

      <div class="layer-2" v-show="Layer1ExpandPath === layer1.path">
        <div
          v-for="layer2 in layer1.children"
          :key="layer2.path"
          class="layer-2-button"
          :class="{ active: route.path === `/${layer1.path}/${layer2.path}` }"
          @click="ClickRouteHandler(`/${layer1.path}/${layer2.path}`)"
        >
          {{ $t(`router.${layer2.path}`) }}
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useRouter, useRoute } from "vue-router";
import { useStore } from "../../store/main";
import { computed, ref, onBeforeMount } from "vue";
import emitter from "@/tools/Emitter";

const router = useRouter();
const route = useRoute();
const store = useStore();

const Layer1ExpandPath = ref("");

onBeforeMount(() => {
  Layer1ExpandPath.value = route.matched[0].path.replaceAll("/", "");
});

const ClickRouteHandler = (target: string) => {
  if (target === route.path) {
    emitter.emit(target);
    return;
  }

  store.UpdateRouteTokeepAliveRoutePathList(target);
  router.push(target);
};

const SetLayer1ExpandPath = (path: string) => {
  Layer1ExpandPath.value = Layer1ExpandPath.value === path ? "" : path;
};

// 目標: 遍歷路由設定，組合並解析出可以直接渲染的物件
const sideBarObject = computed(() => {
  const routes = router.getRoutes();
  const parsedResult = routes
    .filter((el) => el.children.length !== 0)
    .reduce((acc, el) => {
      if (!el.meta.isDisplayOnSideBar) return acc;

      const childrenList = el.children.reduce((acc1, el1) => {
        if (!el1.meta?.isDisplayOnSideBar) return acc1;

        acc1.push({ path: el1.path });
        return acc1;
      }, [] as { path: string }[]);

      if (childrenList.length === 0) return acc;

      acc.push({
        path: el.path.replaceAll("/", ""),
        children: childrenList,
      });

      return acc;
    }, [] as { path: string; children: { path: string }[] }[]);

  return parsedResult;
});
</script>

<style lang="scss" scoped>
.side-bar-block {
  height: 100%;
  width: 210px;
  min-width: 210px;
  background-color: #2e3b4d;
  border-right: 1px solid #c8c8c8;
  overflow: auto;

  color: white;
  .web-site-title {
    display: flex;
    flex-direction: column;

    padding: 30px 0 15px 40px;
    cursor: pointer;
    font-size: 17px;
    color: #fefefe;
  }

  .layer-1 {
    border-bottom: 1px solid #2e3b4d;
    box-sizing: border-box;

    .layer-1-button {
      display: flex;
      align-items: center;
      cursor: pointer;
      height: 45px;
      font-size: 17px;
      color: #8f9eb2;
      padding-left: 40px;

      &:hover,
      &.active {
        color: #fff;
        background: #606d80;
        border-left: 10px solid #fff;
        padding-left: 30px;

        .arrow-margin {
          transform: rotate(90deg);
        }
      }

      .arrow-margin {
        margin-left: auto;
        margin-right: 15px;
      }
    }

    .layer-2 {
      background-color: #263540;
      padding: 12px 0 12px 40px;
      font-size: 15px;

      .layer-2-button {
        display: flex;
        align-items: center;
        min-height: 30px;
        color: #a1bde5;
        text-decoration: none;
        cursor: pointer;

        &:hover,
        &.active {
          color: #fff;
        }
      }
    }
  }
}
</style>
