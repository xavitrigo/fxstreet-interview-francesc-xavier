import {Component, Input, OnInit} from '@angular/core';
import {ManagerModel} from "../../models/manager.model";

@Component({
  selector: 'app-manager-table',
  templateUrl: './manager-table.component.html',
  styleUrls: ['./manager-table.component.css']
})
export class ManagerTableComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'yellowCard', 'redCard'];
  @Input() data: ManagerModel[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
