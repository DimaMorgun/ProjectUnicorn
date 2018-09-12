import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { TestPageComponent } from './test-page/test-page.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(
      [
        { path: '', redirectTo: 'page', pathMatch: 'full' },
        { path: 'page', component: TestPageComponent }
      ]
    )
  ],
  declarations: [TestPageComponent]
})
export class TestPageModule { }
