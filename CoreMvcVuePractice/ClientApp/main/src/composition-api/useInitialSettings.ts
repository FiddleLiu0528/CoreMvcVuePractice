import { onBeforeMount } from "vue";
import { useStore } from "@/store/main";
import { storeToRefs } from "pinia";
import FrontEndTestSetting from "@/mock/FrontEndTestSetting.json";
import { useI18n } from "vue-i18n";

export default function useInitialSettings() {
  const { availableLocales, locale } = useI18n();
  const store = useStore();
  const { userInfo, selectedLanguage } = storeToRefs(store);

  onBeforeMount(() => {
    SetDefaultSelectedLanguage();
    SetDefaultUserInfo();
  });

  const SetDefaultSelectedLanguage = () => {
    const LangStorageKey = "locale";
    const lang = window.localStorage.getItem(LangStorageKey) ?? "";
    const isExist = availableLocales.includes(lang);

    selectedLanguage.value = isExist ? lang : locale.value;
    window.localStorage.setItem(LangStorageKey, locale.value);
  };

  const SetDefaultUserInfo = () => {
    //TODO:實作 前端開發與前後端整合開發的測試資料流程
    if (process.env.NODE_ENV === "production") {
    }

    // DEV: 開發專用代碼，編譯時會treeshaking
    if (process.env.NODE_ENV === "development") {
      userInfo.value.account = FrontEndTestSetting.userInfo.account;
      userInfo.value.nickname = FrontEndTestSetting.userInfo.account;
    }
  };
}
