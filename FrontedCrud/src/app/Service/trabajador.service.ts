import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Trabajador } from '../interfaces/trabajador';

@Injectable({
  providedIn: 'root'
})
export class TrabajadorService {

  private endpoint: string = "http://localhost:5089/api/";
  private apirul: string = this.endpoint + "Trabajador";

  constructor(private http: HttpClient) {}

  getTrabajadores(): Observable<Trabajador[]>{
    return this.http.get<Trabajador[]>(`${this.apirul}`)
  }

  getOne(id: number): Observable<Trabajador> {
    return this.http.get<Trabajador>(`${this.apirul}/${id}`);
  }
  postOne(modelo: Trabajador): Observable<Trabajador> {
    return this.http.post<Trabajador>(`${this.apirul}/`,modelo);
  }
  putOne(id: number, modelo: Trabajador): Observable<Trabajador> {
    return this.http.put<Trabajador>(`${this.apirul}/${id}`,modelo);
  }

  deleteOne(id: number): Observable<string> {
    return this.http.delete<string>(`${this.apirul}/${id}`);
  }

}
