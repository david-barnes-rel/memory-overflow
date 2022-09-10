import { createAction, props } from "@ngrx/store";
import { PostDetail } from "../post-detail.model";
import { PostSlim } from "../post-slim.model";

export const loadSlimPosts = createAction(
  '[Posts API] Load Slim posts'
);
export const loadSlimPostsSuccess = createAction(
  '[Posts API] Load Slim posts Success',
  props<{posts: PostSlim[]}>()
);

export const loadSlimPostsFailure = createAction(
  '[Posts API] Load Slim posts Success',
  props<{ error: string }>()
);

export const loadPost = createAction(
  '[Post API] load post',
  props<{ id: string }>()
);

export const clearActivePost = createAction(
  '[Post API] clear active post',
)

export const loadPostSuccess = createAction(
  '[Post API] load post success',
  props<{ post: PostDetail }>()
);
export const loadPostFailure = createAction(
  '[Post API] load post Failure',
  props<{ error: string }>()
);
