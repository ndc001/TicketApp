import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateticketComponent } from './createticket/createticket.component';
import { AppRoutingModule } from './app-routing.module';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { FormsModule } from '@angular/forms';
import { TicketlistComponent } from './ticket_list/ticket_list.component';
import { TicketDetailComponent } from './ticket_detail/ticket_detail.component';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    CreateticketComponent,
    PagenotfoundComponent,
    TicketlistComponent,
    TicketDetailComponent,
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    FormsModule,
    ToastrModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
