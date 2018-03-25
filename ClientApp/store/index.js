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
    cart: []
  }
});

store.subscribe((mutation, state) => {
  localStorage.setItem("store", JSON.stringify(state));
});

export default store;
