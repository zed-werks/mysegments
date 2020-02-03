import { MutationTree } from 'vuex';
import AthleteProfile from '@/models/AthleteProfile';

export const mutations: MutationTree<AthleteProfile> = {
  setFirstName(state, name) {
    state.firstName = name;
  },
  setLastName(state, name) {
    state.lastName = name;
  },
};
