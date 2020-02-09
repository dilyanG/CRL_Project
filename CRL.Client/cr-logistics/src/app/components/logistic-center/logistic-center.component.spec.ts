import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogisticCenterComponent } from './logistic-center.component';

describe('LogisticCenterComponent', () => {
  let component: LogisticCenterComponent;
  let fixture: ComponentFixture<LogisticCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogisticCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogisticCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
