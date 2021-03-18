import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  order: IOrder;
  constructor(private route: ActivatedRoute, private bcService: BreadcrumbService, private ordersService: OrdersService) {
    this.bcService.set('@OrderDetail', '');
  }

  ngOnInit(): void {
    this.ordersService.getOrderDetail(+this.route.snapshot.paramMap.get('id'))
      .subscribe((order: IOrder) => {
        this.order = order;
        this.bcService.set('@OrderDetail', `Sipariş # ${order.id} - ${this.ordersService.getStatusName(order.status)}`);
      }, error => {
        console.log(error);
      });
  }

}
