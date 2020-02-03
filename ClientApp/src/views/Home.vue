<template>
  <v-parallax dark src="@/assets/background.jpg" height="700">
    <v-container app>
      <v-layout column align-center>
        <v-card light max-width="500">
          <v-card-title class="headline" align="top">How Many top-ten trophies do you have?</v-card-title>
          <v-card-text>Just tap the button below and you'll see how many top ten placings you currently hold on segments you've ridden.</v-card-text>
          <v-btn href="/Strava/Connect" large height="96px" depressed />
        </v-card>
      </v-layout>
    </v-container>
  </v-parallax>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  public name = 'Home';
}
</script>

<style scoped>
.v-btn {
  background: url("../assets/strava/btn_strava_connectwith_orange@2x.png")
    no-repeat;
  background-size: 100%;
  width: 386px;
  height: 96px;
  display: block;
  margin: 10px auto 50px;
  border: none;
}
</style>
