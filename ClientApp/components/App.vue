<template>
  <div class="app">
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
      <b-navbar-brand to="/">PhoneShop</b-navbar-brand>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item to="/products">Products</b-nav-item>
          <b-nav-item v-if="isAdmin" to="/admin">Admin</b-nav-item>
        </b-navbar-nav>
        <b-navbar-nav class="ml-auto mr-4">
          <cart-summary v-if="isCustomer" />
          <auth-nav-item />
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    
    <transition name="fade" mode="out-in">
      <router-view />
    </transition>

    <auth-modal :show="showAuthModal" />
  </div>
</template>

<script>
import AuthNavItem from "./app/AuthNavItem.vue";
import AuthModal from "./app/AuthModal.vue";
import CartSummary from "./cart/CartSummary.vue";

export default {
  name: "app",
  components: {
    AuthNavItem,
    AuthModal,
    CartSummary
  },
  computed: {
    showAuthModal() {
      return this.$store.state.showAuthModal;
    },
    isAdmin() {
      return this.$store.getters.isInRole("Admin");
    },
    isCustomer() {
      return (
        this.$store.getters.isInRole("Customer") ||
        !this.$store.getters.isAuthenticated
      );
    }
  }
};
</script>

<style lang="scss">
html,
body {
  height: 100vh;
}

div.app,
div.page {
  height: 100% !important;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease-in-out;
}
.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>
