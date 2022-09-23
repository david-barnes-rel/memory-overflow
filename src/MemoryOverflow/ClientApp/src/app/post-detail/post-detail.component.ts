import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs';
import { createCommentForAnswer, createCommentForPost, deleteAnswer, upsertAnswerForPost, voteOnAnswer, voteOnPost } from '../app-state/actions';
import {
  getActivePost,
  getActivePostAnswerCount,
} from '../app-state/selectors';
import { Logger } from '../logger';
import { Comment } from '../comment.model';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css'],
})
export class PostDetailComponent implements OnInit {
  answerForm = new FormGroup({
    answer: new FormControl('', [Validators.required]),
  });
  post$ = this.store
    .select(getActivePost)
    .pipe(tap((post) => console.log('new Post', post)));
  answerCount$ = this.store.select(getActivePostAnswerCount);
  private _logger = new Logger('PostDetailComponent');
  constructor(private store: Store) {}

  ngOnInit(): void {}

  upvotePost(id: string) {
    this.store.dispatch(voteOnPost({postId: id, value: 1}))
  }
  downvotePost(id: string) {
    this.store.dispatch(voteOnPost({postId: id, value: -1}))
  }

  upvoteAnswer(postId: string, id: string) {
    this.store.dispatch(voteOnAnswer({postId: postId, answerId: id, value: 1}));
    this._logger.log('upvote', id);
  }
  downvoteAnswer(postId: string, id: string) {
    this.store.dispatch(voteOnAnswer({postId: postId, answerId: id, value: -1}));
  }
  createAnswer(postId: string): void {
    this.store.dispatch(
      upsertAnswerForPost({
        postId: postId,
        answer: {
          id: '',
          text: this.answerForm.value.answer || '',
          comments: [],
          voteCount: 0
        },
      })
    );
    // TODO this could be a problem if the answer fails to save
    this.answerForm.reset();
  }

  createCommentForAnswer(id: string, postId: string, comment: Comment): void {
    this.store.dispatch(createCommentForAnswer({ postId: postId, answerId: id, comment: comment }));
  }
  createCommentForPost(id: string, comment: Comment): void {
    this.store.dispatch(createCommentForPost({postId: id, comment: comment }));
  }
  deleteAnswer(postId: string, answerId: string) : void{
   this.store.dispatch(deleteAnswer({postId, answerId}));
  }
}
