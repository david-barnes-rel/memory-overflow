import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadSlimPosts } from './app-state/actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(private store: Store) {

  }
}
