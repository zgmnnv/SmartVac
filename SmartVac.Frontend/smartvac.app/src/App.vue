<script>
import Registration from './components/Registration.vue';
import Login from './components/Login.vue';

export default {
  name: "SmartVaccine",
  components: { Registration, Login }, // Регистрируем компоненты
  data() {
    return {
      showRegistration: false, // Управляет отображением компонента регистрации
      showLogin: false,        // Управляет отображением компонента авторизации
    };
  },
};
</script>

<template>
  <div class="smart-vaccine">
    <!-- Условное отображение волны -->
    <img v-if="!showRegistration && !showLogin" src="@/assets/img/wave.png" class="wave" alt="Wave Image" />

    <div class="content" v-if="!showRegistration && !showLogin">
      <a href="/" class="logo-link">
        <img src="@/assets/img/logo_new.svg" alt="Smart Vaccine Logo" class="logo" />
      </a>
      <p class="subtitle">
        Заботиться о здоровье ребенка стало проще и удобнее. <br />
        Пройдите регистрацию - мы напомним вам о следующей вакцинации
      </p>
      <button class="register-btn" @click="showRegistration = true">
        Пройти регистрацию
      </button>
      <a href="#" class="login-link" @click.prevent="showLogin = true">
        Войти
      </a>
    </div>

    <!-- Отображение компонентов регистрации и авторизации -->
    <Registration v-if="showRegistration" />
    <Login v-if="showLogin" />
  </div>
</template>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Lexend:wght@300;400;700&display=swap");

.smart-vaccine {
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  background-color: #ffffff;
  position: relative;
  padding: 16px;
  box-sizing: border-box;
  overflow: hidden;
}

.content {
  text-align: center;
  z-index: 2; /* Контент будет выше изображения волны */
  display: flex;
  flex-direction: column; /* Размещаем элементы по вертикали */
  align-items: center;    /* Центрируем элементы */
}

.logo {
  scale: 1.5; /* Масштабируем логотип */
  margin-bottom: 16px;
}

.subtitle {
  font-family: "Lexend", sans-serif;
  font-size: 24px; /* Базовый размер шрифта */
  font-weight: normal;
  color: #4c4c4c;
  margin-bottom: 36px;
}

.register-btn {
  background-color: #4A75B9;
  color: #fff;
  font-size: 16px; /* Базовый размер шрифта кнопки */
  padding: 12px 24px; /* Плюс внутренние отступы */
  border: none;
  border-radius: 8px;
  cursor: pointer;
  transition: background-color 0.3s;
  margin-top: 8px; /* Отступ сверху */
}

.register-btn:hover {
  background-color: #3a5f93; /* Цвет при наведении */
}

.login-link {
  display: inline-block;
  margin-top: 32px; /* Отступ под кнопкой регистрации */
  font-family: "Lexend", sans-serif;
  font-size: 16px; /* Размер шрифта ссылки */
  color: #4A75B9;
  text-decoration: none;
  cursor: pointer;
  transition: color 0.3s;
}

.login-link:hover {
  color: #3a5f93; /* Цвет при наведении */
}

.wave {
  position: absolute; /* Фиксируем позицию изображения */
  bottom: 0; /* Устанавливаем его внизу контейнера */
  left: 0; /* Устанавливаем его слева */
  right: 0; /* Устанавливаем его справа */
  z-index: 1; /* Устанавливаем z-index ниже, чтобы изображение было на заднем плане */
  width: 100%; /* Изображение занимает всю ширину */
}

/* Адаптивный дизайн */
@media (max-width: 1512px) {
  .logo {
    scale: 1.2; /* Уменьшаем масштаб логотипа при меньшей ширине экрана */
  }

  .subtitle {
    font-size: 28px; /* Увеличиваем размер для экранов менее 1512px */
  }

  .register-btn {
    font-size: 18px; /* Увеличиваем размер шрифта кнопки */
    padding: 14px 28px; /* Увеличиваем внутренние отступы кнопки */
  }

  .login-link {
    font-size: 18px; /* Увеличиваем размер шрифта ссылки */
    margin-top: 32px;
  }
}

@media (max-width: 768px) {
  .subtitle {
    white-space: nowrap;
    font-size: 16px;
    margin: 8px 16px 0;
  }

  .logo {
    scale: 0.7; /* Уменьшаем масштаб логотипа */
    margin-bottom: 0; /* Убираем нижний отступ */
  }

  .register-btn {
    margin-top: 16px;
    font-size: 16px; /* Размер для кнопки на мобильных устройствах */
    padding: 12px 24px; /* Уменьшаем отступы для компактного отображения */
  }

  .login-link {
    font-size: 16px; /* Размер шрифта для мобильных устройств */
    margin-top: 32px;
  }

  .wave {
    position: absolute;
    height: 80%;
    width: 150%;
  }
}

@media (min-width: 768px) {
  .subtitle {
    font-size: 32px; /* Увеличиваем размер для экранов от 768px */
  }

  .register-btn {
    font-size: 20px; /* Размер кнопки для больших экранов */
    padding: 16px 32px; /* Увеличиваем внутренние отступы кнопки */
  }

  .login-link {
    font-size: 18px; /* Размер шрифта ссылки */
    margin-top: 32px;
  }
}

@media (min-width: 1024px) {
  .logo {
    scale: 1.5;
  }

  .subtitle {
    font-size: 28px; /* Размер шрифта для очень больших экранов */
  }

  .register-btn {
    font-size: 18px; /* Размер кнопки для больших экранов */
    padding: 14px 80px; /* Увеличиваем отступы кнопки для больших экранов */
  }

  .login-link {
    font-size: 18px; /* Размер шрифта ссылки */
  }
}
</style>
