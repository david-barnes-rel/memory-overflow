import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PostsComponent } from './posts/posts.component';
import { PostPreviewComponent } from './post-preview/post-preview.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { environment } from '../environments/environment';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { StoreModule } from '@ngrx/store';

import { collectionResolver as reducers } from './app-state/reducers';
import { STATE_KEY } from './app-state/selectors';
import { EffectsModule } from '@ngrx/effects';
import { AppEffects } from './app-state/effects'
import { LoadAllPostsGuard } from '../load-all-posts.guard';
import { LoadPostGuard } from '../load-post.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PostsComponent,
    PostPreviewComponent,
    PostDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'posts', component: PostsComponent, canActivate: [LoadAllPostsGuard] },
      { path: 'posts/:id', component: PostDetailComponent, canActivate: [LoadPostGuard] }
    ]),
    StoreModule.forRoot({}),
    EffectsModule.forRoot(),
    StoreModule.forFeature(STATE_KEY, reducers),
    EffectsModule.forFeature([AppEffects]),
    !environment.production ? StoreDevtoolsModule.instrument() : []
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
