<template>
  <v-footer app>
    <span>&nbsp;Zed Werks Inc.&nbsp;&copy;&nbsp;2019</span>
    <TopToolbar />
  </v-footer>
</template>


<script lang="ts">
import { Action, Getter } from 'vuex-class';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Footer extends Vue {}
</script>