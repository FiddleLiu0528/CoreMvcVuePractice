<template>
  <section class="label-block">
    <div class="label-range">
      <div
        v-for="(item, index) in parsedObj"
        :key="index"
        :title="LabelText(item.path)"
        class="label"
        :class="{ active: item.isActive }"
        @click="router.push(item.path)"
        @click.middle="RemoveFromKeepAliveList(item.path)"
        draggable="true"
        @dragenter.prevent
        @dragover.prevent
        @dragstart="DragStart(item.path)"
        @dragenter="DragEnter(item.path)"
        @dragend="DragEnd()"
      >
        <span class="label-text">{{ LabelText(item.path) }}</span>
        <SvgIcon
          width="15"
          height="15"
          class="close-x"
          iconType="custom"
          iconName="close-x"
          @click.stop="RemoveFromKeepAliveList(item.path)"
        />
      </div>
    </div>

    <img
      class="open-new-tab"
      src="@/assets/images/btn_newPage.png"
      @click="OpenSiteInNewTab()"
      draggable="false"
      @drop.prevent
    />
  </section>
</template>

<script lang="ts" setup>
import { useStore } from "../../../store/main";
import { storeToRefs } from "pinia";
import { computed, ref } from "vue";
import { useRouter, useRoute } from "vue-router";
import { useI18n } from "vue-i18n";

const store = useStore();
const router = useRouter();
const route = useRoute();
const { keepAliveRoutePathList } = storeToRefs(store);
const { t } = useI18n();

const parsedObj = computed(() => {
  return keepAliveRoutePathList.value.map((el) => ({
    path: el,
    isActive: route.path === el,
  }));
});

const draggingLabelPath = ref<string | null>(null);

const DragStart = (path: string) => {
  draggingLabelPath.value = path;
};

const DragEnter = (path: string) => {
  const fromIndex = keepAliveRoutePathList.value.findIndex(
    (el) => el === draggingLabelPath.value
  );
  const targetIndex = keepAliveRoutePathList.value.findIndex(
    (el) => el === path
  );
  if (fromIndex === targetIndex) return;

  [
    keepAliveRoutePathList.value[targetIndex],
    keepAliveRoutePathList.value[fromIndex],
  ] = [
    keepAliveRoutePathList.value[fromIndex],
    keepAliveRoutePathList.value[targetIndex],
  ];
};

const DragEnd = () => {
  draggingLabelPath.value = null;
};

const RemoveFromKeepAliveList = (target: string) => {
  keepAliveRoutePathList.value = keepAliveRoutePathList.value.filter(
    (item) => item !== target
  );

  if (keepAliveRoutePathList.value.includes(route.path)) return;

  const nextRoute = keepAliveRoutePathList.value.at(-1);
  if (nextRoute) {
    router.push(nextRoute);
    return;
  }

  if (keepAliveRoutePathList.value.length === 0) router.push("/");
};

const OpenSiteInNewTab = () => {
  window.open(window.location.origin, "_blank");
};

const LabelText = (path: string) => {
  const targetPathString = path.split("/").at(-1) ?? "";
  return t(`router.${targetPathString}`);
};
</script>

<style lang="scss" scoped>
.label-block {
  display: flex;
  overflow: hidden;
  flex-shrink: 0;
  z-index: 1;

  .label-range {
    flex-grow: 1;
    display: flex;
    flex-wrap: wrap;

    .label {
      display: flex;
      align-items: center;

      box-sizing: border-box;
      border-top: 5px solid #b3b3b3;
      background-color: #d9d9d9;
      padding: 5px 15px;
      margin-right: 8px;
      box-shadow: 0 -2px 2px #eee;

      cursor: pointer;
      user-select: none;

      .label-text {
        white-space: nowrap;
      }

      &.active {
        border-top: 5px solid #77a0d9;
        background-color: #fff;
      }

      .close-x {
        margin-left: 0.5rem;
        color: #888;

        &:hover {
          color: #1979ff;
        }
      }
    }
  }

  .open-new-tab {
    cursor: pointer;
    margin-top: auto;
    flex-shrink: 0;
  }
}

[draggable="true"] {
  /*
   To prevent user selecting inside the drag source
  */
  user-select: none;
  -moz-user-select: none;
  -webkit-user-select: none;
  -ms-user-select: none;
}
</style>
