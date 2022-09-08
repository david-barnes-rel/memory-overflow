import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts$ = of([{ title: "hello" }, { title: "world" }]);
  constructor() { }

  ngOnInit(): void {
  }

}
