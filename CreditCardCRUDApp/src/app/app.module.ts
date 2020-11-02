import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreditCardService } from './credit-card-service.service';

//import { CreditCardDetailListComponent } from './creditCard-detail-list.component';
//import { CreditCardDetailsComponent } from './creditCard-details.component';
//import { CreditCardDetailComponent } from './creditCard.component';
import { CCComponent } from './CC/cc.component';

@NgModule({
declarations: [
    AppComponent,
    //CreditCardDetailComponent,
    //CreditCardDetailListComponent,
    //CreditCardDetailsComponent,
    CCComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatDatepickerModule,
    MatIconModule,
    MatRadioModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,  
    ToastrModule.forRoot()
  ],
  providers: [HttpClientModule, CreditCardService, ReactiveFormsModule, MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
