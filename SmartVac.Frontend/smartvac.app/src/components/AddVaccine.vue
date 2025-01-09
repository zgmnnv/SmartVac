<template>
  <div class="container">
    <h2>Добавить информацию о вакцинации</h2>
    <div v-for="(vaccine, index) in vaccines" :key="index">
      <div class="vaccine-form">
        <label for="vaccine-select">Выберите вакцину:</label>
        <select v-model="vaccine.vaccineId" required>
          <option disabled value="">Выберите вакцину</option>
          <option v-for="vac in availableVaccines" :value="vac.id" :key="vac.id">
            {{ vac.name }}
          </option>
        </select>

        <label for="date">Дата:</label>
        <input type="date" v-model="vaccine.date" required />

        <label for="comment">Комментарий:</label>
        <textarea v-model="vaccine.description"></textarea>
      </div>
    </div>
    <button type="button" @click="addNewVaccine">Добавить еще вакцину</button>
    <button type="submit" @click="submitForms">Сохранить</button>
    <button type="submit" @click="resetForms">Сбросить</button>
    <button type="submit" @click="goToKidsAccount">Назад</button>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'AccVaccine',
  data() {
    return {
      vaccines: [],
      availableVaccines: [], // Список доступных вакцин для выбора
      isLoading: false,
    };
  },
  async created() {
    this.isLoading = true;
    try {
      const res = await axios.get(
          'http://localhost:5052/api/Vaccine/GetAllVaccines'
      );
      console.log(res.data);

      this.availableVaccines = res.data;
      console.log('Доступные вакцины:', this.availableVaccines);

      // Создаем начальную структуру для первой записи
      this.addNewVaccine();
    } catch (err) {
      console.error(err.message);
    } finally {
      this.isLoading = false;
    }
  },
  methods: {
    goToKidsAccount() {
      this.$router.push(`/kids_account/${this.$route.params.id}`);
    },
    resetForms() {
      location.reload(); // Обновление текущей страницы
    },
    addNewVaccine() {
      this.vaccines.push({
        vaccineId: '', // Выбранная вакцина
        date: '',
        description: ''
      });
    },
    async submitForms() {
      for (const vaccine of this.vaccines) {
        const data = {
          date: vaccine.date,
          vaccineId: vaccine.vaccineId,
          childId: parseInt(this.$route.params.id),
          description: vaccine.description
        };
        await axios.post('http://localhost:5052/api/Manipulation/AddManipulation', data);
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
  background-color: #f7f9fc;
}

.container {
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

h2 {
  text-align: center;
  margin-bottom: 20px;
}

.vaccine-form {
  margin-bottom: 20px;
  text-align: left;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

select, input[type=date], textarea {
  width: 200px;
  padding: 12px;
  border: 1px solid #ced4da;
  border-radius: 10px;
  margin-bottom: 15px;
}

button {
  width: 250px;
  padding: 12px;
  background-color: #FFFFFF;
  color: #25396F;
  border: none;
  border-radius: 4px;
  font-size: 18px;
  cursor: pointer;
  transition: background-color 0.3s;
  margin-right: 10px;
  margin-bottom: 10px;
}

button:hover {
  background-color: #d3e4ff;
}
</style>