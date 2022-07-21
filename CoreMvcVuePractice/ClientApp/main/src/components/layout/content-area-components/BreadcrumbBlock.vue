<template>
  <div class="breadcrumb-block">
    <div
      v-for="(item, index) in breadcrumbList"
      :key="index"
      class="breadcrumb-item"
    >
      <span class="active">{{ item }}</span>

      <img
        v-if="index < breadcrumbList.length - 1"
        src="@/assets/images/icon_subMenu.png"
      />
    </div>
  </div>
</template>

<script lang="ts" setup>
import { reactive } from "vue";
const breadcrumbList = reactive(["會員管理", "等級權限設定", "修改紀錄"]);
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
