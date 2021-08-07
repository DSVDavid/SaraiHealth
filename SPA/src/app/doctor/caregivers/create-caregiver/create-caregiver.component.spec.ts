import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCaregiverComponent } from './create-caregiver.component';

describe('CreateCaregiverComponent', () => {
  let component: CreateCaregiverComponent;
  let fixture: ComponentFixture<CreateCaregiverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCaregiverComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCaregiverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
