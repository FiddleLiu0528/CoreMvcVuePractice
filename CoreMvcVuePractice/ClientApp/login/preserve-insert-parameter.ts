// 讀取appsettings json 設定檔，並新增.env.local 檔，讓編譯時使用該靜態參數

(async () => {
  const fs = require("fs").promises;

  const appsettingsFile = await fs.readFile("../../appsettings.json", "utf-8");
  const PwEncryptCode =
    JSON.parse(appsettingsFile).FrontEnd.Login.PwEncryptCode;
  const LoginValidateType =
    JSON.parse(appsettingsFile).FrontEnd.Login.LoginValidateType;
  await fs.writeFile(
    ".env.development.local",
    `VUE_APP_PW_ENCRYPT_CODE = '${PwEncryptCode}'
VUE_APP_LOGIN_VALIDATE_TYPE = '${LoginValidateType}'`
  );
})();
