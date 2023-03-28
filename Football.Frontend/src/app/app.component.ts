import {Component, OnInit} from '@angular/core';
import {ManagerService} from "./services/manager.service";
import {ManagerModel} from "./models/manager.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Football.Frontend';
  managers: ManagerModel[] = [];

  constructor(private managerService: ManagerService) {
  }
  ngOnInit(): void {
    this.getManagers();
  }

  addManager(managerToAdd: ManagerModel): void {
    this.managerService.create(managerToAdd).subscribe(() => this.getManagers())
  }

  getManagers(): void {
    this.managerService.getManagers().subscribe((managerList) => {
      this.managers = managerList;
    });
  }
}
