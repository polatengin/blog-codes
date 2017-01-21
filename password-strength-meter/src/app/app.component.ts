import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  private fullName: string = '';
  private email: string = '';
  private password: string = '';
  private passwordStrength: number;

  updateMeter(): void {
    let strength: number = 0;

    let variations = {
      digits: /\d/.test(this.password),
      lower: /[a-z]/.test(this.password),
      upper: /[A-Z]/.test(this.password),
      nonWords: /\W/.test(this.password),
    }

    for (let check in variations) {
      strength += (variations[check]) ? 1 : 0;
    }
    if(strength < 3) {
      this.passwordStrength = 0;
      return;
    }

    strength = this.password.length;

    if(strength > 10) {
      strength = 10;
    }

    this.passwordStrength = parseInt((strength / 2).toString());
  }

  signup(): void {
    if(this.passwordStrength > 3) {
      // en az 3 seviyesinde güvenli şifre ise yolumuza devam ediyoruz...
    }
  }

}
