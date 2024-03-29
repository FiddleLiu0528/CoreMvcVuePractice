import { onBeforeMount } from "vue";
import { useStore } from "@/store/main";
import { storeToRefs } from "pinia";
import { useI18n } from "vue-i18n";
import appsettings from "../../../../appsettings.json";

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
    locale.value = selectedLanguage.value;
    window.localStorage.setItem(LangStorageKey, selectedLanguage.value);
  };

  const SetDefaultUserInfo = () => {
    // 取得後端輸出的使用者資料並更新至倉儲
    if (process.env.NODE_ENV === "production") {
      const target = JSON.parse(
        (<HTMLInputElement>document.getElementById("USER_INFO")).value
      );
      userInfo.value.account = target.account;
      userInfo.value.nickname = target.nickname;
    }

    // DEV: 開發專用代碼，編譯時會 treeshaking 移除
    if (process.env.NODE_ENV === "development") {
      userInfo.value.account = appsettings.BackEnd.EngineerInfo.Account;
      userInfo.value.nickname = appsettings.BackEnd.EngineerInfo.Nickname;
    }
  };
}
