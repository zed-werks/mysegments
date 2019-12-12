<template>
  <v-container fluid>
    <v-layout column align-center>
      <img src="@/assets/logo.png" alt="Vuetify.js" class="mb-5">
    </v-layout>
    <v-slide-y-transition mode="out-in">
      <v-row>        
        <v-col>
          <Landing/>
        </v-col>
      </v-row>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Landing from '@/components/Landing.vue'; // @ is an alias to /src

@Component({
  components: {
    Landing,
  },
})
export default class Home extends Vue {}
</script>

