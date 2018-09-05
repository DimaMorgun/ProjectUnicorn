import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { DefaultLayoutComponent } from '../../layouts/default-layout/default-layout.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(
      [
        {
          path: '', component: DefaultLayoutComponent, children: [
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent }
          ]
        }
      ]
    )
  ],
  declarations: [HomeComponent, DefaultLayoutComponent],
  exports: [HomeComponent, DefaultLayoutComponent]
})
export class DashboardModule { }
