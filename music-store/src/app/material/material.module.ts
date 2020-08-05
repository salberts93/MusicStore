import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule, MatInputModule } from '@angular/material';
import {MatSelectModule} from '@angular/material/select';

import { MatSortModule } from '@angular/material';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatSortModule,
    MatTableModule,
    MatFormFieldModule, 
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ],
  exports: [
    MatSortModule,
    MatTableModule,
    MatFormFieldModule, 
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ]
})
export class MaterialModule { }
