import { createSelector } from '@ngrx/store';
import { createFeatureSelector } from '@ngrx/store';
import { AppState } from './reducers';

export const STATE_KEY = 'app_state';

const getState = createFeatureSelector<AppState>(STATE_KEY);

export const getPosts = createSelector(
  getState,
  (state) => state.posts
);

export const getActivePost = createSelector(
  getState,
  (state) => state.activePost
);

export const getActivePostAnswerCount = createSelector(
  getState,
  (state) => state.activePost?.answers.length
);


