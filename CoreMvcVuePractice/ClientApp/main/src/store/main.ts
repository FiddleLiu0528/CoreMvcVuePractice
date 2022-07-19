import { defineStore } from "pinia";

export const useStore = defineStore("main", {
  state: () => ({
    selectedLanguage: "en",
    userInfo: {
      account: "-",
      nickname: "-",
      permission: [],
    },
    isSideMenuDisplay: true,
  }),
  getters: {},
  actions: {
    ToggleSideMenuDisplay() {
      this.isSideMenuDisplay = !this.isSideMenuDisplay;
    },
  },
});
