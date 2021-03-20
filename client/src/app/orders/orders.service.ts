import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getOrders() {
    return this.http.get(this.baseUrl + '/orders');
  }

  getOrderDetail(id: number) {
    return this.http.get(this.baseUrl + '/orders/' + id);
  }

  getStatusName(status: String) {
    var statusReturn = "";
    switch (status) {
      case "Pending":
        statusReturn = "Bekliyor";
        break;
      case "PaymentReceived":
        statusReturn = "Ödeme Başarılı";
        break;
      case "PaymentFailed":
        statusReturn = "Ödeme Başarısız";
    }
    return statusReturn;
  }

  getStatusColor(status: String) {
    var statusColor = "";
    switch (status) {
      case "Pending":
        statusColor = "text-warning";
        break;
      case "PaymentReceived":
        statusColor = "text-success";
        break;
      case "PaymentFailed":
        statusColor = "text-danger";
    }
    return statusColor;
  }
}
