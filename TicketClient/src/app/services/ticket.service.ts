import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, of } from "rxjs";
import { environment } from "src/environments/environment";
import { Ticket } from "../Models/Ticket";
import { Ticket_Type } from "../Models/Ticket_Type";

@Injectable({
    providedIn: 'root'
})
export class TicketsService {
    baseUrl = environment.baseUrl;
    tickets: Ticket[] = [];
    ticket: Ticket | undefined;
    


    constructor(private http: HttpClient) {}

    createticket(ticket: any)
    {
        return this.http.post<Ticket>(this.baseUrl + "CreateTicket", ticket);
    }

    Get_Ticket_Types()
    {
        return Object.values(Ticket_Type).filter((x) =>
        { return isNaN(Number(x))});
    }

    View_Tickets()
    {
        if(this.tickets.length > 0) return of(this.tickets);
        return this.http.get<Ticket[]>(this.baseUrl + "GetTickets").pipe(map(
            tickets =>
            {
                this.tickets = tickets;
                return tickets;
            }
        ))
    }

    View_Ticket_Details(id: number)
    {
        const ticket = this.tickets.find(x => x.ticket_id === id);
        if(ticket !== undefined) return of(ticket);
        
        let queryParams = new HttpParams().append("id", id)
        return this.http.get<Ticket>(this.baseUrl + "GetTicket", {params:queryParams});
            
    }
   
    
}