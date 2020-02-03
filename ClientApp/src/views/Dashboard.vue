<template>
<v-container>
    <v-expansion-panels popout>
      <v-expansion-panel value='true' v-for="(item, i) in items" :key="i" :to="item.link">
        <v-expansion-panel-header>
          <v-row>
            <v-icon class="mx-4" small>fas fa-trophy</v-icon>
            <b>{{item.title}}</b>
            <v-spacer />
            <v-spacer />
            Total: {{item.count}}
            <v-spacer />
          </v-row>
        </v-expansion-panel-header>
        <v-expansion-panel-content>quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
    <p>&nbsp;&nbsp;</p>
    </v-container>

</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Dashboard extends Vue {
  public name = 'Dashboard';
  private items = [
    { title: '1st Overall', count: '45' },
    { title: '2nd Overall', count: '34' },
    { title: '3rd Overall', count: '34' },
    { title: '4th Overall', count: '56' },
    { title: '5th Overall', count: '88' },
    { title: '6th Overall', count: '90' },
    { title: '7th Overall', count: '33' },
    { title: '8th Overall', count: '203' },
    { title: '9th Overall', count: '99' },
    { title: '10th Overall', count: '36' },
  ];
}
</script>


