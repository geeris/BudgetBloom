import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  
  constructor(private messageService: MessageService) { }

  showSuccess(message: string): void {
    this.messageService.add({severity: 'success', summary: 'Success', detail: message, life: 6000});
  }

  showError(message: string): void {
    this.messageService.add({severity: 'error', summary: 'Error', detail: message, life: 6000});
  }
}