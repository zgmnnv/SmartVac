<template>
  <div class="account-page">
    <h3>Личный кабинет пользователя</h3>
    <img src="@/assets/img/avatar.png" alt="Avatar Img" class="avatar" />
    <h4>{{ userName }}</h4>
    <button type="button" class="menu-button" @click="goToKids">Мои дети</button>
    <button type="button" class="menu-button" @click="goToAddKids">Добавить ребенка</button>
    <button type="button" class="menu-button" @click="goToLogin">Выйти</button>
  </div>
</template>

<script>
import CommonMethods from "@/components/CommonMethods.js";

export default {
  name: "Account",
  data() {
    return {
      userName: "",
    };
  },
  async created() {
    this.userName = await this.getUserName();
  },
  methods: {
    goToKids() {
      this.$router.push("/kids");
    },
    goToAddKids() {
      this.$router.push("/add_kids");
    },
    goToLogin(){
      this.$router.push("/login");
    },
    async getUserName(){
      const userEmail = CommonMethods.getUserEmailFromLocalStorage();
      const userData = await CommonMethods.getUserDataByEmail(userEmail);
      return userData.name;
    }
  },
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

.account-page {
  font-family: "Lexend", Arial, sans-serif;
  text-align: center;
  padding: 20px;
  background-color: #F2F6FC;
  min-height: 100vh;
  box-sizing: border-box;
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
  max-width: 400px;
  width: 75%;
  margin-bottom: 50px;
}

input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 14px;
}

.menu-button {
  width: 20%;
  padding: 10px;
  background-color: #FFFFFF;
  color: #25396F;
  border: none;
  border-radius: 4px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s;
  margin-bottom: 15px;
}

.menu-button:hover {
  background-color: #d3e4ff;
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
