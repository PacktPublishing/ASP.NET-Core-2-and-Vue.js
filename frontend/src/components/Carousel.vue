<template>
  <div>
    <h1>V-Bind Carousel Example</h1>
    <img v-bind:src="imageSrc" alt="image" />
  </div>
</template>

<script>
export default {
  name: 'carousel',
  data () {
    return {
      imageSrc: '',
      images: [
        'http://placehold.it/250x50/ff0000/ffffff?text=1',
        'http://placehold.it/250x50/00ff00/ffffff?text=2',
        'http://placehold.it/250x50/0000ff/ffffff?text=3'
      ]
    }
  },
  mounted () {
    let vm = this
    let count = 0

    setInterval(function() {
      vm.imageSrc = vm.images[count++]
      if (count == vm.images.length)
        count = 0
    }, 1500)
  }
}
</script>