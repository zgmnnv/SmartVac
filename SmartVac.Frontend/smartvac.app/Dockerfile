# Используем Node.js образ для сборки Vue.js проекта
FROM node:lts-alpine as builder

# Указываем рабочую директорию
WORKDIR /app

# Копируем файлы проекта в контейнер
COPY . .

# Устанавливаем зависимости и собираем приложение
RUN npm install && \
    npm run build

# Финальная стадия: используем Nginx для обслуживания статических файлов
FROM nginx:alpine

# Копируем собранные файлы из предыдущей стадии
COPY --from=builder /app/dist /usr/share/nginx/html

# Открываем порт 5173 для доступа к приложению
EXPOSE 5173

# Запускаем Nginx
CMD ["nginx", "-g", "daemon off;"]