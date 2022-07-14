import { Ticket_Type } from "./Ticket_Type";
import { Resolution_Type } from "./Resolution_Type";
import { Ticket_Status } from "./Status";

export interface Ticket {
    ticket_id: number;
    title: string;
    ticket_description: string;
    ticket_type: Ticket_Type;    
    resolution_type: Resolution_Type;    
    ticket_status: Ticket_Status;
    resolution_note: string;
    assigned_date: Date;
    created_date: Date;
    resolved_date: Date;
        
}