import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TicketsService } from '../services/ticket.service';
import { Ticket } from '../Models/Ticket';
import { Observable } from 'rxjs';
import { Ticket_Type } from '../Models/Ticket_Type';
import { Router } from '@angular/router';

@Component({
  selector: 'app-createticket',
  templateUrl: './createticket.component.html',
  styleUrls: ['./createticket.component.css']
})
export class CreateticketComponent implements OnInit {
  model: any = {};
  public types = this.ticketService.Get_Ticket_Types();
  ticket_response: any[] = [];
  note_response: any = {};
  Observable = new Observable;
  

  constructor(private ticketService: TicketsService, private router: Router) { }

  ngOnInit(): void {
  }

Maketicket()
{
  var value = Ticket_Type[this.model.ticket_type];
  this.model.ticket_type = value;  
  
  this.ticketService.createticket(this.model).subscribe((response: any) =>
  {
    console.log(response);
    //Next Map values into a Ticket and into a Note
    console.log(response.ticket_response.ticket_id);
    
    this.router.navigate(['/ticket_detail']);
    
  })
  
}

}
