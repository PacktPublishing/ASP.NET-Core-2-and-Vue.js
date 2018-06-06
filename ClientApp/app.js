import Vue from "vue";
import VeeValidate from "vee-validate";
import router from "./router";
import store from "./store";
import { currency, date } from "./filters";
import { sync } from "vuex-router-sync";
import Cookie from "js-cookie";
import axios from "axios";
import "./helpers/interceptors";
import App from "./components/App.vue";

Vue.use(VeeValidate);
Vue.filter("currency", currency);
Vue.filter("date", date);

sync(store, router);

axios.defaults.baseURL =
  process.env.NODE_ENV === "production"
    ? "https://phoneshop/azurewebsites/net"
    : "http://localhost:5000";

const auth = Cookie.get("AUTH");
if (auth) {
  store.commit("loginSuccess", JSON.parse(auth));
  axios.defaults.headers.common["Authorization"] = `Bearer ${
    store.state.auth.access_token
  }`;
}

const app = new Vue({
  router,
  store,
  render: h => h(App)
});

export { app, router, store };
