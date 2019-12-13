<template>
  <v-parallax dark src="@/assets/background.jpg" height="700">
    <v-container app>
      <v-layout column align-center>
        <v-card light max-width="500">
          <v-card-title class="headline" align="top">Are you in the top ten?</v-card-title>
          <v-card-text>Just tap the button below and you'll see how many top ten placings you currently hold on segments you've ridden.</v-card-text>
          <a href="/Strava/Connect">
            <v-btn height="96px"/>
          </a>
        </v-card>
      </v-layout>
    </v-container>
    <Landing />
  </v-parallax>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {}
</script>

<style scoped> 
.v-btn {
background: url('../assets/strava/btn_strava_connectwith_orange@2x.png') no-repeat;
background-size: 100%;
width: 386px;
height: 96px;
display: block;
margin: 20px auto 50px;
border: none;
}
</style>