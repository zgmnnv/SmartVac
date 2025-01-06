<template>
  <div class="kids-container">
    <h3>Ваши дети</h3>
    <ul class="list-of-kids">
      <li v-for="child in kidsList" :key="child.id">
        <button class="kid-name-button">
          {{ child.name }}
        </button>
      </li>
    </ul>
    <button type="button" class="back-button" @click="goToAccount">Вернуться в профиль</button>
  </div>
</template>

<script>
import CommonMethods from '@/components/CommonMethods.js';

export default {
  data() {
    return {
      kidsList: [],
    };
  },
  mounted() {
    this.fetchKids();
  },
  methods: {
    goToAccount() {
      this.$router.push('/account');
    },
    async fetchKids() {
      try {
        const userEmail = CommonMethods.getUserEmailFromLocalStorage();
        const userData = await CommonMethods.getUserDataByEmail(userEmail);
        this.kidsList = await CommonMethods.getKidsListByUserId(userData.id);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
</script>

<style scoped>
html, body {
  margin: 0;
  padding: 0;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #4a73bd;
}

.kids-container {
  font-family: "Lexend", Arial, sans-serif;
  text-align: center;
  padding: 20px;
  background-color: #F2F6FC;
  color: #4a73bd;
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
}

h3 {
  font-size: 18px;
  color: #25396F;
  margin-bottom: 20px;
}

.list-of-kids {
  list-style-type: none;
  margin: 0;
  padding: 0;
  width: 100%;
}

.kid-name-button,
.back-button {
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

.back-button:hover {
  background-color: #d3e4ff;
}
.kid-name-button:hover {
  background-color: #d3e4ff;
}

.back-button {
  margin-top: 30px;
}

/* Адаптивный дизайн */
@media (max-width: 768px) {
  .kid-name-button,
  .back-button {
    font-size: 18px;
    padding: 8px;
  }
}

@media (min-width: 1024px) {
  .kid-name-button,
  .back-button {
    font-size: 18px;
    padding: 12px;
  }
}
</style>