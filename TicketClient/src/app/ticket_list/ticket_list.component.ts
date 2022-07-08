import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Ticket } from '../Models/Ticket';
import { TicketsService } from '../services/ticket.service';

@Component({
  selector: 'app-ticket_list',
  templateUrl: './ticket_list.component.html',
  styleUrls: ['./ticket_list.component.css']
})
export class TicketlistComponent implements OnInit {
tickets$: Observable<Ticket[]> | undefined;

  constructor(private ticket_service: TicketsService) { }

  ngOnInit(): void {
    this.tickets$ = this.ticket_service.View_Tickets();
  }

}
