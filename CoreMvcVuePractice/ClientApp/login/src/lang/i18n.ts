import { createI18n } from "vue-i18n";

import cn from "./locale/cn.json";
import en from "./locale/en.json";
import zh from "./locale/zh.json";

const i18n = createI18n({
  locale: "en",
  fallbackLocale: "zh",
  messages: {
    cn,
    en,
    zh,
  },
});

export default i18n;
