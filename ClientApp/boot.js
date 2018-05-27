import Vue from "vue";
import router from "./router";
import store from "./store";
import BootstrapVue from "bootstrap-vue";
import VueToastr from "@deveodk/vue-toastr";
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css";
import VeeValidate from "vee-validate";

//helpers
import "./helpers/validation";
import "./helpers/interceptors";

Vue.use(BootstrapVue);
Vue.use(VueToastr, {
  defaultPosition: "toast-top-right"
});
Vue.use(VeeValidate);

// filters
import { currency, date } from "./filters";

Vue.filter("currency", currency);
Vue.filter("date", date);

import axios from "axios";
const initialStore = localStorage.getItem("store");

if (initialStore) {
  store.commit("initialise", JSON.parse(initialStore));
  if (store.getters.isAuthenticated) {
    axios.defaults.headers.common["Authorization"] = `Bearer ${
      store.state.auth.access_token
    }`;
  }
}

new Vue({
  el: "#app-root",
  router,
  store,
  render: h => h(require("./components/App.vue"))
});
