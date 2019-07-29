import { Component } from '@angular/core';
import { LoadingController } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(public loadingController: LoadingController) {}

	searchVideo(tag : string ){
		console.log(tag);

		if(tag == null || tag.toString() == ''){
			return;
		}

		this.loadVideo(tag);
	}

	async loadVideo(tag : string){
		const  loading = await this.loadingController.create({
			spinner: null,
			duration: 5000,
			message: 'Please wait...',
			translucent: true,
			cssClass: 'custom-class custom-loading'
		});
    	
    	return  await loading.present();
	}

}

