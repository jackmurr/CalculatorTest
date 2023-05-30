import { Component, Input, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { ModalComponent } from '../modal/modal.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  @ViewChild(ModalComponent) child!: ModalComponent;

    // these realistically don't need to update on blur or at all,
  // could just get the value from ele on methods below. Think having them update is cleaner
  // dont care about all update just on blur, could switch if we wanted to run on debounce

  updateHeaderColor(val: string) {
    this.headerColor = val;
  }
  updateHeaderTextColor (val: string) {
    this.headerTextColor = val;
  }
  updateBodyColor(val: string) {
    this.bodyColor = val;
  }
  updateBodyTextColor(val: string) {
    this.bodyTextColor = val;
  }
  updateFooterColor(val: string) {
    this.footerColor = val;
  }
  updateFooterTextColor(val: string) {
    this.footerTextColor = val;
  }


  // added defaults for both this and modal - in terms of the app the ones on the modal are probably not needed
  // but id rather set them incase the modal(calculator) ever got called from something that didn't edit them
  headerColor: string = '#1C110A';
  bodyColor: string = '#E7E5DF';
  footerColor: string = '#1C110A'

  headerTextColor: string = '#FFFFFF';
  bodyTextColor: string = '#000000';
  footerTextColor: string = '#FFFFFF'

  public callModal() {
    // lazy
    this.child.headerColor = this.headerColor;
    this.child.bodyColor = this.bodyColor;
    this.child.footerColor = this.footerColor;

    this.child.headerTextColor = this.headerTextColor;
    this.child.bodyTextColor = this.bodyTextColor;
    this.child.footerTextColor = this.footerTextColor;


    this.child.open();
  }
}
