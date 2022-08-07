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
    refreshPage: null as string | null,
    keepAliveRoutePathList: [] as string[],
  }),
  getters: {},
  actions: {
    ToggleSideBarDisplay() {
      this.isSideBarDisplay = !this.isSideBarDisplay;
    },

    UpdateRouteTokeepAliveRoutePathList(target: string) {
      if (target === "/") return;

      if (this.keepAliveRoutePathList.includes(target)) return;

      this.keepAliveRoutePathList.push(target);
    },

    EmptyRouteTokeepAliveRoutePathList() {
      this.keepAliveRoutePathList = [];
    },
  },
});
