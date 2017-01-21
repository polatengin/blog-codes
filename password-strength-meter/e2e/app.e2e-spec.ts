import { PasswordStrengthMeterPage } from './app.po';

describe('password-strength-meter App', function() {
  let page: PasswordStrengthMeterPage;

  beforeEach(() => {
    page = new PasswordStrengthMeterPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
