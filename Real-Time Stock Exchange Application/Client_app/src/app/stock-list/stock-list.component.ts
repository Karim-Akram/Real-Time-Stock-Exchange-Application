import { Component, OnInit } from '@angular/core';
import { StockService } from '../stock.service';


@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html',
  styleUrls: ['./stock-list.component.css']
})
export class StockListComponent implements OnInit {

  stocks: any[] = [];

  constructor(private stockService: StockService) { }

  ngOnInit(): void {
    this.stockService.getStockData().subscribe(data => {
      this.stocks = data;
    });
  }
}
