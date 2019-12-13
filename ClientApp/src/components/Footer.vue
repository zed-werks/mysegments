<template>
  <v-footer app dark paddless>
    <v-row no-gutters>
      <v-col>
        <div class="py-2 white--text">
          {{ new Date().getFullYear() }}
          <strong>&copy;&nbsp;zedwerks inc.</strong>
        </div>
      </v-col>
      <v-col>
        <v-spacer/>
        <v-img
          src="@/assets/strava/api_logo_pwrdBy_strava_horiz_white.png"
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