import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CreditCard } from '../credit-card';
import { CreditCardService } from '../credit-card-service.service';

@Component({
  selector: 'app-cc',
  templateUrl: './cc.component.html',
  styleUrls: ['./cc.component.css']
})
export class CCComponent implements OnInit {
  dataSaved = false;
  creditCardForm: any;
  allCards: Observable<CreditCard[]>;
  cardIdUpdate = null;
  massage = null;

  constructor(private formbulider: FormBuilder, private creditCardService: CreditCardService) { }

  ngOnInit() {
    this.creditCardForm = this.formbulider.group({
      CardId: ['', [Validators.required]],
      CardNumber: ['', [Validators.required]],
      AccountNumber: ['', [Validators.required]],
      InitialBalance: ['', [Validators.required]],
      Age: ['', [Validators.required]],
      Address: ['', [Validators.required]],
      Name: ['', [Validators.required]]

    });
    this.loadAllCards();
  }
  loadAllCards() {
    debugger;
    this.allCards = this.creditCardService.getAllCards();
    console.log(this.allCards);
  }
  onFormSubmit() {
    this.dataSaved = false;
    const cards = this.creditCardForm.value;
    this.CreateEmployee(cards);
    this.creditCardForm.reset();
  }
  loadCardToEdit(cardId: string) {
    this.creditCardService.getCardById(cardId).subscribe(creditcard => {
      this.massage = null;
      this.dataSaved = false;
      this.cardIdUpdate = creditcard.cardId;
      this.creditCardForm.controls['CardId'].setValue(creditcard.cardId);
      this.creditCardForm.controls['CardNumber'].setValue(creditcard.cardNumber);
      this.creditCardForm.controls['AccountNumber'].setValue(creditcard.accountNumber);
      this.creditCardForm.controls['InitialBalance'].setValue(creditcard.initialBalance);
      this.creditCardForm.controls['Age'].setValue(creditcard.age);
      this.creditCardForm.controls['Address'].setValue(creditcard.address);
      this.creditCardForm.controls['Name'].setValue(creditcard.name);

    });

  }
  CreateEmployee(creditCard: CreditCard) {
    if (this.cardIdUpdate == null) {
      console.log(creditCard);
      this.creditCardService.createCreditCard(creditCard).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          this.loadAllCards();
          this.cardIdUpdate = null;
          this.creditCardForm.reset();
        }
      );
    } else {
      creditCard.cardId = this.cardIdUpdate;
      this.creditCardService.updateCard(creditCard).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        this.loadAllCards();
        this.cardIdUpdate = null;
        this.creditCardForm.reset();
      });
    }
  }
  deleteCard(cardId: string) {
    if (confirm("Are you sure you want to delete this ?")) {
      this.creditCardService.deleteCardById(cardId).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Deleted Succefully';
        this.loadAllCards();
        this.cardIdUpdate = null;
        this.creditCardForm.reset();

      });
    }
  }
  resetForm() {
    this.creditCardForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }

}

