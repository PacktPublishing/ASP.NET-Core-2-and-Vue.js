import { app, router, store } from "./app";
import axios from "axios";
import Cookie from "js-cookie";

export default context => {
  return new Promise((resolve, reject) => {
    const auth = context.cookies.find(c => c.key === "AUTH");
    if (auth) {
      store.commit("loginSuccess", JSON.parse(auth.value));
      if (store.getters.isAuthenticated) {
        axios.defaults.headers.common["Authorization"] = `Bearer ${
          store.state.auth.access_token
        }`;
      }
    }

    router.push(context.url);

    router.onReady(() => {
      const matchedComponents = router.getMatchedComponents();
      if (!matchedComponents.length) {
        return reject(new Error({ code: 404 }));
      }
      Promise.all(
        matchedComponents.map(Component => {
          if (Component.asyncData) {
            return Component.asyncData({ store, route: router.currentRoute });
          }
        })
      )
        .then(() => {
          context.state = store.state;
          resolve(app);
        })
        .catch(reject);
    }, reject);
  });
};
