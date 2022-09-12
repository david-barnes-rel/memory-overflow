import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { switchMap, catchError, map, of, tap } from "rxjs";
import { PostService } from "../../post.service";
import { Logger } from "../logger";

import * as actions from './actions';
@Injectable()
export class AppEffects {

  private _logger = new Logger('AppEffects');
  constructor(
    private actions$: Actions, private postService: PostService, private router: Router) {


  }

  loadAllPosts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.loadSlimPosts),
      switchMap(_ => this.postService.loadAllPosts()
        .pipe(
          tap(t=>this._logger.log('Load AllPosts Success')),
          map(result => actions.loadSlimPostsSuccess({ posts: result })),
          catchError(error => of(actions.loadSlimPostsFailure({ error })))
        )
      )
    )
  );


  loadPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.loadPost),
      switchMap(action => this.postService.loadPost(action.id)
        .pipe(
          tap(t=>this._logger.log('Load Post Success', t.id)),
          map(result => actions.loadPostSuccess({ post: result })),
          catchError(error => of(actions.loadPostFailure({ error })))
        )
      )
    )
  );

  upsertPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.upsertPost),
      switchMap(action => this.postService.upsertPost(action.post)
        .pipe(
          map(result => actions.upsertPostSuccess({ post: result })),
          catchError(error => of(actions.upsertPostError({ error })))
        ))
    ));


  upsertPostSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.upsertPostSuccess),
      map(r => this.router.navigate(['/posts', r.post.id]))
    ), { dispatch: false }
  );

  upsertAnswer$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.upsertAnswerForPost),
      switchMap(action => this.postService.upsertAnswer(action.postId, action.answer).pipe(
        map(r => actions.upsertAnswerForPostSuccess({ answer: r })),
        catchError(error => of(actions.upsertAnswerForPostError({ error })))
      ))
    ));

  voteOnPost = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.voteOnPost),
      switchMap(action => this.postService.voteOnPost(action.postId, action.value).pipe(
        map(r => actions.voteOnPostSuccess({ value: action.value })),
        catchError(error => of(actions.voteOnPostFailure({ error }))
        ))
      )));

  voteOnAnswer = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.voteOnAnswer),
      switchMap(action => this.postService.voteOnAnswer(action.answerId, action.value).pipe(
        map(r => actions.voteOnAnswerSuccess({ value: action.value })),
        catchError(error => of(actions.voteOnAnswerFailure({ error }))
        ))
      )));

}
