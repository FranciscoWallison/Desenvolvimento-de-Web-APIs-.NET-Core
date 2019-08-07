import { Component } from '@angular/core';
import { UtilService } from 'src/providers/util.service';
//import { UtilService } from ' ./../providers/util.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(private utilService: UtilService) {}

	searchVideo(tag : string ){
		console.log(tag);

		if(tag == null || tag.toString() == ''){
			return;
		}

		this.loadVideo(tag);
	}

	loadVideo(tag : string){
		let loading = this.utilService.presentLoadingWithOptions();
	}

}

