<template>
  <div class="registration-page">
    <h1>Добро пожаловать</h1>
    <form @submit.prevent="handleSubmit">
      <div class="form-group">
        <input type="text" v-model="formData.name" placeholder="Ваше имя" required />
      </div>
      <div class="form-group">
        <input type="email" v-model="formData.email" placeholder="Email" required />
      </div>
      <div class="form-group">
        <input type="password" v-model="formData.password" placeholder="Пароль" required />
      </div>
<!--      <div class="form-group">-->
<!--        <input type="text" v-model="formData.country" placeholder="Ваша страна" required />-->
<!--      </div>-->
      <div class="form-group">
        <input type="date" v-model="formData.childBirthDate" placeholder="Дата рождения ребенка" required />
      </div>
      <div class="form-group">
        <input type="text" v-model="formData.childName" placeholder="Имя ребенка" required />
      </div>
<!--      <div class="form-group">-->
<!--        <select v-model="formData.childGender" required>-->
<!--          <option disabled value="">Пол ребенка</option>-->
<!--          <option value="male">Мальчик</option>-->
<!--          <option value="female">Девочка</option>-->
<!--        </select>-->
<!--      </div>-->
      <button type="submit" class="register-button">Зарегистрировать</button>
    </form>
    <a href="/" class="back-link">Назад</a>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formData: {
        name: '',
        email: '',
        password: '',
        // country: '',
        childBirthDate: '',
        childName: '',
        // childGender: ''
      }
    };
  },
  methods: {
    handleSubmit() {
      console.log('Form submitted:', this.formData);
      // Здесь можно добавить отправку данных на сервер
      alert('Форма успешно отправлена!');
    }
  }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Lexend:wght@300;400;700&display=swap");

html, body {
  margin: 0;
  padding: 0;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #4a73bd;
}

.registration-page {
  font-family: "Lexend", Arial, sans-serif;
  text-align: center;
  padding: 20px;
  background-color: #ffffff;
  color: #4a73bd;
  min-height: 100vh;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

h1 {
  font-size: 36px;
  margin-bottom: 40px;
}

form {
  max-width: 400px;
  width: 75%;
  margin-bottom: 50px;
}

.form-group {
  margin-bottom: 15px;
}

input, select {
  width: 100%;
  padding: 10px;
  border: 2px solid #ccc;
  border-radius: 4px;
  font-size: 14px;
}

.register-button {
  width: 106%;
  margin-top: 20px;
  padding: 10px;
  background-color: #4a73bd;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.register-button:hover {
  background-color: #3b5b99;
}

.back-link {
  margin-top: 20px;
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

  .register-button {
    font-size: 18px;
    padding: 8px;
  }
}

@media (min-width: 1024px) {
  h1 {
    font-size: 28px;
  }

  .register-button {
    font-size: 18px;
    padding: 12px;
  }
}
</style>
