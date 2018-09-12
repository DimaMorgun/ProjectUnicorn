import { TestLayoutModule } from './test-layout.module';

describe('TestLayoutModule', () => {
  let testLayoutModule: TestLayoutModule;

  beforeEach(() => {
    testLayoutModule = new TestLayoutModule();
  });

  it('should create an instance', () => {
    expect(testLayoutModule).toBeTruthy();
  });
});
