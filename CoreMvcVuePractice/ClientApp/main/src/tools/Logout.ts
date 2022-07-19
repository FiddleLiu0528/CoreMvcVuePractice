import axios from "axios";

// 清除 Cookies
function DeleteAllCookies() {
  const cookies = document.cookie.split(";");

  for (let i = 0; i < cookies.length; i += 1) {
    const cookie = cookies[i];
    const eqPos = cookie.indexOf("=");
    const name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
    document.cookie = `${name}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`;
  }
}

// 登出
export default async function Logout() {
  DeleteAllCookies();

  const promiseFunc = async () =>
    axios
      .post(`${window.location.origin}/Logout`, null, { timeout: 100 })
      .then((response) => response.data)
      .catch((error) => console.warn(error));

  await promiseFunc();

  window.location.replace(`${window.location.origin}/Login`);
}
