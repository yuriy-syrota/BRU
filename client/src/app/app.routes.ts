import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { LandingPageComponent } from './public/landing-page/landing-page.component';
import { InventoryComponent } from './public/inventory/inventory.component';

export const routes: Routes = [
    { path: '', component: LandingPageComponent, data: {title: 'Bikes "R" Us'} },
    { path: 'inventory', component: InventoryComponent, data: {title: 'Inventory'} }
];

export const AppRoutes: ModuleWithProviders<unknown> = RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled', relativeLinkResolution: 'legacy' });
