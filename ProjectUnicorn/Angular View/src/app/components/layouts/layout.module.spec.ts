import { LayoutModule } from './layout.module';

describe('LayoutModuleModule', () => {
  let layoutModuleModule: LayoutModule;

  beforeEach(() => {
    layoutModuleModule = new LayoutModule();
  });

  it('should create an instance', () => {
    expect(layoutModuleModule).toBeTruthy();
  });
});
