import { createReducer, on } from "@ngrx/store";
import { PostDetail } from "../post-detail.model";
import { PostSlim } from "../post-slim.model";
import * as actions from './actions';

export interface AppState {
  posts: ReadonlyArray<PostSlim>,
  activePost: PostDetail | null
}
export const initialState: AppState = {
  posts: [],
  activePost: null
};


export const collectionResolver = createReducer(
  initialState,
  on(actions.loadSlimPostsSuccess, (state, action) => ({
    ...state,
    posts: action.posts
  })),
  on(actions.loadPostFailure, (state, _) => ({
    ...state,
    posts: []
  })),
  on(actions.loadPost, (state, _) => ({
    ...state,
    activePost: null
  })),
  on(actions.loadPostSuccess, (state, action) => ({
    ...state,
    activePost: action.post
  }))
);

