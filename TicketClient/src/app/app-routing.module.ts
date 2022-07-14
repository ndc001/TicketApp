import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CreateticketComponent } from "./createticket/createticket.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { LoginComponent } from "./login/login.component";
import { PagenotfoundComponent } from "./pagenotfound/pagenotfound.component";
import { TicketDetailComponent } from "./ticket_detail/ticket_detail.component";
import { TicketlistComponent } from "./ticket_list/ticket_list.component";

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'createticket', component: CreateticketComponent },
    { path: 'ticket_list', component: TicketlistComponent},
    { path: 'ticket_detail', component: TicketDetailComponent},
    { path: '**', component: PagenotfoundComponent },
    
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }