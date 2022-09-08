import { TestBed } from '@angular/core/testing';

import { LoadPostGuard } from './load-post.guard';

describe('LoadPostGuard', () => {
  let guard: LoadPostGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(LoadPostGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
