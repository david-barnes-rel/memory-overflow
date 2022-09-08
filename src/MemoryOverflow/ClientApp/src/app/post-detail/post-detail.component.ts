import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { getActivePost } from '../app-state/selectors';
import { PostDetail } from '../post-detail.model';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  post$ = this.store.select(getActivePost)
  constructor(private store: Store) { }

  ngOnInit(): void {
  }

}
