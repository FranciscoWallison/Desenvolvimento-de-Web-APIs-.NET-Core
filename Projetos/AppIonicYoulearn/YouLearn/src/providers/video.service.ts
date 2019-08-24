import { UtilService } from './util.service';
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Observable } from 'rxjs'; 

@Injectable()

export class VideoService {
    constructor(public http: Http, public utilService: UtilService ){}

    listarPorTags(tags: string): Promise<Response> {
        let host = this.utilService.obterHostDaApi();

        let headers = new Headers();

        headers.append('Content-Type', 'application/json');

        return this.http.get(host + 'api/v1/Video/List/' + tags, {headers: headers}).toPromise();
    }

    listarPorPlayList( idPlayList: string ): Promise<Response>{
        let host = this.utilService.obterHostDaApi();

        let headers = new Headers();
        headers.append('Content-Type', 'applicattion/json');

        return this.http.get(host + 'api/v1/Video/List/' + idPlayList, { headers: headers }).toPromise();

    }

    adicionar(request: any): Promise<Response>{
        let host = this.utilService.obterHostDaApi();

        let headers : any = new Headers();
        headers.append('Content-Type', 'applicattion/json');
        headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

        return this.http.post(host + 'api/v1/Video/Add/' + request, { headers: headers }).toPromise();

    }
}