<template>
  <v-footer app dark paddless>
    <v-row justify="space-between">
      <v-col>
        <v-text class="py-2 white--text">
          {{ new Date().getFullYear() }}
          <strong>&copy;&nbsp;zedwerks inc.</strong>
        </v-text>
      </v-col>
      <v-col>
        <v-spacer />
      </v-col>
      <v-col>
        <v-img
          src="@/assets/strava/pwrdBy_strava_white/api_logo_pwrdBy_strava_horiz_white.png"
          contain
          height="30px"
        />
      </v-col>
    </v-row>
  </v-footer>
</template>

<script lang="ts">
import { Action, Getter } from 'vuex-class';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Footer extends Vue {}
</script>