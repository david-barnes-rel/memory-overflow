import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { switchMap,catchError, map,of } from "rxjs";
import { PostService } from "../../post.service";

import * as actions from './actions';
@Injectable()
export class AppEffects {

  constructor(
    private actions$: Actions, private postService: PostService) { }

  loadAllPosts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.loadSlimPosts),
      switchMap(_ => this.postService.loadAllPosts()
        .pipe(
          map(result => actions.loadSlimPostsSuccess({ posts: result })),
          catchError(error => of(actions.loadSlimPostsFailure({ error})))
        )
      )
    )
  );


  loadPost$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.loadPost),
      switchMap(action => this.postService.loadPost(action.id)
        .pipe(
          map(result => actions.loadPostSuccess({ post: result })),
          catchError(error => of(actions.loadPostFailure({ error })))
        )
      )
    )
  );


}
