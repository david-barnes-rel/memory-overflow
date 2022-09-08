import { Component, Input, OnInit } from '@angular/core';
import { PostDetail } from '../post-detail.model';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  @Input()
  post: PostDetail | null = null;

  constructor() { }

  ngOnInit(): void {
  }

}
