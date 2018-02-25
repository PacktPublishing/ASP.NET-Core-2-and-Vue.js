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
