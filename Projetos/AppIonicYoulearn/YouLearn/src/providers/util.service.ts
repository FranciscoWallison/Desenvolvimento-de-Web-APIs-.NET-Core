import { Injectable } from "@angular/core";
import { LoadingController, AlertController, ToastController } from '@ionic/angular';
import { map } from 'rxjs/operators';

@Injectable()
export class UtilService {
	constructor(
		public loadingController: LoadingController,
		public alertCtrl: AlertController,
		public toastCtrl: ToastController,
		) {}

  async presentLoading() {
    const loading = await this.loadingController.create({
      message: 'Hellooo',
      duration: 2000
    });
    await loading.present();

    const { role, data } = await loading.onDidDismiss();

    console.log('Loading dismissed!');
  }

	async showLoadingPresent(message: string = "Processando...") {
    const loading = await this.loadingController.create({
			message: message
    });
    return await loading.present();
	}

	async showLoadingDismiss() {
    //this.isLoading = false;
    return await this.loadingController.dismiss().then(() => console.log('dismissed'));
  }

	public showLoading(message: string = "Processando..."): any {
		let loading = this.loadingController.create({
			message: message
		});

		return loading;
	}
	
	public obterHostDaApi(): string {
		return "https://localhost:44318/"
	}

	showMessageErros(response: Response){
		if(response.status == 0){
			this.showAlert("Serviço indisponível!");
		}else if (response.status == 401){
			this.showAlertCallBack("Autorização expirada, é necessário que se autentique novamente.", null, function () {
				localStorage.clear();			
			});
		}else if (response.status == 415) {
			this.showToast("Desculpe, serviço indisponível, tente novamente mais tarde!");
		} else {
			let json: any = response.json();

			if(typeof json.error_description != 'undefined'){
				this.showToast(json.error_description);
			}else if ( typeof json.erros != 'undefined' ){
				for(let erro in json.errors)
				{
					let message = json.errors[erro].message;

					this.showToast(message);
				}
			} else {
				this.showToast("Operação falhou!");
			}
		}
	}

	async showToast(message: string, position: string = 'top') {
		let toast = await this.toastCtrl.create({
			message: message,
			duration: 3000,
			//position: position
		});

		toast.present();
	}

	async showAlert(message: string, title: string = "Atenção") {
		let alert = await this.alertCtrl.create({
			header: title,
			message: message,
			buttons: ['OK']
		});
		return await alert.present();
	}

	async showAlertCallBack(message: string, title: string = "Atenção", callback) {
		let alert = await this.alertCtrl.create({
			header: title,
			message: message,
			buttons: [{
				text: 'OK',
				handler: callback
			}]
		});
		return await alert.present();
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