import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { Ticket } from '../Models/Ticket';
import { TicketsService } from '../services/ticket.service';

@Component({
  selector: 'app-ticket-detail',
  templateUrl: './ticket_detail.component.html',
  styleUrls: ['./ticket_detail.component.css']
})
export class TicketDetailComponent implements OnInit {
ticket$: Observable<Ticket> | undefined;
ticket: Ticket | undefined;


  constructor(private ticket_service: TicketsService, private activated_route: ActivatedRoute) { }

  ngOnInit(): void {
    this.activated_route.queryParams.subscribe(params =>
      {
        let id = params['id'];
        console.log(id);
        this.ticket_service.View_Ticket_Details(id).pipe(map(ticket =>
          {
            this.ticket = ticket;
            console.log(this.ticket);
          })).subscribe();
        
        
        //.subscribe(ticket => (this.ticket = ticket));
        
      })
}

}
