import Vue from "vue";
import VueRouter from "vue-router";
import store from "./store";
import BootstrapVue from "bootstrap-vue";
import NProgress from "nprogress";
import VueToastr from "@deveodk/vue-toastr";
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css";

Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.use(VueToastr, {
  defaultPosition: "toast-top-right"
});

// filters
import { currency } from "./filters";

Vue.filter("currency", currency);

//import page components
import Catalogue from "./pages/Catalogue.vue";
import Product from "./pages/Product.vue";
import Cart from "./pages/Cart.vue";
import Checkout from "./pages/Checkout.vue";

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

const routes = [
  { path: "/products", component: Catalogue },
  { path: "/products/:slug", component: Product },
  { path: "/cart", component: Cart },
  { path: "/checkout", component: Checkout, meta: { requiresAuth: true } },
  { path: "*", redirect: "/products" }
];

const router = new VueRouter({ mode: "history", routes: routes });

router.beforeEach((to, from, next) => {
  NProgress.start();
  if (to.matched.some(route => route.meta.requiresAuth)) {
    if (!store.getters.isAuthenticated) {
      store.commit("showAuthModal");
      next({ path: from.path, query: { redirect: to.path } });
    } else {
      next();
    }
  } else {
    next();
  }
});

router.afterEach((to, from) => {
  NProgress.done();
});

new Vue({
  el: "#app-root",
  router: router,
  store,
  render: h => h(require("./components/App.vue"))
});
