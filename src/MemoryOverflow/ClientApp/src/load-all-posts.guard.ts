import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadSlimPosts } from './app/app-state/actions';

@Injectable({
  providedIn: 'root'
})
export class LoadAllPostsGuard implements CanActivate {
  constructor(private store: Store) { };
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.store.dispatch(loadSlimPosts());
    return true;
  }
  
}
