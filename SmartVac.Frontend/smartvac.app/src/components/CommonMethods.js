import axios from "axios";

class CommonMethods{
   static getUserEmailFromLocalStorage(){
        return localStorage.getItem("userEmail");
    }

    static async getUserDataByEmail(email) {
        const userDataResponse =
             await axios.get('http://localhost:5052/api/User/GetUserByEmail', {
                params: {
                    email: email
                }
            });

        if (userDataResponse.status !== 200) {
            throw new Error('Сервер вернул ошибку: ' + userDataResponse.statusText);
        }

        const userData = userDataResponse.data;
        console.log('Полученные данные:', userData);

        return userData;
    }

    static async getKidsListByUserId(id){

        const response =
            await axios.get(`http://localhost:5052/api/Child/GetChildrenByUser/${id}`, { });

        if (response.status !== 200) {
            throw new Error('Сервер вернул ошибку: ' + response.statusText);
        }

        return response.data;
    }

    static async getLastKidVaccineData(id){
        const request = `http://localhost:5052/api/Manipulation/GetLastManipulationByChildId/${id}`;
        const response = await axios.get(request);
        return await this.getVaccineDataById(response.data.id);
    }

    static async getVaccineDataById(vaccineId){
        const request = `http://localhost:5052/api/Vaccine/GetVaccine/${vaccineId}`;
        const response = await axios.get(request);
        return response.data;
    }
}

export default CommonMethods;