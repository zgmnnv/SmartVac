<template>
  <div class="account-page">
    <h1>Добро пожаловать</h1>

    <img src="@/assets/img/avatar.png" alt="Avatar Img" class="avatar" />
    <button type="button" class="login-button">Мои дети</button>
    <button type="button" class="login-button">Изменить данные профиля</button>
    <button type="button" class="login-button">Связаться с разработчиками</button>
    <button type="button" class="login-button">Выйти</button>
  </div>
</template>

<script>
import apiClient from '@/services/api-client';

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
  background-color: #f7f9fc;
}

.login-page {
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
  font-size: 24px;
  margin-bottom: 20px;
}

form {
  max-width: 400px;
  width: 75%;
  margin-bottom: 50px;
}

.form-group {
  margin-bottom: 15px;
}

input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 14px;
}

.login-button {
  width: 106%;
  padding: 10px;
  background-color: #4a73bd;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.login-button:hover {
  background-color: #3b5b99;
}

.back-link {
  margin-left: 30px;
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

  .login-button {
    font-size: 18px;
    padding: 8px;
  }
}

@media (min-width: 1024px) {
  h1 {
    font-size: 28px;
  }

  .login-button {
    font-size: 18px;
    padding: 12px;
  }
}
</style>
