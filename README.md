# Telegram-бот с веб-приложением на React Native Expo Web и C#-бэкендом

## Обзор проекта

Этот проект представляет собой комплексное решение, объединяющее Telegram-Bot Web App, созданным с использованием React Native Expo Web и ASP NET C#
В проекте используются различные архитектурные паттерны и технологии, чтобы обеспечить масштабируемую, поддерживаемую и эффективную систему.
Доступ по умолчанию 
 - localhost:6061 - GameService
 - locahost:6060 - UserService (Identity)
 - locahost:5050 - pgAdmin 
 * (подключение - любое название, далее название контейнера gameservice.db, название db - gamerservicedb, user - postgres, пароль - 123)
 * (в .env файле все атрибуты для подключения)

## Что использовалось
 - EF - ORM
 - CQRS - Command/Queries
 - Dapper - для преобразования sql в dto
 - Onion 
 -  microservices - не связаны, просто хотел авторизацию через Identity глянуть
 - repositories - для разделения бизнес логики и работы с данными (доработать)
 - Result pattern в Response, middlewaire лучше накинуть для глобального Try Catch
 - unitOfWork for transactions (но по сути там SaveChanges, т.к. он в транзакцию все операции оборачивает, если только для SQL использовать)
 - Допилить еще нужно PagedList, чтобы отдавать данные порционно

## Миграции
  Миграции базы данных обрабатываются автоматически. Система попытается применить ожидающие миграции при запуске приложения. См. скриншот ниже:
![image](https://github.com/user-attachments/assets/f8ce9a80-a3a8-4035-a104-2d6fc87657a1)

## всякие анимации еще игрался в react native web
![image](https://github.com/user-attachments/assets/b35237fb-3cd3-44a2-b211-c85e1bacd432)
![image](https://github.com/user-attachments/assets/0515b44c-e181-4b44-934b-3fde18cc09f2)

