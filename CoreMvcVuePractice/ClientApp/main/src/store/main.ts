import { defineStore } from "pinia";

export const useStore = defineStore("main", {
  state: () => ({
    selectedLanguage: "",
    userInfo: {
      account: "-",
      nickname: "-",
      permission: [],
    },
    isSideBarDisplay: true,
    keepAliveRoutePathList: [] as string[],
  }),
  getters: {},
  actions: {
    ToggleSideBarDisplay() {
      this.isSideBarDisplay = !this.isSideBarDisplay;
    },

    UpdateRouteTokeepAliveRoutePathList(target: string) {
      if (target === "/" || target === "/refresh-router-view-page") return;

      if (this.keepAliveRoutePathList.includes(target)) return;

      this.keepAliveRoutePathList.push(target);
    },

    EmptyRouteTokeepAliveRoutePathList() {
      this.keepAliveRoutePathList = [];
    },
  },
});
