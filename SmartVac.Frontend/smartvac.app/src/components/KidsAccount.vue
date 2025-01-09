<template>
  <div class="kids-account-container">
    <div class="vaccines">
      <div class="last-vaccination">
        <h4>Последняя вакцинация:</h4>
        <ul>
          <li><strong>Вакцина:</strong> {{ lastVaccine.name }}</li>
          <li><strong>Дата:</strong> {{ lastVaccine.date}} </li>
          <li><strong>Описание:</strong> {{ lastVaccine.description }}</li>
        </ul>
      </div>
      <div class="next-vaccination">
        <h4>Следующая вакцинация:</h4>
        <ul>
          <li><strong>Вакцина:</strong> {{ nextVaccine.name }}</li>
          <li><strong>Дата:</strong> {{ nextVaccine.date }} </li>
          <li><strong>Описание:</strong> {{ nextVaccine.description }}</li>
        </ul>
      </div>
    </div>
    <button type="button" class="menu-button">Посмотреть все вакцины</button>
    <button type="button" class="menu-button">Добавить информацию о вакцинации</button>
    <button type="button" class="menu-button" @click="goToAccount">Вернуться в профиль</button>
  </div>
</template>

<script>
import CommonMethods from '@/components/CommonMethods.js';

export default {
  name: 'App',
  data() {
    return {
      lastVaccine: {
        name: '',
        date: '',
        description: '',
        id: ''
      },
      nextVaccine: {
        name: '',
        date: '',
        description: '',
      },
      childId: this.$route.params.id,
    };
  },
  methods: {
    goToAccount() {
      this.$router.push('/account');
    },
    async loadLastVaccine() {
      try {
        console.log('childId in data:', this.childId);
        this.lastVaccine = await CommonMethods.getLastKidVaccineData(this.childId);
        console.log("Данные о последней вакцинации:", this.lastVaccine);

        this.nextVaccine = await CommonMethods.getNextKidVaccineData(this.childId);
        console.log("Данные о следующей вакцинации:", this.nextVaccine);

      } catch (error) {
        console.error('Ошибка загрузки данных о последней вакцинации:', error);
      }
    }
  },
  mounted() {
    this.loadLastVaccine();
  }
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
  background-color: #f7f9fc;
}

.kids-account-container {
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

header {
  text-align: center;
  margin-bottom: 20px;
}

.last-vaccination, .next-vaccination {
  margin-bottom: 20px;
  text-align: left;
}

ul {
  font-size: 16px;
  list-style-type: none;
  padding: 0;
}

h4 {
  color: #25396F;
  font-style: normal;
  font-size: 18px;
}

.vaccines {
  margin-left: 30px;
  max-width: 250px;
  text-align: center;
}

.menu-button {
  width: 250px;
  margin-left: 25px;
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

.menu-button:hover {
  background-color: #d3e4ff;
}
</style>