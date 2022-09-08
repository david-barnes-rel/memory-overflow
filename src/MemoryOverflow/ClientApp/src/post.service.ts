import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { PostDetail } from './app/post-detail.model';
import { PostSlim } from './app/post-slim.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor() { }

  public loadAllPosts(): Observable<PostSlim[]> {
    return of([
      {
        id: '123',
        title: 'first post',
        text: 'this is my first question'
      },
      {
        id: '321',
        title: 'second post',
        text: 'this is my 2nd question'
      }
    ])
  }


  public loadPost(id: string): Observable<PostDetail> {
    return of(
      {
        id: '123',
        title: 'first post',
        text: 'this is my first question',
        answers: []
      })
  }

}
