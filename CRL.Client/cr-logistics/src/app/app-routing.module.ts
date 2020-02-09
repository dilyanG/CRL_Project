import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LogisticCenterComponent } from './components/logistic-center/logistic-center.component';


const routes: Routes = [
  { path: '', component: LogisticCenterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
