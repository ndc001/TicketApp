import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Ticket } from '../Models/Ticket';
import { TicketsService } from '../services/ticket.service';

@Component({
  selector: 'app-ticket-detail',
  templateUrl: './ticket_detail.component.html',
  styleUrls: ['./ticket_detail.component.css']
})
export class TicketDetailComponent implements OnInit {
  ticket: Ticket | undefined;
  id: number = 0;

  constructor(private ticket_service: TicketsService, private activated_route: ActivatedRoute) { }

  ngOnInit(): void {
    this.activated_route.params.forEach((params: Params) => 
    {
      if(params['id'] !== undefined) {
        const id = +params['id'];
        this.ticket_service.View_Ticket_Details(id).subscribe(ticket =>
          {
            this.ticket = ticket;
          })
      }
    })
    
      
  }

}
