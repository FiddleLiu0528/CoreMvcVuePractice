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
    keepAliveRouteFullNameList: [] as string[],
  }),
  getters: {},
  actions: {
    ToggleSideBarDisplay() {
      this.isSideBarDisplay = !this.isSideBarDisplay;
    },
    UpdateRouteTokeepAliveRouteFullNameList(target: string) {
      if (target === "/") return;

      if (this.keepAliveRouteFullNameList.includes(target)) return;

      this.keepAliveRouteFullNameList.push(target);
    },
    EmptyRouteTokeepAliveRouteFullNameList() {
      this.keepAliveRouteFullNameList = [];
    },
  },
});
