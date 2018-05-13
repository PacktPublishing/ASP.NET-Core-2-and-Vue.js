<template>
  <b-container class="page pt-4">
    <b-row>
      <b-col cols="3">
        <b-list-group>
          <b-list-group-item to="/admin/orders">
            <i class="fas fa-shopping-cart mr-2"></i>
            Orders
          </b-list-group-item>
          <b-list-group-item to="/admin/products">
            <i class="fas fa-mobile mr-2"></i>
            Products
          </b-list-group-item>
        </b-list-group>
      </b-col>
      <b-col cols="9">
        <router-view />
      </b-col>
    </b-row>
  </b-container>
</template>
