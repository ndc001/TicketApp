import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable, of } from "rxjs";
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
    item: Object = {};
    


    constructor(private http: HttpClient) {}

    //Sends a post command to api/CreateTicket with the ticket values in body
    createticket(ticket: any)
    {
        return this.http.post<Ticket>(this.baseUrl + "CreateTicket", ticket);
    }

    //Filters the Ticket_Type enum for non-numbers
    Get_Ticket_Types()
    {
        return Object.values(Ticket_Type).filter((x) =>
        { return isNaN(Number(x))});
    }

    //if it has tickets already it returns the tickets
    //else it sends a get request to /api/GetTickets
    //it maps the response into array of Tickets: tickets
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

    //Finds the ticket by id
    //If it cannot find it, makes an http request /api/GetTicket?id={id}
    View_Ticket_Details(id: number)
    {
        const ticket = this.tickets.find(x => x.ticket_id === id);
        if(ticket !== undefined) return of(ticket);
        
        let queryParams = new HttpParams().append("id", id)
        return this.http.get<Ticket>(this.baseUrl + "GetTicket", {params:queryParams});            
    }

    Delete_Ticket(id: number)
    {
        return this.http.post<Ticket>(this.baseUrl + "DeleteTicket", id);
    }
   
   
}