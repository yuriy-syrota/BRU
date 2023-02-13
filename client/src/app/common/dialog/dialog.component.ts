import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  @Input() header: string;   
  @Input() submitTitle: string = undefined;
  @Input() submitDisabled = false;
  @Input() closable = true;
  @Input() showDialog: boolean;
  @Input() closeOnSumbit = true;
  @Input() closeOnEscape = true;
  @Input() showFooter: boolean = true;
  @Output() showDialogChange = new EventEmitter<boolean>();
  @Output() doIt = new EventEmitter<boolean>();
    
  constructor() { }

  ngOnInit(): void {
  }
  
  onShow()
  {
    this.showDialogChange.emit(true);
  }

  onHide()
  {
    this.showDialogChange.emit(false);  
  }

  onSubmit()
  {
    this.doIt.emit(true);
    if (this.closeOnSumbit) {
      this.showDialog = false;
    }
  }
}
