<template>
  <div class="login-page">
    <h1>Добро <br>пожаловать</h1>
    <form @submit.prevent="handleLogin">
      <div class="form-group">
        <input type="email" v-model="loginData.email" placeholder="Email" required />
      </div>
      <div class="form-group">
        <input type="password" v-model="loginData.password" placeholder="Пароль" required />
      </div>
      <button type="submit" class="login-button">Войти</button>
    </form>
    <a href="/" class="back-link">Назад</a>
  </div>
</template>

<script>
import apiClient from '@/services/api-client';

export default {
  data() {
    return {
      loginData: {
        email: '',
        password: ''
      }
    };
  },
  methods: {
    async handleLogin() {
      try {
        const response = await apiClient.post('/User/LoginUser', this.loginData);
        const token = response.data.token;
        localStorage.setItem('access_token', token);
        localStorage.setItem('userEmail', this.loginData.email);
        this.$router.push('/account')

      } catch (error) {
        console.error(error);
        alert('Произошла ошибка при входе.');
      }
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
  background-color: #f7f9fc;
}

.login-page {
  font-family: "Lexend", Arial, sans-serif;
  text-align: center;
  padding: 20px;
  background-color: #F2F6FC;
  color: #4a73bd;
  min-height: 100vh;
  width: 100%;
  display: flex;
  flex-direction: column;
  box-sizing: border-box;
  justify-content: center;
  align-items: center;
}

.logo {
  width: 250px;
  margin-bottom: 150px;
  margin-left: 20px;
}

h1 {
  font-size: 40px;
  margin-bottom: 30px;
  text-align: left;
}

form {
  max-width: 250px;
  width: 100%;
  margin-bottom: 25px;
}

.form-group {
  margin-bottom: 15px;
}

input {
  width: 100%;
  padding: 10px;
  border: 2px solid #d3e4ff;
  border-radius: 4px;
  font-size: 16px;
}

.login-button {
  width: 109%;
  padding: 10px;
  background-color: #4a73bd;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 18px;
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
</style>
