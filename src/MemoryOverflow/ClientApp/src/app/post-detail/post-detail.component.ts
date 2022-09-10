import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { getActivePost, getActivePostAnswerCount } from '../app-state/selectors';
import { PostDetail } from '../post-detail.model';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  post$ = this.store.select(getActivePost);
  answerCount$ = this.store.select(getActivePostAnswerCount);
  constructor(private store: Store) { }

  ngOnInit(): void {
  }

  upvote(id: string) {
    console.log('upvote', id);
  }
  downvote(id: string) {
    console.log('downvote', id);
  }
}
