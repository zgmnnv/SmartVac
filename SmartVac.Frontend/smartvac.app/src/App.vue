<script>
export default {
  name: "SmartVaccine",
};
</script>

<template>
  <div class="smart-vaccine">
    <img src="@/assets/img/wave.png" class="wave" alt="Wave Image" />
    <div class="content">
      <a href="/" class="logo-link">
        <img src="@/assets/img/logo_new.svg" alt="Smart Vaccine Logo" class="logo" />
      </a>
      <p class="subtitle">
        Заботиться о здоровье ребенка стало проще. <br />
        Мы напомним вам о следующей вакцинации
      </p>
      <button class="register-btn">Пройти регистрацию</button>
    </div>
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
}

.register-btn:hover {
  background-color: #4A75B9;
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
}

@media (min-width: 1024px) {

  .logo {
    scale: 1.5;
  }
  .subtitle {
    font-size: 28px; /* Размер шрифта для очень больших экранов */
  }

  .register-btn {
    font-size: 24px; /* Размер кнопки для больших экранов */
    padding: 28px 112px; /* Увеличиваем отступы кнопки для больших экранов */
  }
}
</style>
