<template>
  <section class="label-block">
    <div class="label-range">
      <div
        v-for="(item, index) in parsedObj"
        :key="index"
        :title="'item'"
        class="label"
        :class="{ active: item.isActive }"
        @click="router.push(item.path)"
        @click.middle="RemoveFromKeepAliveList(item.path)"
        draggable="true"
        @drag="handleDrag($event)"
        @dragenter.prevent
        @dragover.prevent
      >
        <span class="label-text">{{ item.name }}</span>
        <SvgIcon
          width="15"
          height="15"
          class="close-x"
          iconType="custom"
          iconName="close-x"
          @click="RemoveFromKeepAliveList(item.path)"
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
import { computed } from "vue";
import { useRouter, useRoute } from "vue-router";

const store = useStore();
const router = useRouter();
const route = useRoute();
const { keepAliveRouteFullNameList } = storeToRefs(store);

const parsedObj = computed(() => {
  const routes = router.getRoutes();

  return keepAliveRouteFullNameList.value.map((el) => {
    const target = routes.find((route) => route.path === el);

    return {
      name: target?.name,
      path: el,
      isActive: route.path === el,
    };
  });
});

const RemoveFromKeepAliveList = (target: string) => {
  keepAliveRouteFullNameList.value = keepAliveRouteFullNameList.value.filter(
    (item) => item !== target
  );

  if (keepAliveRouteFullNameList.value.includes(route.path)) return;
  const nextRoute = keepAliveRouteFullNameList.value.at(-1);

  if (nextRoute) router.push(nextRoute);
};

const OpenSiteInNewTab = () => {
  window.open(window.location.origin, "_blank");
};

const handleDrag = (event: DragEvent) => {
  const selectedItem = event.target as HTMLElement;
  let list = selectedItem.parentElement as HTMLElement;
  const x = event.clientX;
  const y = event.clientY;

  let swapItem =
    document.elementFromPoint(x, y) === null
      ? selectedItem
      : (document.elementFromPoint(x, y) as HTMLElement);

  if (list === swapItem.parentNode) {
    swapItem =
      swapItem !== selectedItem.nextSibling
        ? swapItem
        : (swapItem.nextSibling as HTMLElement);
    list.insertBefore(selectedItem, swapItem);
  }
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
