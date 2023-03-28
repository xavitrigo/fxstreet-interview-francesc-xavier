import { Injectable } from '@angular/core';
import {ManagerHttpService} from "./manager-http.service";
import {Observable} from "rxjs";
import {ManagerModel} from "../models/manager.model";

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private managerHttpService: ManagerHttpService) { }

  getManagers(): Observable<ManagerModel[]> {
    return this.managerHttpService.getManagers();
  }

  getManagerById(id: number): Observable<ManagerModel> {
    return this.managerHttpService.getManagerById(id);
  }

  create(manager: ManagerModel): Observable<ManagerModel> {
    return this.managerHttpService.create(manager);
  }

  modify(manager: ManagerModel): Observable<ManagerModel> {
    return this.managerHttpService.modify(manager);
  }
}
