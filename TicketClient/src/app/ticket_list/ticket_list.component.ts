import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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

  constructor(private ticket_service: TicketsService, private router: Router) { }

  ngOnInit(): void {
    this.tickets$ = this.ticket_service.View_Tickets();
  }

  go_to_page(id: number)
  {
    this.router.navigate(['/ticket_detail'], { queryParams: { id: id }});
  }

  delete(id: number)
  {
    this.ticket_service.Delete_Ticket(id);
    this.ticket_service.View_Tickets();
  }
}
