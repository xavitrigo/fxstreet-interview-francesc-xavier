import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {ManagerModel} from "../models/manager.model";

const API_MANAGER_URL = `${environment.apiUrl}`

@Injectable({
  providedIn: 'root'
})
export class ManagerHttpService {

  constructor(private http: HttpClient) {}

  getManagers(): Observable<ManagerModel[]> {
    return this.http.get<ManagerModel[]>(`${API_MANAGER_URL}`);
  }

  getManagerById(id: number): Observable<ManagerModel> {
    return this.http.get<ManagerModel>(`${API_MANAGER_URL}/${id}`);
  }

  create(manager: ManagerModel): Observable<ManagerModel> {
    return this.http.post<ManagerModel>(`${API_MANAGER_URL}`, manager);
  }

  modify(manager: ManagerModel): Observable<ManagerModel> {
    return this.http.put<ManagerModel>(`${API_MANAGER_URL}`, manager);
  }
}
