import { DefaultLayoutModule } from './default-layout.module';

describe('DefaultLayoutModule', () => {
  let defaultLayoutModule: DefaultLayoutModule;

  beforeEach(() => {
    defaultLayoutModule = new DefaultLayoutModule();
  });

  it('should create an instance', () => {
    expect(defaultLayoutModule).toBeTruthy();
  });
});
