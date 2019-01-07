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
  return state.auth !== null && state.auth.access_token !== null;
};

export const isInRole = (state, getters) => role => {
  const result = getters.isAuthenticated && state.auth.roles.indexOf(role) > -1;
  return result;
};

export const sortedProducts = state => {
  switch (state.route.query.sort || 0) {
    case 1:
      return state.products.slice().sort((a, b) => {
        return b.price - a.price;
      });
      break;
    case 2:
      return state.products.slice().sort((a, b) => {
        return a.name > b.name ? 1 : -1;
      });
      break;
    case 3:
      return state.products.slice().sort((a, b) => {
        return b.name > a.name ? 1 : -1;
      });
      break;
    default:
      return state.products.slice().sort((a, b) => {
        return a.price - b.price;
      });
  }
};
