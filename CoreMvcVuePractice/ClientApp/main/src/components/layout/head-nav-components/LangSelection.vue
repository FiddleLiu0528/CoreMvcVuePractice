<template>
  <div
    v-click-outside:[langSelectionRef]="HideLanguageSelector"
    class="lang-selection"
    ref="langSelectionRef"
  >
    <span class="nav-icon" @click="isDisplay = !isDisplay">
      {{ $t(selectedLanguage) }}
    </span>

    <div v-if="isDisplay" class="lang-Box">
      <div @click="SetSelectedLanguageAbbr('zh')">{{ $t("zh") }}</div>
      <div @click="SetSelectedLanguageAbbr('cn')">{{ $t("cn") }}</div>
      <div @click="SetSelectedLanguageAbbr('en')">{{ $t("en") }}</div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useStore } from "@/store/main";
import { storeToRefs } from "pinia";
import { ref } from "vue";
import { useI18n } from "vue-i18n";

const { locale } = useI18n();
const store = useStore();

const langSelectionRef = ref<null | HTMLElement>(null);
const { selectedLanguage } = storeToRefs(store);
const isDisplay = ref<boolean>(false);

const HideLanguageSelector = () => {
  isDisplay.value = false;
};

const SetSelectedLanguageAbbr = (target: string) => {
  selectedLanguage.value = target;
  locale.value = selectedLanguage.value;
  const LangStorageKey = "locale";
  window.localStorage.setItem(LangStorageKey, locale.value);
  HideLanguageSelector();
};
</script>

<style lang="scss" scoped>
.lang-selection {
  position: relative;
  cursor: pointer;
  margin: 0 8px;

  .nav-icon {
    cursor: pointer;
    color: #263540;

    &:hover {
      color: #77a0d9;
    }
  }

  .lang-Box {
    position: absolute;
    width: 50px;
    text-align: center;
    border-radius: 3px;
    background: #dee6ef;
    box-shadow: 0 0 3px rgb(0 0 0 / 20%);
    z-index: 100;
    top: 30px;
    left: 50%;
    transform: translate(-50%);

    div {
      line-height: 28px;
      &:hover {
        background: #fefefe;
      }
    }

    &:before {
      content: "";
      border-style: solid;
      border-width: 0 7px 7px 7px;
      border-color: transparent transparent #dee6ef transparent;
      position: absolute;
      z-index: 100;
      top: -7px;
      left: 18px;
    }
  }
}
</style>
