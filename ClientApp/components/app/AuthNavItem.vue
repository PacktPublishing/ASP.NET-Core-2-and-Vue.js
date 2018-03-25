<template>
  <b-nav-item-dropdown v-if="isAuthenticated" right>
    <template slot="button-content">
      <i class="fas fa-user"></i>
    </template>
    <b-dropdown-item @click="logout">
      <i class="fas fa-sign-out-alt"></i>
      Logout
    </b-dropdown-item>
  </b-nav-item-dropdown>
  <b-nav-item v-else @click="login">
    <i class="fas fa-user"></i>
    Login / register
  </b-nav-item>
</template>

<script>
export default {
  name: "auth-nav-item",
  computed: {
    isAuthenticated() {
      return this.$store.getters.isAuthenticated;
    }
  },
  methods: {
    login() {
      this.$store.commit("showAuthModal");
    },
    logout() {
      this.$store.dispatch("logout").then(() => {
        if (this.$route.meta.requiresAuth) {
          this.$router.push("/");
        }
      });
    }
  }
};
</script>
