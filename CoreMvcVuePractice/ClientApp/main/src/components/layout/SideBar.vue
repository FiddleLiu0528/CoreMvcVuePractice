<template>
  <div class="side-bar-block">
    <div class="web-site-title">
      <span>管理後台</span>
      <span>測試站</span>
    </div>

    <div>
      會員管理
      <div>會員列表</div>
    </div>

    <div>
      後台管理
      <div>權限管理</div>
      <div>帳號管理</div>
      <div>系統設置</div>
    </div>

    <span>first group</span>
    <span @click="router.push(`/first-group/page-a`)">page A</span>
    <span @click="router.push(`/first-group/page-b`)">page B</span>
  </div>
</template>

<script lang="ts" setup>
import { useRouter } from "vue-router";
const router = useRouter();
</script>

<style lang="scss" scoped>
.side-bar-block {
  height: 100%;
  width: 210px;
  min-width: 210px;
  background-color: #2e3b4d;
  border-right: 1px solid #c8c8c8;
  overflow: auto;

  .web-site-title {
    display: flex;
    flex-direction: column;

    padding: 30px 0 15px 40px;
    cursor: pointer;
    font-size: 17px;
    color: #fefefe;
  }
}
</style>
