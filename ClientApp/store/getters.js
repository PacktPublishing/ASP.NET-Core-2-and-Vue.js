export const shoppingCartTotal = state => {
  const reducer = (accumulator, cartItem) =>
    accumulator + cartItem.price * cartItem.quantity;

  return state.cart.reduce(reducer, 0);
};

export const shoppingCartItemCount = state => {
  const reducer = (accumulator, cartItem) => accumulator + cartItem.quantity;
  return state.cart.reduce(reducer, 0);
};

export const isAuthenticated = state => {
  return (
    state.auth !== null &&
    state.auth.access_token !== null &&
    new Date(state.auth.access_token_expiration) > new Date()
  );
};

export const isInRole = (state, getters) => role => {
  const result = getters.isAuthenticated && state.auth.roles.indexOf(role) > -1;
  return result;
};
