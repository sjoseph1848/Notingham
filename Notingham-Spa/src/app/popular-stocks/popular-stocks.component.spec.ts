import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PopularStocksComponent } from './popular-stocks.component';

describe('PopularStocksComponent', () => {
  let component: PopularStocksComponent;
  let fixture: ComponentFixture<PopularStocksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PopularStocksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PopularStocksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
