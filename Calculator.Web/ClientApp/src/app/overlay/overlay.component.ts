import { Component } from '@angular/core';

@Component({
  selector: 'app-overlay',
  templateUrl: './overlay.component.html',
  styleUrls: ['./overlay.component.css']
})
export class OverlayComponent {
  isOpen = false;
  public toggleOpen() { this.isOpen = !this.isOpen; };
}


// this should really live above modal at main and have a controller to open/close from anywhere, but lazy
