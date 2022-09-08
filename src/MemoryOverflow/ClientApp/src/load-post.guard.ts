import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadPost, loadSlimPosts } from './app/app-state/actions';

@Injectable({
  providedIn: 'root'
})
export class LoadPostGuard implements CanActivate {
  constructor(private store: Store) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.store.dispatch(loadPost(route.params['id']));
    return true;
  }
  
}
