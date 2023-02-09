import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddressDTO } from './AddressDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient) { }

  getAddresses() {
    return this.http.get<AddressDTO[]>('https://localhost:44355/api/address');
  }

  getAddressById(id: number) {
    return this.http.get<AddressDTO>(`https://localhost:44355/api/address/${id}`);
  }

  deleteAddressById(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/address/${id}`);
  }

  deleteAllAddresses(): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/address`);
  }
}
