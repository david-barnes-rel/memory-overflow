import { TestBed } from '@angular/core/testing';

import { LoadAllPostsGuard } from './load-all-posts.guard';

describe('LoadAllPostsGuard', () => {
  let guard: LoadAllPostsGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(LoadAllPostsGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
