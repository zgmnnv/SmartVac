<script>
import axios from 'axios';

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
    getUserEmailFromLocalStorage() {
      return localStorage.getItem('userEmail') || '';
    },

    async handleAddKid() {
      // Получаем данные формы
      const userEmail = this.getUserEmailFromLocalStorage();

      const formData = {
        name: this.formData.name,
        birthDate: this.formData.birthDate
      };

      try {
        // Получение данных пользователя по email
        const { data: userData } =
            await axios.get(`http://localhost:5052/api/User/GetUserDataByEmail/${userEmail}`, {});

        if (!userData || !userData.id) {
          throw new Error("Не удалось получить данные пользователя.");
        }

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
      } catch (error) {
        console.error('Ошибка при добавлении записи:', error.message);
        alert('Произошла ошибка. Попробуйте позже.');
      }
    }
  }
};
</script>

<template>
  <div class="add-kids-page">
    <h3>Добавьте информацю о ребенке</h3>
    <form @submit.prevent="handleAddKid">
      <div class="form-group">
        <input type="text" v-model="formData.name" placeholder="Имя" required />
      </div>
      <div class="form-group">
        <input type="email" v-model="formData.birthDate" placeholder="Дата рождения" required />
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
}
h4 {
  color: #25396F;
  font-style: normal;
}

form {
  max-width: 250px;
  width: 100%;
  margin-bottom: 50px;
}

.form-group {
  margin-bottom: 15px;
}

.add-kid-button {
  width: 109%;
  padding: 10px;
  background-color: #4a73bd;
  color: #FFFFFF;
  border: none;
  border-radius: 4px;
  font-size: 16px;
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
  font-size: 14px;
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

/* Адаптивный дизайн */
@media (max-width: 768px) {
  h1 {
    font-size: 20px;
  }

  .menu-button {
    font-size: 18px;
    padding: 8px;
  }
}

@media (min-width: 1024px) {
  h1 {
    font-size: 28px;
  }

  .menu-button {
    font-size: 18px;
    padding: 12px;
  }
}
</style>