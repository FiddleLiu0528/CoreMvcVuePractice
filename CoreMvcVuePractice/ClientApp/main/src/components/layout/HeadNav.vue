<template>
  <div class="head-nav-block">
    <SvgIcon
      width="20"
      height="20"
      iconType="custom"
      :iconName="isSideBarDisplay ? 'menu-turn-off' : 'menu-turn-on'"
      class="nav-icon"
      :title="$t('headNav.menu')"
      @click="ToggleSideBarDisplay()"
    />

    <div class="account-range">
      <SvgIcon
        width="20"
        height="20"
        iconType="custom"
        iconName="admin"
        class="name-icon"
      />
      <span>{{ $t("headNav.user") }} ({{ userInfo.account }})</span>
    </div>

    <div class="split"></div>
    {{ userInfo.nickname }}
    <div class="split left"></div>

    <LangSelection />

    <SvgIcon
      width="20"
      height="20"
      class="nav-icon pw"
      iconType="custom"
      iconName="pw"
      :title="$t('headNav.changePwd')"
      @click="router.push('/password-setting/password-modify')"
    />

    <SvgIcon
      width="20"
      height="20"
      class="nav-icon log-out"
      iconType="custom"
      iconName="log-out"
      :title="$t('headNav.logout')"
      @click="Logout()"
    />
  </div>
</template>

<script setup lang="ts">
import { useStore } from "@/store/main";
import { storeToRefs } from "pinia";
import LangSelection from "@/components/layout/head-nav-components/LangSelection.vue";
import Logout from "@/tools/Logout";
import { useRouter } from "vue-router";

const store = useStore();
const { ToggleSideBarDisplay } = store;
const { isSideBarDisplay } = storeToRefs(store);
const { userInfo } = storeToRefs(store);
const router = useRouter();
</script>

<style lang="scss" scoped>
.head-nav-block {
  box-sizing: border-box;
  display: flex;
  align-items: center;

  height: 40px;
  box-shadow: 1px 2px 3px #ccc;
  padding: 10px;
  margin-bottom: 5px;

  white-space: nowrap;

  .nav-icon {
    cursor: pointer;
    color: #263540;
    flex-shrink: 0;

    &:hover {
      color: #77a0d9;
    }
  }

  .name-icon {
    margin: 8px;
  }

  .account-range {
    display: flex;
    align-items: center;
    margin-left: auto;
  }

  .split {
    height: 100%;
    border-right: 1px solid #3a3a3a;
    margin: 0 15px;
    &.left {
      margin: 0;
      margin-left: 15px;
    }

    &.right {
      margin: 0;
      margin-right: 15px;
    }
  }

  .pw,
  .log-out {
    margin: 8px;
  }
}
</style>
