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
