<template>
  <div :style="{backgroundImage:'url(@/assets/background.jpg)'}"
    <v-card title="Connect">
      <a href="/Strava/Connect">Connect with Strava</a>
    </v-card>
  </div>
</template>

<script lang='ts'>
import vuetify from '../plugins/vuetify';

export default {
  name: 'Landing',
};
</script>