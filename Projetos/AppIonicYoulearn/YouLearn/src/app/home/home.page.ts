import { Component } from '@angular/core';
import { UtilService } from 'src/providers/util.service';
import { VideoService } from 'src/providers/video.service';
//import { UtilService } from ' ./../providers/util.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
	
	videos : any[] = [];
  constructor(private utilService: UtilService, private videoService : VideoService) {}

	searchVideo(tag : string ){
		console.log(tag);

		if(tag == null || tag.toString() == ''){
			return;
		}

		this.loadVideo(tag);
	}

	loadVideo(tag : string){
		//Abrir a tela de aguarde
		this.utilService.showLoadingPresent();
		
		
		//Chamr a API
		this.videoService.listarPorTags(tag).then((response) =>{
			//Populo minhas lista de videos em um array
			this.videos = response.json();

			console.log(this.videos,"resposta api");
			
			this.utilService.showLoadingDismiss();
		}).catch((response) => {
			//this.utilService.showMessageError(response);
		});
	}

}

