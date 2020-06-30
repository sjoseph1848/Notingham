import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PopularStocksComponent } from './popular-stocks/popular-stocks.component';

@NgModule({
  declarations: [
    AppComponent,
    PopularStocksComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
