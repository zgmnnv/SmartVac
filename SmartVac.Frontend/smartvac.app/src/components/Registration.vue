<script setup>
import { ref } from 'vue';

const yourName = ref('');
const babyName = ref('');
const email = ref('');
const dob = ref('');
const country = ref('');
const gender = ref('');
const password = ref('');

const handleSubmit = (event) => {
  event.preventDefault();
  // Логика для отправки данных на сервер здесь
  console.log({
    yourName: yourName.value,
    babyName: babyName.value,
    email: email.value,
    dob: dob.value,
    country: country.value,
    gender: gender.value,
    password: password.value,
  });
};
</script>

<template>
  <div class="container">
    <header class="header">
      <div class="top_bar">
        <div class="logo">
          <img src="@/assets/img/logo_new.svg" alt="logo">
        </div>
      </div>
    </header>

    <div class="center">
      <div class="left_center">
        <form class="registration-form" @submit="handleSubmit">
          <div class="input-block">
            <label for="your-name">Ваше имя:</label>
            <input type="text" id="your-name" v-model="yourName" placeholder="Ольга" required>
          </div>
          <div class="input-block">
            <label for="baby-name">Имя ребёнка:</label>
            <input type="text" id="baby-name" v-model="babyName" placeholder="Даниил" required>
          </div>
          <div class="input-block">
            <label for="email">Email:</label>
            <input type="email" id="email" v-model="email" placeholder="super-mama@mail.ru" required>
          </div>
          <div class="input-block">
            <label for="dob">Дата рождения ребёнка:</label>
            <input type="date" id="dob" v-model="dob" required>
          </div>
          <div class="input-block">
            <label for="country">Страна:</label>
            <select id="country" v-model="country" required>
              <option disabled value="">Выберите страну</option>
              <option value="russia">Россия</option>
              <option value="belarus">Беларусь</option>
              <option value="kazakhstan">Казахстан</option>
            </select>
          </div>
          <div class="input-block">
            <label for="gender">Пол ребёнка:</label>
            <select id="gender" v-model="gender" required>
              <option disabled value="">Выберите пол</option>
              <option value="boy">Мальчик</option>
              <option value="girl">Девочка</option>
            </select>
          </div>
          <div class="input-block">
            <label for="password">Пароль:</label>
            <input type="password" id="password" v-model="password" pattern="^(?=.*[0-9])(?=.*[a-zA-Z]).{8,}$"
                   title="Пароль должен содержать минимум 8 символов, как минимум одну цифру и буквы латинского алфавита"
                   placeholder="Пример пароля: passw0rd" required>
          </div>
          <div class="input-block">
            <button class="submit_button" type="submit">Зарегистрироваться</button>
          </div>
        </form>
      </div>
      <div class="r_center">
        <img src="@/assets/img/doc_registration.svg" alt="doc_registration" class="doc_registration">
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Здесь можно добавить стили */
</style>
