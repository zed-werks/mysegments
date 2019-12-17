import { GetterTree } from 'vuex';
import { RootState } from '../types';
import AthleteProfile from '@/models/AthleteProfile';

export const getters: GetterTree<AthleteProfile, RootState> = {
    firstName(state): string {
        return state.firstName;
    },
};
