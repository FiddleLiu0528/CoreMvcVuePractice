import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import LayOut from "@/components/layout/LayOut.vue";

import { useStore } from "@/store/main";

const routes: Array<RouteRecordRaw> = [
  // root
  {
    path: "/",
    component: LayOut,
  },

  // password-setting
  {
    path: "/password-setting",
    component: LayOut,
    redirect: "/password-setting/password-modify",
    meta: {},
    children: [
      {
        path: "password-modify",
        component: () =>
          import(
            "@/components/content-range/password-setting/PasswordModify.vue"
          ),
        meta: {},
      },
    ],
  },

  // members-management
  {
    path: "/members-management",
    component: LayOut,
    redirect: "/members-management/members-list",
    meta: {
      isDisplayOnSideBar: true,
    },
    children: [
      {
        path: "members-list",
        component: () =>
          import(
            "@/components/content-range/members-management/MembersList.vue"
          ),
        meta: {
          isDisplayOnSideBar: true,
        },
      },
    ],
  },

  // backstage-management
  {
    path: "/backstage-management",
    component: LayOut,
    redirect: "/backstage-management/permission-management",
    meta: {
      isDisplayOnSideBar: true,
    },
    children: [
      {
        path: "permission-management",
        component: () =>
          import(
            "@/components/content-range/backstage-management/PermissionManagement.vue"
          ),
        meta: {
          isDisplayOnSideBar: true,
        },
      },
      {
        path: "account-management",
        component: () =>
          import(
            "@/components/content-range/backstage-management/AccountManagement.vue"
          ),
        meta: {
          isDisplayOnSideBar: true,
        },
      },
      {
        path: "system-setting",
        component: () =>
          import(
            "@/components/content-range/backstage-management/SystemSetting.vue"
          ),
        meta: {
          isDisplayOnSideBar: true,
        },
      },
    ],
  },

  // 匹配不到轉導至首頁
  {
    path: "/:pathMatch(.*)*",
    redirect: "/",
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

router.beforeEach((to) => {
  const store = useStore();

  if (to.path === "/") {
    store.EmptyRouteTokeepAliveRoutePathList();
  }

  store.UpdateRouteTokeepAliveRoutePathList(to.path);
});

export default router;
