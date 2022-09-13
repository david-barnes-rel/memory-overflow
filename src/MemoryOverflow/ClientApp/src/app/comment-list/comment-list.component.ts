import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Comment } from '../comment.model';
import { Logger } from '../logger';

@Component({
  selector: 'comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.scss'],
})
export class CommentListComponent implements OnInit {
  @Input()
  comments: Comment[] = [];

  @Output()
  create = new EventEmitter<Comment>();

  commentForm = new FormGroup({
    message: new FormControl('', [Validators.required]),
  });
  showCommentForm = false;
  private _logger = new Logger('CommentListComponent');
  constructor() {}

  ngOnInit(): void {}

  addComment(): void {
    this.showCommentForm = true;
  }
  onSubmit(): void {
    this._logger.log(
      'onSubmit',
      this.commentForm.valid,
      this.commentForm.value.message
    );
    if (this.commentForm.valid == true) {
      this.create.emit({
        message: this.commentForm.value.message || '',
      });
      this.showCommentForm = false;
      this.commentForm.reset();
    }
  }
}
