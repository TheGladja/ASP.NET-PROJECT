import { Component, OnInit } from '@angular/core';
import { AddressService } from './AddressService';
import { AddressDTO } from './AddressDTO';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {
  addresses: AddressDTO[];
  selectedAddress: AddressDTO;

  constructor(private addressService: AddressService) { }

  ngOnInit() {
    this.addressService.getAddresses().subscribe(addresses => {
      this.addresses = addresses;
    });
  }

  getAddressById(id: number) {
    this.addressService.getAddressById(id).subscribe(address => {
      this.selectedAddress = address;
    });
  }

  deleteAddressById(id: number) {
    this.addressService.deleteAddressById(id).subscribe();
    window.location.reload();
  }

  deleteAllAddresses() {
    this.addressService.deleteAllAddresses().subscribe();
    window.location.reload();
  }
}
