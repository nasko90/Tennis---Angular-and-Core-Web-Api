import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from "@angular/http";
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from './app.component';
import { RankingComponent } from './ranking/ranking.component';
import { GalleryComponent } from './gallery/gallery.component';
import { HomeComponent } from './home/home.component';
import { ScoresComponent } from './scores/scores.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';

const appRoutes: Routes =  [
  { path: 'home', component: HomeComponent},
  { path: '', component: NavbarComponent},
  { path: 'gallery', component: GalleryComponent},
  { path: 'ranking', component: RankingComponent},
  { path: 'scores', component: ScoresComponent},
  { path: 'login', component: LoginComponent},
  { path: '**', component: NotFoundPageComponent},
]


@NgModule({
  declarations: [
    AppComponent,
    RankingComponent,
    GalleryComponent,
    ScoresComponent,
    HomeComponent,
    NotFoundPageComponent,
    LoginComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
