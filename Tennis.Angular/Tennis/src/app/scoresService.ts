import { Injectable } from '@angular/core';  
import { Http, Headers, RequestOptions, Response } from '@angular/http';  
import { Player } from './Models/Player';  
import { Observable, Subject } from 'rxjs/Rx';  
import 'rxjs/Rx'; //get everything from Rx  
import 'rxjs/add/operator/toPromise';  
import { Constants } from "../app/Common/Constants";
@Injectable()  

export class ScoresServices {  
apiUrl: string = Constants.Api_Url;// Web API URL  

constructor(private _http: Http) { }  
private RegenerateData = new Subject<number>();  
RegenerateData$ = this.RegenerateData.asObservable();  
AnnounceChange(mission: number) {  
this.RegenerateData.next(mission);  
}  
// //  
// getCricketers() {  
// return this._http.get(this.apiUrl)  
// .map((response) => response.json());  
//}  
getPlayers(): Observable<Player[]> {  

return this._http.get(this.apiUrl + "/players")  
.map((res: Response) => res.json())  
.catch((error: any) => Observable.throw(error.json().error || 'Server error'));  
}  
}  