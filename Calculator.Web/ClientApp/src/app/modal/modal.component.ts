import { Component, Inject, ViewChild } from '@angular/core';
import { OverlayComponent } from '../overlay/overlay.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  @ViewChild(OverlayComponent) child!: OverlayComponent;
  constructor(http: HttpClient, @Inject('API_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }
  // spent longer than i care messing on with cors. angular/.net are running on differnet ports.
  // added a core rules and set specific ports
  // not too sure why fetch-data the default method can be called on the wrong port - will look into if
  // have more time
  http: HttpClient;
  baseUrl: string;
  isOpen = false;

  // these realistically don't need to update on blur or at all,
  // could just get the value from ele on methods below. Think having them update is cleaner
  // dont care about all update just on blur, could switch if we wanted to run on debounce
  updateStart(val:string)
  {
    this.start = val as unknown as number;
  }
  updateAmount(val: string) {
    this.amount = val as unknown as number;
  }
  start:number = 0;
  amount:number = 0;
  result = 0;

  // wasn't sure if you wanted themes or whitelabelling -> could be a class or something cleaner

  headerColor = '#1C110A';
  bodyColor = '#E7E5DF';
  footerColor = '#1C110A'

  headerTextColor = '#FFFFFF';
  bodyTextColor = '#000000';
  footerTextColor = '#FFFFFF'
  subtract() {
    var url = this.baseUrl + 'calculator/subtract/' + this.start + '/' + this.amount + '';
    this.http.get<number>(url).subscribe(result => {
      this.result = result;
    }, error => console.error(error));
  };
  add() {
    var url = this.baseUrl + 'calculator/add/' + this.start + '/' + this.amount + '';
    this.http.get<number>(url).subscribe(result => {
      this.result = result;
    }, error => console.error(error));
  };

  open() {
    this.isOpen = !this.isOpen;
    this.child.toggleOpen();
  }
}

// i was tempted to put modal at top level, but feel like the spec makes the modal fairly ungeneric
// and could of made it pass in a template and callback etc, but i find that tends to get more
// complicated over time, should be renamed to calculate-modal etc
