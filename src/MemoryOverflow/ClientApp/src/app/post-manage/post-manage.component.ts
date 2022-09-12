import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { upsertPost } from '../app-state/actions';
import { getActivePost } from '../app-state/selectors';
import { PostSlim } from '../post-slim.model';

@Component({
  selector: 'app-post-manage',
  templateUrl: './post-manage.component.html',
  styleUrls: ['./post-manage.component.css']
})
export class PostManageComponent implements OnInit, OnDestroy {

  private _sub = new Subscription();
  post = new FormGroup({
    id: new FormControl(''),
    title: new FormControl('', [Validators.required]),
    text: new FormControl('', [Validators.required])
  });

  constructor(private store: Store) { }

  ngOnInit(): void {
    this.store.select(getActivePost).subscribe( post => {
      this.post.patchValue({
        title: post?.title,
        text: post?.text
      })
    });
  }

  ngOnDestroy(): void {
    this._sub.unsubscribe();
  }
  onSubmit() : void{
    const post = this.post.value as PostSlim;
    this.store.dispatch(upsertPost({post}));
  }
}
