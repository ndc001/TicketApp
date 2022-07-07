import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TicketsService } from '../services/ticket.service';
import { Ticket } from '../Models/Ticket';
import { Observable } from 'rxjs';
import { Ticket_Type } from '../Models/Ticket_Type';

@Component({
  selector: 'app-createticket',
  templateUrl: './createticket.component.html',
  styleUrls: ['./createticket.component.css']
})
export class CreateticketComponent implements OnInit {
  model: any = {};
  public types = this.ticketService.Get_Ticket_Types();

  

  constructor(private ticketService: TicketsService) { }

  ngOnInit(): void {
  }

Maketicket()
{
  var value = Ticket_Type[this.model.ticket_type];
  this.model.ticket_type = value;  
  console.log(value);
  
  this.ticketService.createticket(this.model).subscribe((response: Ticket) =>
  {
    console.log(response);
  })
}

}
