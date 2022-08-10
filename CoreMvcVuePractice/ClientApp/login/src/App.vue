<template>
  <div class="account-block">
    <span>{{ $t("titleAccount") }}</span>
    <input type="text" v-model="inputAccount" />
  </div>

  <div class="pw-block">
    <span>{{ $t("titlePw") }}</span>
    <input type="password" v-model="inputPw" />
  </div>

  <div class="lang-block">
    <span>{{ $t("titleLanguage") }}</span>
    <select v-model="selectedLanguage">
      <option v-for="item in availableLocales" :key="item" :value="item">
        {{ $t(item) }}
      </option>
    </select>
  </div>

  <div class="verify-block" v-if="LoginValidateType === 'TextCaptcha'">
    <img
      class="text-image"
      :src="validateTextImageSrc"
      @click="
        RetrieveValidateTextImage();
        inputValidateTextRef?.focus();
      "
    />
    <input ref="inputValidateTextRef" type="text" v-model="inputValidateText" />
  </div>

  <div class="submit-block">
    <button @click="VerifyLogin()" :disabled="!isAbleToVerifyLogin">
      {{ $t("titleLogin") }}
    </button>
  </div>
</template>

<script lang="ts" setup>
import { ref, watch, onBeforeMount } from "vue";
import { useI18n } from "vue-i18n";
import { inject } from "vue";
import { computed } from "@vue/reactivity";
const md5 = require("md5");

const LangStorageKey = "locale";
const { availableLocales, locale } = useI18n();
const ErrorCodeConvertToText: any = inject("ErrorCodeConvertToText");
const axios: any = inject("axios");

const inputAccount = ref<string>("");
const inputPw = ref<string>("");

const selectedLanguage = ref<string>(locale.value);

const LoginValidateType = ref<string>(process.env.VUE_APP_LOGIN_VALIDATE_TYPE);
const inputValidateTextRef = ref<null | { focus: () => null }>(null);
const validateTextImageSrc = ref<string>("");
const inputValidateText = ref<string>("");

onBeforeMount(() => {
  var lang = window.localStorage.getItem(LangStorageKey) ?? "";
  const isExist = availableLocales.includes(lang);

  selectedLanguage.value = isExist ? lang : locale.value;
  window.localStorage.setItem(LangStorageKey, locale.value);

  RetrieveValidateTextImage();
});

const isAbleToVerifyLogin = computed(() => {
  if (!inputAccount.value || !inputPw.value) return false;
  if (LoginValidateType.value === "TextCaptcha" && !inputValidateText.value) {
    return false;
  }

  return true;
});

watch(selectedLanguage, () => {
  locale.value = selectedLanguage.value;
  window.localStorage.setItem(LangStorageKey, locale.value);
});

const RetrieveValidateTextImage = (): void => {
  axios
    .post("/api/Verification/RetrieveValidateTextImage")
    .then((response: { data: any }) => {
      if (response.data.errorCode !== 0) {
        alert(ErrorCodeConvertToText(response.data.errorCode));
        return;
      }

      validateTextImageSrc.value = response.data.result.textImage;
    });
};

const VerifyValidateTextImageResult = () => {
  return axios
    .post("/api/Verification/VerifyValidateTextImageResult", {
      textResult: inputValidateText.value,
    })
    .then((response: { data: any }) => {
      if (response.data.errorCode !== 0) {
        alert(ErrorCodeConvertToText(response.data.errorCode));
        ResetValidateInfo();
        RetrieveValidateTextImage();
        return false;
      }
      return true;
    });
};

const VerifyLogin = async (): Promise<void> => {
  if (LoginValidateType.value === "TextCaptcha") {
    const isVerifySuccess = await VerifyValidateTextImageResult();
    if (!isVerifySuccess) return;
  }

  const queryObject = {
    Account: inputAccount.value,
    Pw: md5(`${process.env.VUE_APP_PW_ENCRYPT_CODE}${inputPw.value}`),
  };

  axios
    .post("/api/Verification/VerifyLogin", queryObject)
    .then((response: { data: any }) => {
      if (response.data.errorCode !== 0) {
        alert(ErrorCodeConvertToText(response.data.errorCode));
        ResetValidateInfo();
        return;
      }

      location.href = "/";
    });
};

const ResetValidateInfo = (): void => {
  inputPw.value = "";
};
</script>

<style lang="scss">
html,
body {
  height: 100%;
  width: 100%;
}

body {
  margin: 0;
  font-family: Arial, "Microsoft JhengHei";
}

#app {
  height: 100%;
  width: 100%;
  background-color: #212126;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

  .account-block,
  .pw-block,
  .lang-block,
  .verify-block,
  .submit-block {
    display: flex;
    flex-direction: column;
    justify-content: center;
    margin-top: 20px;
    width: 200px;

    &.submit-block {
      margin-top: 50px;
      margin-bottom: 50px;
    }

    > button {
      height: 35px;
      border-radius: 20px;
      font-size: 15px;
      font-weight: bold;
      background: linear-gradient(to right, #c78426 0%, #fbb85a 100%);
      cursor: pointer;
      width: 100%;

      &:hover {
        background: #fbb85a;
      }

      &:disabled {
        cursor: not-allowed;
        background: #ccc;
      }
    }

    span {
      color: #b8c5cc;
      text-align: center;
      height: 30px;
    }

    input,
    select {
      height: 35px;
      border-radius: 20px;
      font-size: 15px;
      color: #1f2026;
      background: #fefefe;
      text-align: center;
    }

    .text-image {
      margin: auto;
      height: 50px;
      width: 150px;
      background-color: #cccccc;
      margin-bottom: 10px;
      cursor: pointer;
    }
  }
}

input,
select,
button {
  border: 0;
  outline: none;
}
</style>
