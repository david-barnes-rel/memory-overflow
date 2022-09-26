import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Answer } from './app/answer.model';
import { Comment } from './app/comment.model';
import { PostDetail } from './app/post-detail.model';
import { PostSlim } from './app/post-slim.model';
import {environment as env } from './environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private client: HttpClient) {}

  public loadAllPosts(): Observable<PostSlim[]> {
    return this.client.get<PostSlim[]>(`${env.url}/api/post`);
  }

  public loadPost(id: string): Observable<PostDetail> {
    return this.client.get<PostDetail>(`${env.url}/api/post/${id}`);
  }

  public upsertPost(post: PostSlim): Observable<PostSlim> {
    const p = {
      ...post
    } as Partial<PostSlim>;
    delete p.id;
    return this.client.post<PostSlim>(`${env.url}/api/post`, p);
  }

  public upsertAnswer(postId: string, answer: Answer): Observable<Answer> {
    const p = {
      ...answer
    } as Partial<Answer>;
    delete p.id;
    return this.client.post<Answer>(`${env.url}/api/post/${postId}/answer`, p);
  }

  public deleteAnswer(postId: string,answerId: string): Observable<void> {
    return this.client.delete<void>(`${env.url}/api/post/${postId}/answer/${answerId}`);
  }

  public voteOnPost(postId: string, number: number): Observable<void> {
    return this.client.post<void>(`${env.url}/api/post/${postId}/vote`, {vote: number});
  }

  public voteOnAnswer(postId: string, answerId: string, number: number): Observable<void> {
    return this.client.post<void>(`${env.url}/api/post/${postId}/answer/${answerId}/vote`, {vote: number});
  }

  public createCommentForAnswer(
    postId: string,
    answerId: string,
    comment: Comment
  ): Observable<Comment> {
    return this.client.post<Comment>(`${env.url}/api/post/${postId}/answer/${answerId}/comment`, comment);
  }

  public createCommentForPost(
    postId: string,
    comment: Comment
  ): Observable<Comment> {
    return this.client.post<Comment>(`${env.url}/api/post/${postId}/comment`, comment);
  }
}


@Injectable({
  providedIn: 'root',
})
export class TelemetryService {
  constructor(private client: HttpClient) {}

  public track(obj: {type: string, payload: any}) {
    return this.client.post<void>(`${env.url}/api/telemetry/track`, {type: obj.type, payload: JSON.stringify(obj.payload)}).subscribe();
  }

}
