import { Component, Input, OnInit } from '@angular/core';
import { PostSlim } from '../post-slim.model';

@Component({
  selector: 'post-preview',
  templateUrl: './post-preview.component.html',
  styleUrls: ['./post-preview.component.css']
})
export class PostPreviewComponent implements OnInit {

  @Input()
  post: PostSlim | null = null;

  constructor() { }

  ngOnInit(): void {
  }

}
