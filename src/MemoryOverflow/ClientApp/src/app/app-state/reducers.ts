import { createReducer, on } from '@ngrx/store';
import { PostDetail } from '../post-detail.model';
import { PostSlim } from '../post-slim.model';
import * as actions from './actions';

export interface AppState {
  posts: ReadonlyArray<PostSlim>;
  activePost: PostDetail | null;
}
export const initialState: AppState = {
  posts: [],
  activePost: null,
};

export const collectionResolver = createReducer(
  initialState,
  on(actions.loadSlimPostsSuccess, (state, action) => ({
    ...state,
    posts: action.posts,
  })),
  on(actions.loadPostFailure, (state, _) => ({
    ...state,
    posts: [],
  })),
  on(actions.loadPost, (state, _) => ({
    ...state,
    //activePost: null,
  })),
  on(actions.loadPostSuccess, (state, action) => ({
    ...state,
    activePost: action.post,
  })),
  on(actions.clearActivePost, (state, action) => ({
    ...state,
    activePost: null,
  })),
  on(actions.upsertAnswerForPostSuccess, (state, action) => ({
    ...state,
    activePost: {
      ...state.activePost!,
      answers: [...(state.activePost?.answers || []), action.answer],
    },
  })),
  on(actions.createCommentForPostSuccess, (state, action) => ({
    ...state,
    activePost: {
      ...state.activePost!,
      comments: [...(state.activePost?.comments || []), action.comment],
    },
  })),
  on(actions.voteOnPostSuccess, (state, action) => ({
    ...state,
    activePost: {
      ...state.activePost!,
      voteCount: (state.activePost?.voteCount || 0) + (action.value > 0 ? 1: -1)
    }
  })),
  on(actions.createCommentForAnswerSuccess, (state, action) => {
    const currentAnswers = [...(state.activePost?.answers || [])];
    return {
      ...state,
      activePost: {
        ...state.activePost!,
        answers: currentAnswers.map((a) => {
          if (a.id == action.answerId) {
            return {
              ...a,
              comments: [
                ...(a?.comments || []),
                action.comment,
              ]
            }
          } else {
            return a;
          }
        }),
      },
    };
  }),
  on(actions.deleteAnswerSuccess, (state, action) => ({
    ...state,
    activePost: {
      ...state.activePost!,
      answers: state.activePost?.answers.filter(x => x.id != action.answerId) || []
    }
  }))
);
