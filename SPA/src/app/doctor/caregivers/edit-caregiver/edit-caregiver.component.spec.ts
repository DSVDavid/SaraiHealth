import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCaregiverComponent } from './edit-caregiver.component';

describe('EditCaregiverComponent', () => {
  let component: EditCaregiverComponent;
  let fixture: ComponentFixture<EditCaregiverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCaregiverComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCaregiverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
