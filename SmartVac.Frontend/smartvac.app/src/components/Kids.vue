<template>
  <div class="kids-container">
    <img src="@/assets/img/father_addkids_img.png" alt="FatherBabyImg" class="father_baby_img" />
    <ul class="list-of-kids">
      <li v-for="child in kidsList" :key="child.id">
        <button class="kid-name-button" :id="child.id" @click="goToKidsAccount(child.id)">
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
    goToKidsAccount(id) {
      this.$router.push(`/kids_account/${id}`);
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

.father_baby_img {
  width: 250px;
  margin-bottom: 30px;
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
  width: 250px;
  padding: 12px;
  background-color: #FFFFFF;
  color: #25396F;
  border: none;
  border-radius: 4px;
  font-size: 18px;
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
</style>