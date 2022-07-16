// 讀取appsettings json 設定檔，並新增.env.local 檔，讓編譯時使用該靜態參數

const fs = require("fs").promises;

(async () => {
  const appsettingsFile = await fs.readFile("../../appsettings.json", "utf-8");
  const PwEncryptCode =
    JSON.parse(appsettingsFile).FrontEnd.Login.PwEncryptCode;
  await fs.writeFile(".env.local", `VUE_APP_PW_KEY = '${PwEncryptCode}'`);
})();
