FROM node:lts-alpine as builder
WORKDIR /app
COPY . .

RUN npm install && \
    npm run build

FROM node:lts-alpine
COPY --from=builder /app/dist /app/dist
RUN npm install -g serve

EXPOSE 5173

CMD ["serve", "/app/dist"]