import { TestBed } from '@angular/core/testing';

import { TrackingEntryService } from './tracking-entry.service';

describe('TrackingEntryService', () => {
  let service: TrackingEntryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrackingEntryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
