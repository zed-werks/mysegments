<template>
  <v-footer app>
    <span>&nbsp;<v-img src="@/assets/zedwerks.jpg" contain height="30px"/>
    &nbsp;Zed Werks Inc.&nbsp;&copy;&nbsp;2019</span>
    <v-img src="@/assets/strava/powerstrava.png" contain height="30px" />
  </v-footer>
</template>


<script lang="ts">
import { Action, Getter } from 'vuex-class';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Footer extends Vue {}
</script>