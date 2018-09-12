import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent } from './components/layouts/default-layout/default-layout/default-layout.component';
import { TestLayoutComponent } from './components/layouts/test-layout/test-layout/test-layout.component';

const selectedLayoutComponent = DefaultLayoutComponent;
const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full', },
  {
    path: '', component: selectedLayoutComponent, children: [
      { path: 'dashboard', loadChildren: './components/pages/dashboard-page/dashboard-page.module#DashboardPageModule' },
      { path: 'test', loadChildren: './components/pages/test-page/test-page.module#TestPageModule' }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { useHash: false, enableTracing: false })
  ],
  declarations: [DefaultLayoutComponent, TestLayoutComponent],
  exports: [RouterModule],
})
export class AppRoutingModule { }
