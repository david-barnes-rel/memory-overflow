import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';

@Component({
  selector: 'posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts$ = of([{ id: '123', title: "hello", description: 'hello world' }, { id:'321', title: "world", description: 'hello other world' }]);
  constructor() { }

  ngOnInit(): void {
  }

}
