import Vue from "vue";
import VueRouter from "vue-router";
import NProgress from "nprogress";

import routes from "./routes";
import store from "../store";

Vue.use(VueRouter);

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

export default router;
