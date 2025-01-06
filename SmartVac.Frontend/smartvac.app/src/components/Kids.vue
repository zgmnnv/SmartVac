<template>
  <div class="kids-container">
    <ul class="list-of-kids">
      <li v-for="child in kidsList">
        <button class="kid-name">
          {{ child.name }}
        </button>
      </li>
    </ul>
  </div>
</template>

<script>
import CommonMethods from '@/components/CommonMethods.js';

export default {
  data() {
    return {
      kidsList: []
    };
  },

  mounted() {
    this.fetchKids();
  },

  methods: {
    async fetchKids() {
      try {

        const userEmail = CommonMethods.getUserEmailFromLocalStorage();
        const userData = await CommonMethods.getUserDataByEmail(userEmail)
        const userList = await CommonMethods.getKidsListByUserId(userData.id)

        if (userList.status == 200) {
          this.kidsList = userList.data();
        } else {
          console.error('Ошибка при получении списка детей');
        }
      } catch (err) {
        console.error(err);
      }
    }
  }
};
</script>


<style scoped>
.list-of-kids {
  list-style-type: ul;
  margin-left: 20px;
}
.kid-name {
  text-align: center;
  padding: 10px;
  font-weight: bold;
  cursor: pointer;
}
.kids-container {
  display: flex;
  justify-content: center;
  align-items: stretch;
}
</style>/