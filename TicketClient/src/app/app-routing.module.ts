import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CreateticketComponent } from "./createticket/createticket.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { LoginComponent } from "./login/login.component";
import { PagenotfoundComponent } from "./pagenotfound/pagenotfound.component";
import { TicketlistComponent } from "./ticketlist/ticketlist.component";

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'createticket', component: CreateticketComponent },
    { path: 'ticketlist', component: TicketlistComponent},
    { path: '**', component: PagenotfoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }