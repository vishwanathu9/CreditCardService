import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { throwError, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CreditCard } from "../app/credit-card";

//After that we write all methods related to consume web in employee.service.ts
@Injectable({
  providedIn: 'root'
})

export class CreditCardService {
  url = 'http://localhost:60606/api/CreditCard/';
  constructor(public http: HttpClient) { }
  debugger;
  getAllCards(): Observable<CreditCard[]> {
    return this.http.get<CreditCard[]>(this.url + 'AllcardDetails');
  }
  getCardById(cardId: string): Observable<CreditCard> {
    return this.http.get<CreditCard>(this.url + 'GetCardDetailById/' + cardId);
  }
  createCreditCard(creditCard: CreditCard): Observable<CreditCard> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<CreditCard>(this.url + 'InsertCreditCardDetails/',
      creditCard, httpOptions);
  }
  updateCard(creditCard: CreditCard): Observable<CreditCard> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<CreditCard>(this.url + 'UpdateCreditCardDetails/' + creditCard.cardId,
      creditCard, httpOptions);
  }
  deleteCardById(cardId: string): Observable<string> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<string>(this.url + 'Delete/' + cardId,
      httpOptions);
  }
}  
