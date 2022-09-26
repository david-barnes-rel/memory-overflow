import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { switchMap, catchError, map, of, tap } from 'rxjs';
import { PostService, TelemetryService } from '../../post.service';
import { Logger } from '../logger';

import * as actions from './actions';
@Injectable()
export class AppEffects {
  private _logger = new Logger('AppEffects');
  constructor(
    private actions$: Actions,
    private postService: PostService,
    private telemService: TelemetryService,
    private router: Router
  ) { }

  loadAllPosts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.loadSlimPosts),
      switchMap((_) =>
        this.postService.loadAllPosts().pipe(
          tap((t) => this._logger.log('Load AllPosts Success')),
          map((result) => actions.loadSlimPostsSuccess({ posts: result })),
          catchError((error) => of(actions.loadSlimPostsFailure({ error })))
        )
      )
    )
  );

  loadPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.loadPost),
      tap(p => this._logger.log('load post', p.id)),
      switchMap((action) =>
        this.postService.loadPost(action.id).pipe(
          tap((t) => this._logger.log('Load Post Success', t.id)),
          map((result) => actions.loadPostSuccess({ post: result })),
          catchError((error) => of(actions.loadPostFailure({ error })))
        )
      )
    )
  );

  upsertPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.upsertPost),
      switchMap((action) =>
        this.postService.upsertPost(action.post).pipe(
          tap(r=>this.telemService.track({type: 'create_post', payload: { postId: r.id, questionLength: action.post.text.length, titleLength: action.post.title.length }})),
          map((result) => actions.upsertPostSuccess({ post: result })),
          catchError((error) => of(actions.upsertPostError({ error })))
        )
      )
    )
  );

  upsertPostSuccess$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(actions.upsertPostSuccess),
        map((r) => this.router.navigate(['/posts', r.post.id]))
      ),
    { dispatch: false }
  );

  upsertAnswer$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.upsertAnswerForPost),
      switchMap((action) =>
        this.postService.upsertAnswer(action.postId, action.answer).pipe(
          map((r) => actions.upsertAnswerForPostSuccess({ answer: r })),
          tap(r=>this.telemService.track({type: 'create_answer', payload: { answerId: r.answer.id, answerLength: action.answer.text.length }})),
          catchError((error) => of(actions.upsertAnswerForPostError({ error })))
        )
      )
    )
  );

  voteOnPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.voteOnPost),
      switchMap((action) =>
        this.postService.voteOnPost(action.postId, action.value).pipe(
          map((r) => actions.voteOnPostSuccess({ value: action.value })),
          catchError((error) => of(actions.voteOnPostFailure({ error })))
        )
      )
    )
  );

  voteOnAnswer$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.voteOnAnswer),
      switchMap((action) =>
        this.postService.voteOnAnswer(action.postId, action.answerId, action.value).pipe(
          map((r) => actions.voteOnAnswerSuccess({ answerid: action.answerId, value: action.value })),
          catchError((error) => of(actions.voteOnAnswerFailure({ error })))
        )
      )
    )
  );

  createCommentOnPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.createCommentForPost),
      switchMap((action) =>
        this.postService
          .createCommentForPost(action.postId, action.comment)
          .pipe(
            tap(r=>this.telemService.track({type: 'create_comment', payload: {commentId: r.id, commentLength: action.comment.message }})),
            map((r) =>
              actions.createCommentForPostSuccess({
                postId: action.postId,
                comment: r,
              })
            ),
            catchError((error) =>
              of(actions.createCommentForPostFailure({ error }))
            )
          )
      )
    )
  );

  createCommentOnAnswer$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.createCommentForAnswer),
      switchMap((action) =>
        this.postService
          .createCommentForAnswer( action.postId, action.answerId, action.comment)
          .pipe(
            tap(r=>this.telemService.track({type: 'create_comment', payload: { commentId: r.id, commentLength: action.comment.message }})),
            map((r) =>
              actions.createCommentForAnswerSuccess({
                answerId: action.answerId,
                comment: r,
              })
            ),
            catchError((error) =>
              of(actions.createCommentForAnswerFailure({ error }))
            )
          )
      )
    )
  );

  deleteAnswer$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.deleteAnswer),
      switchMap((action) =>
        this.postService.deleteAnswer(action.postId, action.answerId)
          .pipe(
            map(r => actions.deleteAnswerSuccess({ answerId: action.answerId })),
            catchError(error => of(actions.deleteAnswerFailure({ error }))
            ))
      ))
  )
}
