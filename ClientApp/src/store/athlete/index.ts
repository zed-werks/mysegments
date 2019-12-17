import { Module } from 'vuex';
import { getters } from './getters';
import { actions } from './actions';
import { mutations } from './mutations';
import AthleteProfile from '@/models/AthleteProfile';
import { RootState } from '../types';

export const state: AthleteProfile = {
  id: 0,
  username: '',
  firstName: '',
  lastName: '',
  profile: '',
  units: '',
};

const namespaced: boolean = true;

export const athlete: Module<AthleteProfile, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations,
};
