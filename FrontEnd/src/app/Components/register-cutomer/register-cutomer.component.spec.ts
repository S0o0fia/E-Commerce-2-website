import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterCutomerComponent } from './register-cutomer.component';

describe('RegisterCutomerComponent', () => {
  let component: RegisterCutomerComponent;
  let fixture: ComponentFixture<RegisterCutomerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterCutomerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterCutomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
