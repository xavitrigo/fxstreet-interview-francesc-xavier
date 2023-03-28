import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ManagerModel} from "../../models/manager.model";

@Component({
  selector: 'app-manager-form',
  templateUrl: './manager-form.component.html',
  styleUrls: ['./manager-form.component.css']
})
export class ManagerFormComponent implements OnInit {

  @Output() addManager = new EventEmitter<ManagerModel>();

  formGroup!: FormGroup;

  constructor(
    private formBuilder: FormBuilder
  ) {
    this.createForm();
  }

  createForm() {
    this.formGroup = this.formBuilder.group({
      'name': [null, [Validators.required]],
      'yellowCard': [null, Validators.required],
      'redCard': [null, [Validators.required]],
    });
  }

  ngOnInit(): void {
  }

  onSubmit(formValue: any) {
    this.addManager.emit(formValue as ManagerModel);
  }

}
