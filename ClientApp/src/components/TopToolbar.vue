<template>
  <v-row justify="space-around">
    <v-avatar>
      <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="Brad" />
    </v-avatar>
    <v-toolbar dense>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
      <v-btn icon>
        <v-icon>mdi-heart</v-icon>
      </v-btn>
      <v-btn icon>
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
    </v-toolbar>
  </v-row>
</template>

<script lang="ts">
import { Action, Getter } from 'vuex-class';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class TopToolbar extends Vue {}
</script>