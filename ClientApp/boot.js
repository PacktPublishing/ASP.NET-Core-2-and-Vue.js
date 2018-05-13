import Vue from "vue";
import VueRouter from "vue-router";
import store from "./store";
import BootstrapVue from "bootstrap-vue";
import NProgress from "nprogress";
import VueToastr from "@deveodk/vue-toastr";
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css";
import VeeValidate from "vee-validate";

//plugins
import "./helpers/validation";

Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.use(VueToastr, {
  defaultPosition: "toast-top-right"
});
Vue.use(VeeValidate);

// filters
import { currency, date } from "./filters";

Vue.filter("currency", currency);
Vue.filter("date", date);

//import page components
import Catalogue from "./pages/Catalogue.vue";
import Product from "./pages/Product.vue";
import Cart from "./pages/Cart.vue";
import Checkout from "./pages/Checkout.vue";
import Account from "./pages/Account.vue";

//import admin pages
import AdminIndex from "./pages/admin/Index.vue";
import AdminOrders from "./pages/admin/Orders.vue";
import AdminProducts from "./pages/admin/Products.vue";
import AdminCreateProduct from "./pages/admin/CreateProduct.vue";

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
  { path: "/cart", component: Cart, meta: { role: "Customer" } },
  {
    path: "/checkout",
    component: Checkout,
    meta: { requiresAuth: true, role: "Customer" }
  },
  {
    path: "/account",
    component: Account,
    meta: { requiresAuth: true, role: "Customer" }
  },
  {
    path: "/admin",
    component: AdminIndex,
    meta: { requiresAuth: true, role: "Admin" },
    redirect: "/admin/orders",
    children: [
      {
        path: "orders",
        component: AdminOrders
      },
      {
        path: "products",
        component: AdminProducts
      },
      {
        path: "products/create",
        component: AdminCreateProduct
      }
    ]
  },
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
      if (
        to.matched.some(
          route => route.meta.role && store.getters.isInRole(route.meta.role)
        )
      ) {
        next();
      } else if (!to.matched.some(route => route.meta.role)) {
        next();
      } else {
        next({ path: "/" });
      }
    }
  } else {
    if (
      to.matched.some(
        route =>
          route.meta.role &&
          (!store.getters.isAuthenticated ||
            store.getters.isInRole(route.meta.role))
      )
    ) {
      next();
    } else {
      if (to.matched.some(route => route.meta.role)) {
        next({ path: "/" });
      }

      next();
    }
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
