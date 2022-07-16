import { createApp } from "vue";
import App from "@/App.vue";
import i18n from "@/lang/i18n";
import axios from "axios";
import VueAxios from "vue-axios";
import ErrorCodeConvertToText from "@/tools/ErrorCodeConvertToText";

const app = createApp(App);
app.use(i18n);
app.use(VueAxios, axios);
app.provide("axios", app.config.globalProperties.axios); // provide 'axios'
app.provide("ErrorCodeConvertToText", ErrorCodeConvertToText);
app.mount("#app");
