import Vue from "vue";
import { app, router, store } from "./app";
import BootstrapVue from "bootstrap-vue";
import VueToastr from "@deveodk/vue-toastr";
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css";

Vue.use(BootstrapVue);
Vue.use(VueToastr, {
  defaultPosition: "toast-top-right"
});

if (window.__INITIAL_STATE__) {
  store.replaceState(__INITIAL_STATE__);
}

const cartItems = localStorage.getItem("cart");
if (cartItems) {
  store.commit("setCartItems", JSON.parse(cartItems));
}

router.onReady(() => {
  router.beforeResolve((to, from, next) => {
    const matched = router.getMatchedComponents(to);
    const prevMatched = router.getMatchedComponents(from);

    let diffed = false;
    const activated = matched.filter((c, i) => {
      return diffed || (diffed = prevMatched[i] !== c);
    });

    if (!activated.length) {
      return next();
    }

    Promise.all(
      activated.map(c => {
        if (c.asyncData) {
          return c.asyncData({ store, route: to });
        }
      })
    )
      .then(() => {
        next();
      })
      .catch(next);
  });

  app.$mount("#app-root");
});
