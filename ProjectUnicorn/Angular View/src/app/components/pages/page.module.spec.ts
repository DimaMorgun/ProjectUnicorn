import { PageModule } from './page.module';

describe('PageModuleModule', () => {
  let pageModuleModule: PageModule;

  beforeEach(() => {
    pageModuleModule = new PageModule();
  });

  it('should create an instance', () => {
    expect(pageModuleModule).toBeTruthy();
  });
});
