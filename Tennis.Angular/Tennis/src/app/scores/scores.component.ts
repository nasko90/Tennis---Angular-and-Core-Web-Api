import { Component, OnInit } from '@angular/core';
import {Player} from '../Models/Player';

@Component({
  selector: 'app-scores',
  templateUrl: './scores.component.html',
  styleUrls: ['./scores.component.css']
})
export class ScoresComponent implements OnInit {
  nasko = new Player("2",'nasko',);
  vasko = new Player("1", 'vasko');


  selectedPlayer = "Select Player";
  players: Player[] = [this.nasko, this.vasko] ;
 
  constructor() { }

  ngOnInit() {
  }

  getPlayers(){
    
  }
}
