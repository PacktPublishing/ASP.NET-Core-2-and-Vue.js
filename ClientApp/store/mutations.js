export const addProductToCart = (state, product) => {
  product.quantity = 1;
  state.cart.push(product);
};

export const updateProductQuantity = (state, product) => {
  let cartItem = state.cart.find(
    i =>
      i.productId === product.productId &&
      i.colourId === product.colourId &&
      i.storageId === product.storageId
  );

  cartItem.quantity++;
};

export const removeProductFromCart = (state, product) => {
  const index = state.cart.indexOf(product);
  state.cart.splice(index, 1);
};

export const setProductQuantity = (state, payload) => {
  const index = state.cart.indexOf(payload.product);
  let cartItem = state.cart[index];
  cartItem.quantity = payload.quantity;

  state.cart.splice(index, 1, Object.assign({}, cartItem));
};
