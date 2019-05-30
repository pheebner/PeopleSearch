import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PeopleSearchComponent } from './people-search/people-search.component';
import { CreatePersonComponent } from './create-person/create-person.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PeopleSearchComponent,
    CreatePersonComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CustomFormsModule,
    RouterModule.forRoot([
      { path: '', component: PeopleSearchComponent, pathMatch: 'full' },
      { path: 'create-person', component: CreatePersonComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
