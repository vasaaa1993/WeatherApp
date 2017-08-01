import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class BaceService {
    protected baseUrl:string
    protected parUrl;
    constructor(
        protected http: Http,
        ) {
            this.baseUrl = 'http://localhost:50185/api/';
        }

    protected getDataObservable(url:string){
        return this.http.get(url)
            .map(res => res.json());
    }
    
    protected putDataObservable(url:string, body: any){
        return this.http.put(url, body);
    }
}
