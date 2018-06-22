<template>
  <div>
    <h1>Watchers Example</h1>
    <input v-model="searchValue" />
    <span v-show="loading">Loading...</span>
    <ul>
      <li v-for="result in searchResults">{{ result }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'watchers',
  data () {
    return {
      searchValue: '',
      searchResults: [],
      loading: false
    }
  },
  watch: {
    searchValue (newValue) {
      let vm = this
      this.loading = true

      setTimeout(function () {
        vm.searchResults.push('some', 'search', 'results')
        vm.loading = false
      }, 500)
    }
  }
}
</script>