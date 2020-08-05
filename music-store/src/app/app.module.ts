import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SongModule } from './song/song.module';


@NgModule({
  declarations: [
    AppComponent  ],
  imports: [
    BrowserModule,
    NoopAnimationsModule,
    HttpClientModule,
    SongModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
