// 引入 Svg(都寫成 Sprites 了), 使用 Symbol 的標籤, 透過 use 可以顯示該 Svg,
// 所有 Svg 放在 /src/assets/icons/sprites 直接引入後使用
// Svg 放在 /src/assets/icons/svg 方便查看該 Svg 長怎樣
const req = require.context("@/assets/icons/sprites", false, /\.svg$/);
const requireAll = (requireContext: any) =>
  requireContext.keys().map(requireContext);
requireAll(req);
