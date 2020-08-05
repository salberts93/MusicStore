import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { SongTableComponent } from './song-table/song-table.component';
import { MaterialModule } from '../material/material.module';
import { SongFormComponent } from './song-form/song-form.component';

@NgModule({
  declarations: [SongTableComponent, SongFormComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    SongTableComponent,
    SongFormComponent
  ]
})
export class SongModule { }
