import i18n from "@/lang/i18n";
const { t } = i18n.global;

export default function ErrorCodeConvertToText(val: number): string {
  const Def: { [index: number]: string } = {
    [-1]: t("errorCode.unknown"),
    0: t("errorCode.success"),
    1: t("errorCode.fail"),
    2: t("errorCode.accountError"),
    3: t("errorCode.pwError"),
    4: t("errorCode.parameterError"),
    5: t("errorCode.timeoutError"),
    6: t("errorCode.otherError"),
  };

  return Def[val] || "";
}
