import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

import { createPinia } from "pinia";
const pinia = createPinia();

import i18n from "@/lang/i18n";

import "@/assets/icons/";
import SvgIcon from "@/components/general/SvgIcon.vue";

import ClickOutside from "@/directives/ClickOutside";

createApp(App)
  .use(router)
  .use(pinia)
  .use(i18n)
  .component("SvgIcon", SvgIcon)
  .directive("click-outside", ClickOutside)
  .mount("#app");
