import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, of } from "rxjs";
import { environment } from "src/environments/environment";
import { Ticket } from "../Models/Ticket";
import { Ticket_Type } from "../Models/Ticket_Type";

@Injectable({
    providedIn: 'root'
})
export class TicketsService {
    baseUrl = environment.baseUrl + "Ticket";
    tickets: Ticket[] = [];
    


    constructor(private http: HttpClient) {}

    createticket(ticket: any)
    {
        return this.http.post<Ticket>(this.baseUrl, ticket);
    }

    Get_Ticket_Types()
    {
        return Object.values(Ticket_Type).filter((x) =>
        { return isNaN(Number(x))});
    }

    View_Tickets()
    {
        if(this.tickets.length > 0) return of(this.tickets);
        return this.http.get<Ticket[]>(this.baseUrl).pipe(map(
            tickets =>
            {
                this.tickets = tickets;
                return tickets;
            }
        ))
    }
   
    
}