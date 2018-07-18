import axios from "axios";
import Cookie from "js-cookie";

export const addProductToCart = ({ state, commit }, product) => {
  const index = state.cart.findIndex(
    i =>
      i.productId === product.productId &&
      i.colourId === product.colourId &&
      i.storageId === product.storageId
  );

  if (index >= 0) {
    commit("updateProductQuantity", index);
  } else {
    commit("addProductToCart", product);
  }
};

export const removeProductFromCart = ({ state, commit }, product) => {
  const index = state.cart.findIndex(
    i =>
      i.productId === product.productId &&
      i.colourId === product.colourId &&
      i.storageId === product.storageId
  );

  commit("removeProductFromCart", index);
};

export const setProductQuantity = ({ state, commit }, payload) => {
  const index = state.cart.findIndex(
    i =>
      i.productId === payload.product.productId &&
      i.colourId === payload.product.colourId &&
      i.storageId === payload.product.storageId
  );

  if (payload.quantity > 0) {
    payload.index = index;
    commit("setProductQuantity", payload);
  } else {
    commit("removeProductFromCart", index);
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
        Cookie.set("AUTH", JSON.stringify(auth));
        resolve(response);
      })
      .catch(error => {
        commit("loginError");
        delete axios.defaults.headers.common["Authorization"];
        Cookie.remove("AUTH");
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
  Cookie.remove("AUTH");
};

export const fetchProducts = ({ commit }, query) => {
  return new Promise((resolve, reject) => {
    return axios.get("/api/products", { params: query }).then(response => {
      commit("setProducts", response.data);
      resolve(response);
    });
  });
};

export const fetchFilters = ({ commit }) => {
  return new Promise((resolve, reject) => {
    return axios.get("/api/filters").then(response => {
      commit("setFilters", response.data);
      resolve(response);
    });
  });
};

export const fetchProduct = ({ commit }, slug) => {
  return new Promise((resolve, reject) => {
    return axios.get(`/api/products/${slug}`).then(response => {
      commit("setProduct", response.data);
      resolve(response);
    });
  });
};

export const fetchOrders = ({ commit }) => {
  return new Promise((resolve, reject) => {
    return axios.get("/api/orders").then(response => {
      commit("setOrders", response.data);
      resolve(response);
    });
  });
};
