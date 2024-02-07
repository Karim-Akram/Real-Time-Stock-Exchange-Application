import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http: HttpClient) { }

  getStockData(): Observable<any> {
    
    return this.http.get<any>('https://localhost:7179/api/stocks?symbol=AAPL');
  }
}

