<script>
import axios from 'axios';
import CommonMethods from '@/components/CommonMethods.js';

export default {
  data() {
    return {
      formData: {
        name: '',
        birthDate: ''
      }
    };
  },
  methods: {
    async handleAddKid() {
      // Получаем данные формы
      const formData = {
        name: this.formData.name,
        birthDate: this.formData.birthDate
      };

      const userEmail = CommonMethods.getUserEmailFromLocalStorage();

      try {

        const userData = await CommonMethods.getUserDataByEmail(userEmail)

        // Добавляем parentId в объект данных для отправки
        formData.parentId = userData.id;

        // Отправка данных для добавления нового ребенка
        const response = await axios.post(
            'http://localhost:5052/api/Child/CreateChild',
            formData,
            {
              headers: {
                'Content-Type': 'application/json'
              }
            }
        );

        console.log('Успешное добавление ребенка:', response.data);
        alert('Вы успешно добавили ребенка!');
        this.$router.push('/kids');
      }
      catch (error) {
        console.error('Ошибка при добавлении записи:', error.message);
        alert('Произошла ошибка. Попробуйте позже.');
      }
    }
  }
};
</script>

<template>
  <div class="add-kids-page">
    <img src="@/assets/img/father_baby.svg" alt="doc_male" class="doc_img">
    <form @submit.prevent="handleAddKid">
      <div class="form-group">
        <input type="text" v-model="formData.name" placeholder="Имя" required />
      </div>
      <div class="form-group">
        <input type="date" v-model="formData.birthDate" placeholder="Дата рождения" required />
      </div>
      <button type="submit" class="add-kid-button">Сохранить</button>
    </form>
    <a href="/account" class="back-link">Назад</a>
  </div>
</template>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Lexend:wght@300;400;700&display=swap");

html, body {
  margin: 0;
  padding: 0;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #f7f9fc;
}

.add-kids-page {
  font-family: "Lexend", Arial, sans-serif;
  text-align: center;
  padding: 20px;
  background-color: #F2F6FC;
  color: #4a73bd;
  box-sizing: border-box;
  min-height: 100vh;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

h3 {
  font-size: 18px;
  color: #25396F;
  margin-bottom: 20px;
  margin-left: 40px;
  text-align: left;
}
h4 {
  color: #25396F;
  font-style: normal;
}

form {
  width: 230px;
  margin-bottom: 25px;
  font-size: 18px;
}
.doc_img {
  width: 250px;
  margin-bottom: 25px;
}

.form-group {
  margin-bottom: 15px;
  font-size: 18px;
}

.add-kid-button {
  width: 250px;
  padding: 12px;
  background-color: #4a73bd;
  color: #FFFFFF;
  border: none;
  border-radius: 4px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s;
  margin-bottom: 15px;
}

.add-kid-button:hover {
  background-color: #3b5b99;
}

input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 18px;
}

.back-link {
  margin-top: 20px;
  margin-left: 30px;
  font-size: 18px;
  color: #4a73bd;
  text-decoration: none;
  cursor: pointer;
  transition: color 0.3s;
}

.back-link:hover {
  color: #3b5b99;
}
</style>