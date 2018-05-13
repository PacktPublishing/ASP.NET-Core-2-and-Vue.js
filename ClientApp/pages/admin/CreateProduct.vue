<template>
  <div>
    <div class="clearfix">
      <h3 class="float-left">Add a new product</h3>
      <b-button variant="link" class="float-right" to="/admin/products">Back to product list</b-button>
    </div>
    
    <form class="mt-4 mb-4" @submit.prevent="save">
      <form-input
        label="Name"
        name="name"
        :error="errors.first('name')"
        v-model="product.name"
        v-validate="'required|min:10|uniqueProductName'" />

      <form-input
        label="Short description"
        name="short description"
        :error="errors.first('short description')"
        v-model="product.shortDescription"
        v-validate="'required|min:10'" />

      <form-text-area
        label="Description"
        name="description"
        :rows="5"
        :error="errors.first('description')"
        v-model="product.description"
        v-validate="'required|min:10'" />
      
      <b-row>
        <b-col>
          <form-input
            type="number"
            label="Talk time"
            name="talk time"
            :error="errors.first('talk time')"
            append="hours"
            v-model="product.talkTime"
            v-validate="'required|decimal'" />
        </b-col>
        <b-col>
          <form-input
            type="number"
            label="Standby time"
            name="standby time"
            :error="errors.first('standby time')"
            append="hours"
            v-model="product.standbyTime"
            v-validate="'required|decimal'" />
        </b-col>
        <b-col>
          <form-input
            type="number"
            label="Screen size"
            name="screen size"
            :error="errors.first('screen size')"
            append="inches"
            v-model="product.screenSize"
            v-validate="'required|decimal'" />
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <typeahead 
            label="Brand"
            name="brand" 
            :items="brands"
            :error="errors.first('brand')"  
            v-model="product.brand"
            v-validate="'required|min:3'" />
        </b-col>
        <b-col>
          <typeahead 
            label="Operating system"
            name="operating system" 
            :items="os"
            :error="errors.first('operating system')"  
            v-model="product.os"
            v-validate="'required|min:3'" />
        </b-col>
      </b-row>

      <multi-select 
        name="features"
        label="Features"
        :items="features"
        :error="errors.first('features')"
        v-model="product.features"
        v-validate="'required'" />

      <div class="clearfix mt-4 mb-2">
        <h4 class="float-left">Variants</h4>
        <b-button size="sm" class="float-right" v-b-modal.variantModal>
          <i class="fas fa-plus"></i>
        </b-button>
      </div>

      <table class="table">
        <thead>
          <tr>
            <th>Colour</th>
            <th>Capacity</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          <template v-if="product.variants.length > 0">
            <tr v-for="(item, index) in product.variants" :key="index">
              <td>{{ item.colour }}</td>
              <td>{{ item.storage }}</td>
              <td>{{ item.price | currency }}</td>
            </tr>
          </template>
          <tr v-else>
            <td colspan="3">You haven't added any variants yet</td>
          </tr>
        </tbody>
      </table>
      
      <div v-if="variantsError" class="error">
        {{ variantsError }}
      </div>

      <div class="clearfix">
        <b-button class="float-right" variant="primary" @click.prevent="save">Save product</b-button>
      </div>
    </form>  

    <add-variant-modal 
      :colours="colours"
      :storage="storage" 
      @submit="addVariant" />
  </div>
</template>

<script>
import axios from "axios";
import FormInput from "../../components/shared/FormInput.vue";
import FormTextArea from "../../components/shared/FormTextArea.vue";
import Typeahead from "../../components/shared/Typeahead.vue";
import MultiSelect from "../../components/shared/MultiSelect.vue";
import AddVariantModal from "../../components/admin/AddVariantModal.vue";

export default {
  name: "create-product",
  components: {
    FormInput,
    FormTextArea,
    Typeahead,
    MultiSelect,
    AddVariantModal
  },
  data() {
    return {
      product: {
        name: "",
        shortDescription: "",
        description: "",
        talkTime: "",
        standbyTime: "",
        screenSize: "",
        brand: "",
        os: "",
        features: [],
        variants: []
      },
      brands: [],
      os: [],
      features: [],
      colours: [],
      storage: [],
      variantsError: null
    };
  },
  methods: {
    setData(data) {
      this.brands = data.brands;
      this.os = data.os;
      this.features = data.features;
      this.colours = data.colours;
      this.storage = data.storage;
    },
    save() {
      if (this.product.variants.length <= 0) {
        this.variantsError = "You must add at least one product variant.";
      } else {
        this.variantsError = null;
      }

      this.$validator.validateAll().then(result => {
        if (result && !this.variantsError) {
          axios
            .post("/api/products", this.product)
            .then(response => {
              this.$router.push("/admin/products");
            })
            .catch(error => {
              //handle server side validation
              console.log(error.data);
            });
        }
      });
    },
    addVariant(variant) {
      this.product.variants.push(variant);
    }
  },
  beforeRouteEnter(to, from, next) {
    const vm = this;
    axios.get("/api/filters").then(response => {
      next(vm => vm.setData(response.data));
    });
  }
};
</script>

<style lang="scss" scoped>
.error {
  font-size: 80%;
  color: #dc3545;
}
</style>

