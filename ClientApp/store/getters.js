export const shoppingCartTotal = state => {
  const reducer = (accumulator, cartItem) =>
    accumulator + cartItem.price * cartItem.quantity;

  return state.cart.reduce(reducer, 0);
};

export const shoppingCartItemCount = state => {
  const reducer = (accumulator, cartItem) => accumulator + cartItem.quantity;
  return state.cart.reduce(reducer, 0);
};
