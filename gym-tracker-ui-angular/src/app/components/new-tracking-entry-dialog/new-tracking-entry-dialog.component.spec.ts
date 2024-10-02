import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTrackingEntryDialogComponent } from './new-tracking-entry-dialog.component';

describe('NewTrackingEntryDialogComponent', () => {
  let component: NewTrackingEntryDialogComponent;
  let fixture: ComponentFixture<NewTrackingEntryDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewTrackingEntryDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewTrackingEntryDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
