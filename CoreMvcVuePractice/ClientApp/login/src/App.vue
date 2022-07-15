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

  <div class="submit-block">
    <button>{{ $t("titleLogin") }}</button>
  </div>
</template>

<script lang="ts" setup>
import { ref, watch } from "vue";
import { useI18n } from "vue-i18n";

const { availableLocales, locale } = useI18n();

const inputAccount = ref<string>("");
const inputPw = ref<string>("");

const selectedLanguage = ref<string>(locale.value);

watch(selectedLanguage, () => {
  locale.value = selectedLanguage.value;
});
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
  }
}

input,
select,
button {
  border: 0;
  outline: none;
}
</style>
