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

    static async getKidDataById(id){
        const childRequest = `http://localhost:5052/api/Child/GetChild/${id}`;
        const childResponse = await axios.get(childRequest);
        return childResponse.data;
    }
    static async getNextKidVaccineData(childId){

       const childData = await this.getKidDataById(childId);
       const lastVacData = await this.getLastKidVaccineData(childId);

        const requestUrl = `http://localhost:5052/api/Vaccine/CalculateNextVaccinationDate`;
        const params = {
            birthDate: childData.birthDate,
            lastVaccinationDate: lastVacData.date,
            lastVaccineId: lastVacData.id,
            childId: childData.id
        };

        const response = await axios.post(requestUrl, params, {
            headers: {
                'Content-Type': 'application/json'
            }
        });

        return {
            name: response.data.vaccine,
            date: response.data.nextVaccinationDate,
            description: response.data.description};
    }

    static async getLastKidVaccineData(id) {
        const request = `http://localhost:5052/api/Manipulation/GetLastManipulationByChildId/${id}`;
        const response = await axios.get(request);

        // Получение дополнительных данных по вакцине
        const vaccineData = await this.getVaccineDataById(response.data.id);

        return {
            name: vaccineData.name,
            date: response.data.vaccineDate,
            vaccineId: response.data.id,
            description: vaccineData.description };
    }

    static async getVaccineDataById(vaccineId){
        const request = `http://localhost:5052/api/Vaccine/GetVaccine/${vaccineId}`;
        const response = await axios.get(request);
        return response.data;
    }
}

export default CommonMethods;