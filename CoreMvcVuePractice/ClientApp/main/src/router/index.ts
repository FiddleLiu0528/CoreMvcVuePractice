import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import LayOut from "@/components/layout/LayOut.vue";
import PageA from "@/components/views/first-group/PageA.vue";
import PageB from "@/components/views/first-group/PageB.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    component: LayOut,
  },

  {
    path: "/first-group",
    component: LayOut,
    children: [
      {
        path: "page-a",
        component: PageA,
      },
      {
        path: "page-b",
        component: PageB,
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

export default router;
