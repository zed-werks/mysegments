<template>
  <v-parallax dark src="@/assets/background.jpg" height="900">
    <v-container app>
      <v-layout column align-center></v-layout>
    </v-container>
  </v-parallax>
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

