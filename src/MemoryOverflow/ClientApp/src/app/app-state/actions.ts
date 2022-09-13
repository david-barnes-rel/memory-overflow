import { createAction, props } from '@ngrx/store';
import { Answer } from '../answer.model';
import { Comment } from '../comment.model';
import { PostDetail } from '../post-detail.model';
import { PostSlim } from '../post-slim.model';

export const loadSlimPosts = createAction('[Posts API] Load Slim posts');
export const loadSlimPostsSuccess = createAction(
  '[Posts API] Load Slim posts Success',
  props<{ posts: PostSlim[] }>()
);

export const loadSlimPostsFailure = createAction(
  '[Posts API] Load Slim posts Success',
  props<{ error: string }>()
);

export const loadPost = createAction(
  '[Post API] load post',
  props<{ id: string }>()
);

export const clearActivePost = createAction('[Post API] clear active post');

export const loadPostSuccess = createAction(
  '[Post API] load post success',
  props<{ post: PostDetail }>()
);
export const loadPostFailure = createAction(
  '[Post API] load post Failure',
  props<{ error: string }>()
);

export const upsertPost = createAction(
  '[Post API] UpsertPost',
  props<{ post: PostSlim }>()
);

export const upsertPostSuccess = createAction(
  '[Post API] UpsertPost Success',
  props<{ post: PostSlim }>()
);

export const upsertPostError = createAction(
  '[Post API] UpsertPost Error',
  props<{ error: string }>()
);

// #region Vote On Post
export const voteOnPost = createAction(
  '[Post API] PostVote',
  props<{ postId: string; value: number }>()
);

export const voteOnPostSuccess = createAction(
  '[Post API] PostVote Success',
  props<{ value: number }>()
);

export const voteOnPostFailure = createAction(
  '[Post API] PostVote Failure',
  props<{ error: string }>()
);
// #endregion

// #region Vote On Answer
export const voteOnAnswer = createAction(
  '[Post API] VoteOnAnswer',
  props<{ answerId: string; value: number }>()
);

export const voteOnAnswerSuccess = createAction(
  '[Post API] VoteOnAnswer Success',
  props<{ value: number }>()
);

export const voteOnAnswerFailure = createAction(
  '[Post API] VoteOnAnswer Failure',
  props<{ error: string }>()
);
// #endregion

export const upsertAnswerForPost = createAction(
  '[Post API] UpsertAnswer',
  props<{ postId: string; answer: Answer }>()
);

export const upsertAnswerForPostSuccess = createAction(
  '[Post API] UpsertAnswer Success',
  props<{ answer: Answer }>()
);
export const upsertAnswerForPostError = createAction(
  '[Post API] UpsertAnswer Error',
  props<{ error: string }>()
);

export const createCommentForPost = createAction(
  '[Post API] Create Comment for Post',
  props<{ postId: string; comment: Comment }>()
);

export const createCommentForPostSuccess = createAction(
  '[Post API] Create Comment for Post Success',
  props<{ postId: string; comment: Comment }>()
);

export const createCommentForPostFailure = createAction(
  '[Post API] Create Comment for Post Failure',
  props<{ error: string }>()
);

export const createCommentForAnswer = createAction(
  '[Post API] Create Comment for Answer',
  props<{ answerId: string; comment: Comment }>()
);

export const createCommentForAnswerSuccess = createAction(
  '[Post API] Create Comment for Answer Success',
  props<{ answerId: string; comment: Comment }>()
);

export const createCommentForAnswerFailure = createAction(
  '[Post API] Create Comment for Answer Failure',
  props<{ error: string }>()
);
