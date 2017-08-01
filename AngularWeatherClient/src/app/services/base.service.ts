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

    protected generateUrl():string{
        return this.baseUrl + this.parUrl;
    }
    protected getData(url:string){
        return this.http.get(url)
            .map(res => res.json());
    }
    
    protected putData(url:string, body: any){
        return this.http.put(url, body);
    }

    protected deleteData(url:string){
        return this.http.delete(url);
    }
}
