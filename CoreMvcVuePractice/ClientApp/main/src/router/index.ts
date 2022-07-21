import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import LayOut from "@/components/layout/LayOut.vue";

import { useStore } from "@/store/main";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    component: LayOut,
  },

  // password-setting
  {
    path: "/password-setting",
    component: LayOut,
    redirect: "/password-setting/password-modify",
    children: [
      {
        path: "password-modify",
        name: "PasswordModify",
        component: () =>
          import(
            "@/components/content-range/password-setting/PasswordModify.vue"
          ),
      },
    ],
  },

  // member-manage
  {
    path: "/member-manage",
    component: LayOut,
    redirect: "/member-manage/member-list",
    children: [
      {
        path: "member-list",
        name: "MemberList",
        component: () =>
          import("@/components/content-range/member-manage/MemberList.vue"),
      },
    ],
  },

  // backstage-manage
  {
    path: "/backstage-manage",
    component: LayOut,
    redirect: "/backstage-manage/right-manage",
    children: [
      {
        path: "right-manage",
        name: "RightManage",
        component: () =>
          import("@/components/content-range/backstage-manage/RightManage.vue"),
      },
      {
        path: "account-manage",
        name: "AccountManage",
        component: () =>
          import(
            "@/components/content-range/backstage-manage/AccountManage.vue"
          ),
      },
      {
        path: "system-setting",
        name: "SystemSetting",
        component: () =>
          import(
            "@/components/content-range/backstage-manage/SystemSetting.vue"
          ),
      },
    ],
  },

  {
    path: "/:pathMatch(.*)*",
    redirect: "/",
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

router.beforeEach((to, from) => {
  const store = useStore();
  store.UpdateRouteTokeepAliveRouteFullNameList(to.path);
});

export default router;
