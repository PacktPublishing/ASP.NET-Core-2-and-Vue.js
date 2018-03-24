import axios from "axios";

export const addProductToCart = ({ state, commit }, product) => {
  const exists = state.cart.find(
    i =>
      i.productId === product.productId &&
      i.colourId === product.colourId &&
      i.storageId === product.storageId
  );

  if (exists) {
    commit("updateProductQuantity", product);
  } else {
    commit("addProductToCart", product);
  }
};

export const removeProductFromCart = ({ commit }, product) => {
  commit("removeProductFromCart", product);
};

export const setProductQuantity = ({ commit }, payload) => {
  if (payload.quantity > 0) {
    commit("setProductQuantity", payload);
  } else {
    commit("removeProductFromCart", payload.product);
  }
};

export const login = ({ commit }, payload) => {
  return new Promise((resolve, reject) => {
    commit("loginRequest");
    axios
      .post("/api/token", payload)
      .then(response => {
        const auth = response.data;
        axios.defaults.headers.common["Authorization"] = `Bearer ${
          auth.access_token
        }`;
        commit("loginSuccess", auth);
        commit("hideAuthModal");
        resolve(response);
      })
      .catch(error => {
        commit("loginError");
        delete axios.defaults.headers.common["Authorization"];
        reject(error.response);
      });
  });
};

export const register = ({ commit }, payload) => {
  return new Promise((resolve, reject) => {
    commit("registerRequest");
    axios
      .post("/api/account", payload)
      .then(response => {
        commit("registerSuccess");
        resolve(response);
      })
      .catch(error => {
        commit("registerError");
        reject(error.response);
      });
  });
};

export const logout = ({ commit }) => {
  commit("logout");
  delete axios.defaults.headers.common["Authorization"];
};
