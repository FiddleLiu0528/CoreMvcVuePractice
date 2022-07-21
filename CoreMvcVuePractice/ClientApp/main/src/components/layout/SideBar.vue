<template>
  <div class="side-bar-block">
    <div
      class="web-site-title"
      @click="
        router.push('/');
        store.EmptyRouteTokeepAliveRouteFullNameList();
      "
    >
      <span>管理後台</span>
      <span>測試站</span>
    </div>

    <div class="">
      會員管理
      <div @click="RouterPushAndKeepAlive('/member-manage/member-list')">
        會員列表
      </div>
    </div>

    <div>
      後台管理
      <div @click="RouterPushAndKeepAlive('/backstage-manage/right-manage')">
        權限管理
      </div>
      <div @click="RouterPushAndKeepAlive('/backstage-manage/account-manage')">
        帳號管理
      </div>
      <div @click="RouterPushAndKeepAlive('/backstage-manage/system-setting')">
        系統設置
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useRouter } from "vue-router";
import { useStore } from "../../store/main";

const router = useRouter();
const store = useStore();

const RouterPushAndKeepAlive = (target: string) => {
  store.UpdateRouteTokeepAliveRouteFullNameList(target);
  router.push(target);
};
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
