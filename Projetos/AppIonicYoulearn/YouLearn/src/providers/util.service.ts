import { Injectable } from "@angular/core";
import { LoadingController } from '@ionic/angular';
import { map } from 'rxjs/operators';

@Injectable()
export class UtilService {
	constructor(public loadingController: LoadingController) {}

  async presentLoading() {
    const loading = await this.loadingController.create({
      message: 'Hellooo',
      duration: 2000
    });
    await loading.present();

    const { role, data } = await loading.onDidDismiss();

    console.log('Loading dismissed!');
  }

  async presentLoadingWithOptions() {
    const loading = await this.loadingController.create({
      spinner: null,
      duration: 5000,
      message: 'Please wait...',
      translucent: true,
      cssClass: 'custom-class custom-loading'
    });
    return await loading.present();
	}
	
	public obterHostDaApi(): string {
		return "http://localhost:44056/"
	}
}

/*
	public obterHostDaApi(): string {
		return "http://localhost:44056/"
	}

	public showLoading( message : string = "Processing...") : any {

		let loading;

		try {
			
			loading = this.loadCtrk.create({
				message: message
			});
		} catch (e) {
			return false;
		}

    	
    	return loading.present();	
	} 
	
	public showToast(message: string, position: string = 'top'): any {

		let toast = this.toastCtrl.create({
			message: message,
			duration: 3000,
			position: position
		});

	}

	public isJson(json: string): boolean {
		try {
			JSON.parse(json);
		} catch (e) {
			return false;
		}

		return true;
	}

	public effectLogoff() {
		localStorage.clear();
	}

	//showMessageError(response: Response){}
}
*/