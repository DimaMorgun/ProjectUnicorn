import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { DashboardPageComponent } from './dashboard-page/dashboard-page.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(
      [
        { path: '', redirectTo: 'page', pathMatch: 'full' },
        { path: 'page', component: DashboardPageComponent }
      ]
    )
  ],
  declarations: [DashboardPageComponent]
})
export class DashboardPageModule { }
