import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { loadSlimPosts } from '../app-state/actions';
import { getPosts } from '../app-state/selectors';

@Component({
  selector: 'posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts$ = this._store.select(getPosts);
  constructor(private _store: Store) {

  }

  ngOnInit(): void {
  }

}
