import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

import * as actions from "./actions";
import * as mutations from "./mutations";
import * as getters from "./getters";

const store = new Vuex.Store({
  strict: true,
  actions,
  mutations,
  getters,
  state: {
    auth: null,
    showAuthModal: false,
    loading: false,
    cart: [],
    products: [],
    filters: [],
    product: null,
    orders: []
  }
});

if (typeof window !== "undefined") {
  store.subscribe((mutation, state) => {
    const cartMutations = [
      "addProductToCart",
      "updateProductQuantity",
      "removeProductFromCart",
      "setProductQuantity",
      "clearCartItems"
    ];

    if (cartMutations.indexOf(mutation.type) >= 0) {
      localStorage.setItem("cart", JSON.stringify(state.cart));
    }
  });
}

export default store;
