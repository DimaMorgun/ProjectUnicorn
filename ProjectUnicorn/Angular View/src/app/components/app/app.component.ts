import { Component, OnInit } from '@angular/core';

import { DefaultLayoutComponent } from '../layouts/default-layout/default-layout/default-layout.component';
import { TestLayoutComponent } from '../layouts/test-layout/test-layout/test-layout.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor() { }

  title = 'ProjectUnicornApp';
  public selectedLayout = DefaultLayoutComponent;

  ngOnInit() {
  }

  private changeLayout = (layout) => {
    if (layout === 1 && this.selectedLayout !== DefaultLayoutComponent) {
      this.selectedLayout = DefaultLayoutComponent;
    }
    if (layout === 2 && this.selectedLayout !== TestLayoutComponent) {
      this.selectedLayout = TestLayoutComponent;
    }
    console.log(this.selectedLayout);
  }
}
