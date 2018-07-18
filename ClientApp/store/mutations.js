export const addProductToCart = (state, product) => {
  product.quantity = 1;
  state.cart.push(product);
};

export const updateProductQuantity = (state, index) => {
  let cartItem = Object.assign({}, state.cart[index]);
  cartItem.quantity++;

  state.cart.splice(index, 1, cartItem);
};

export const removeProductFromCart = (state, index) => {
  state.cart.splice(index, 1);
};

export const setProductQuantity = (state, payload) => {
  let cartItem = Object.assign({}, state.cart[payload.index]);
  cartItem.quantity = payload.quantity;

  state.cart.splice(payload.index, 1, cartItem);
};

export const initialise = state => {
  const store = localStorage.getItem("store");
  if (store) {
    Object.assign(state, JSON.parse(store));
  }
};
