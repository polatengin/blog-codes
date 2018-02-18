import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class GlobalMessagingService {

  private static InternalCreating: boolean = false;
  private static Instance: GlobalMessagingService;

  private subject = new Subject<object>();
  messaging$ = this.subject.asObservable();

  constructor() {
    if (!GlobalMessagingService.InternalCreating) {
      throw new Error("You can't instantiate GlobalMessagingService!");
    }
  }

  static GetInstance() {
    if (GlobalMessagingService.Instance == null) {
      GlobalMessagingService.InternalCreating = true;
      GlobalMessagingService.Instance = new GlobalMessagingService();
      GlobalMessagingService.InternalCreating = false;
    }

    return GlobalMessagingService.Instance;
  }

  broadcast(modal: object) {
    this.subject.next(modal);
  }
}
