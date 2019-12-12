<template>
  <v-app id="mysegement">
    <MainNavbar title="MySegments"/>
    <v-content>
      <router-view />
    </v-content>
    <Footer/>
  </v-app>
</template>

<script lang="ts">
import Landing from '@/components/Landing.vue';
import MainNavbar from '@/components/MainNavbar.vue';
import Footer from '@/components/Footer.vue';

import { Component, Vue } from 'vue-property-decorator';

@Component({
  components: { Landing, MainNavbar, Footer },
})
export default class App extends Vue {

}
</script>
