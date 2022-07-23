const { defineConfig } = require("@vue/cli-service");

const options =
  process.env.NODE_ENV === "production"
    ? {
        transpileDependencies: true,
        publicPath: "/login/",
        indexPath: "template",
        outputDir: "../../wwwroot/login",
      }
    : {
        devServer: {
          proxy: "https://localhost:7151",
        },
        chainWebpack: (config) => {
          config.resolve.alias.set("vue-i18n", "vue-i18n/dist/vue-i18n.cjs.js"); // 避免vue-i18n套件警告
        },
      };

module.exports = defineConfig(options);
