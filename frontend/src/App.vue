<template>
  <div id="app">
    <single-file-component />
    <hr />
    <child-component name="Hands on Vue.js and ASP.NET Core" />
    <hr />
    <prop-validation name="Hands on Vue.js and ASP.NET Core" description="Software Development Book" :price="15.99" />
    <hr />
    <methods />
    <hr />
    <expressions />
    <hr />
    <computed-properties />
    <hr />
    <watchers />
    <hr />
    <lifecycle-hooks />
    <hr />
    <v-bind />
    <hr />
    <interpolation />
    <hr />
    <carousel />
    <hr />
    <style-binding />
    <hr />
    <v-show />
    <hr />
    <v-if-v-else />
    <hr />
    <v-if-multiple />
    <hr />
    <v-else-if />
    <hr />
    <v-for />
    <hr />
    <v-for-index />
    <hr />
    <v-on />
    <hr />
    <v-on-shorthand />
    <hr />
    <v-on-prevent />
    <hr />
    <v-on-prevent-shorthand />
    <hr />
    <custom-events />
    <hr />
    <v-on-multiple />
    <hr />
    <form-input-value />
    <hr />
    <v-model />
  </div>
</template>

<script>
import SingleFileComponent from './components/SingleFileComponent.vue'
import ChildComponent from './components/ChildComponent.vue'
import PropValidation from './components/PropValidation.vue'
import Methods from './components/Methods.vue'
import Expressions from './components/Expressions.vue'
import ComputedProperties from './components/ComputedProperties.vue'
import Watchers from './components/Watchers.vue'
import LifecycleHooks from './components/LifecycleHooks.vue'
import VBind from './components/VBind.vue'
import Interpolation from './components/Interpolation.vue'
import Carousel from './components/Carousel.vue'
import StyleBinding from './components/StyleBinding.vue'
import VShow from './components/VShow.vue'
import VIfVElse from './components/VIfVElse.vue'
import VIfMultiple from './components/VIfMultiple.vue'
import VElseIf from './components/VElseIf.vue'
import VFor from './components/VFor.vue'
import VForIndex from './components/VForIndex.vue'
import VOn from './components/VOn.vue'
import VOnShorthand from './components/VOnShorthand.vue'
import VOnPrevent from './components/VOnPrevent.vue'
import VOnPreventShorthand from './components/VOnPreventShorthand.vue'
import CustomEvents from './components/CustomEvents.vue'
import VOnMultiple from './components/VOnMultiple.vue'
import FormInputValue from './components/FormInputValue.vue'
import VModel from './components/VModel.vue'

export default {
  name: 'chapter-1',
  components: {
    SingleFileComponent,
    ChildComponent,
    PropValidation,
    Methods,
    Expressions,
    ComputedProperties,
    Watchers,
    LifecycleHooks,
    VBind,
    Interpolation,
    Carousel,
    StyleBinding,
    VShow,
    VIfVElse,
    VIfMultiple,
    VElseIf,
    VFor,
    VForIndex,
    VOn,
    VOnShorthand,
    VOnPrevent,
    VOnPreventShorthand,
    CustomEvents,
    VOnMultiple,
    FormInputValue,
    VModel
  }
}
</script>
