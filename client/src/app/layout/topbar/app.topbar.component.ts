import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { NavigationEnd, Router } from '@angular/router';
import { tap } from 'rxjs/operators';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html',
    styleUrls: ['./app.topbar.component.css']
})
export class AppTopBarComponent implements OnInit, OnDestroy {

    subscribedTo: Subscription[] = [];
    currentUrl: string;

    constructor(private router: Router) {
        this.subscribedTo.push(this.router.events.pipe(tap(evt => {
            if (evt && evt instanceof NavigationEnd) {
                this.currentUrl = evt.url;
            }
        })).subscribe());
    }

    ngOnInit(): void {
    }

    ngOnDestroy() {
        if (this.subscribedTo?.length) {
            this.subscribedTo.forEach(s => s.unsubscribe());
        }
    }
}
