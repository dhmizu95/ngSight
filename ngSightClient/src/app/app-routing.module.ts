import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SectionHealthComponent } from './sections/SectionHealth/SectionHealth.component';
import { SectionSalesComponent } from './sections/SectionSales/SectionSales.component';
import { SectionOrdersComponent } from './sections/SectionOrders/SectionOrders.component';

const routes: Routes = [
  { path: 'sales', component: SectionSalesComponent },
  { path: 'orders', component: SectionOrdersComponent },
  { path: 'health', component: SectionHealthComponent },
  { path: '', redirectTo: '/sales', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
