import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Answer } from './app/answer.model';
import { Comment } from './app/comment.model';
import { PostDetail } from './app/post-detail.model';
import { PostSlim } from './app/post-slim.model';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor() {}

  public loadAllPosts(): Observable<PostSlim[]> {
    const dPosts = [
      {
        id: '123',
        title: 'first post',
        text: 'this is my first question',
      },
      {
        id: '321',
        title: 'second post',
        text: 'this is my 2nd question',
      },
    ];
    const result: PostSlim[] = JSON.parse(
      localStorage.getItem('posts') || '[]'
    );
    return of([...dPosts, ...result]);
  }

  public loadPost(id: string): Observable<PostDetail> {
    return of({
      id: '123',
      title: 'first post',
      text: 'this is my first question',
      answers: [
        {
          text: 'some answer',
          id: 'a-3215',
          comments: [
            {
              id: 'c-3123',
              message: 'hello world 1',
              user: {
                id: 'u-234',
                name: 'test_user',
              },
            },
            {
              id: 'c-3123',
              message: 'hello world 2',
              user: {
                id: 'u-234',
                name: 'test_user',
              },
            },
          ],
        },
        {
          text: 'some other answer',
          id: 'a-3215',
          comments: [
            {
              id: 'c-3123',
              message: 'hello world 1',
              user: {
                id: 'u-234',
                name: 'test_user',
              },
            },
            {
              id: 'c-3123',
              message: 'hello world 2',
              user: {
                id: 'u-234',
                name: 'test_user',
              },
            },
          ],
        },
      ],
      comments: [
        {
          id: 'c-3123',
          message: 'hello world 1',
          user: {
            id: 'u-234',
            name: 'test_user',
          },
        },
        {
          id: 'c-3123',
          message: 'hello world 2',
          user: {
            id: 'u-234',
            name: 'test_user',
          },
        },
      ],
    });
  }

  public upsertPost(post: PostSlim): Observable<PostSlim> {
    const result: PostSlim[] = JSON.parse(
      localStorage.getItem('posts') || '[]'
    );
    const cPost = {
      ...post,
      id: 'p-123',
    };
    result.push(cPost);
    localStorage.setItem('posts', JSON.stringify(result));
    return of(cPost);
  }

  public upsertAnswer(postId: string, answer: Answer): Observable<Answer> {
    return of(answer);
  }

  public voteOnPost(postId: string, number: number): Observable<void> {
    return of();
  }

  public voteOnAnswer(answerId: string, number: number): Observable<void> {
    return of();
  }

  public createCommentForAnswer(
    answerId: string,
    comment: Comment
  ): Observable<Comment> {
    return of(comment);
  }

  public createCommentForPost(
    answerId: string,
    comment: Comment
  ): Observable<Comment> {
    return of(comment);
  }
}
