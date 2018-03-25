<template>
  <b-modal v-model="show" hide-header hide-footer no-close-on-backdrop no-close-on-esc>
    <b-tabs v-model="index">
      <b-tab title="Login" active>
        <login-form :registered="registered" @close="close" />
      </b-tab>
      <b-tab title="Register" >
        <register-form @success="success" @close="close" />
      </b-tab>
    </b-tabs>
  </b-modal>
</template>

<script>
import LoginForm from "./LoginForm.vue";
import RegisterForm from "./RegisterForm.vue";

export default {
  name: "auth-modal",
  components: {
    LoginForm,
    RegisterForm
  },
  props: {
    show: {
      type: Boolean,
      required: true
    }
  },
  data() {
    return {
      index: 0,
      registered: false
    };
  },
  methods: {
    success() {
      this.registered = true;
      this.index = 0;
    },
    close() {
      this.$store.commit("hideAuthModal");
      let query = Object.assign({}, this.$route.query);
      delete query.redirect;
      this.$router.push({ query: query });
    }
  }
};
</script>

