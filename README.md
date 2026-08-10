# Car News — новостной портал на ASP.NET

Веб-приложение для публикации и чтения статей об автомобилях: список с постраничной
подгрузкой, фильтрация по тегам, добавление статей через форму. Данные лежат в PostgreSQL,
доступ к ним — через собственный слой репозиториев поверх Dapper.

**Стек:** C# · ASP.NET Core MVC · PostgreSQL · Npgsql · Dapper · FluentMigrator

## Чем интересен слой данных

Основная работа здесь не в контроллерах, а в том, как приложение разговаривает с Postgres.

**Композитные типы и `UNNEST`.** Сущности зарегистрированы как композитные типы Postgres
(`Postgres.MapCompositeTypes`), что позволяет отправлять целую пачку записей одним
параметром через `UNNEST` вместо построчных `INSERT` в цикле — один round-trip вместо N.

**Трансляция имён.** Подключён `NpgsqlSnakeCaseNameTranslator` вместе с
`Dapper.DefaultTypeMap.MatchNamesWithUnderscores`, поэтому `PublisherId` в C# и
`publisher_id` в базе сопоставляются автоматически, без атрибутов над каждым полем.

**Миграции.** Схема версионируется через FluentMigrator и применяется на старте
приложения — база собирается с нуля одной командой, без ручных SQL-скриптов.

## Структура

```text
WebApplication1/
├── Context/         CarNewsDBContext — точка доступа к данным
├── Repositories/    ArticleRepository + интерфейс, инъекция через DI
├── Entities/        Article, Tags — модель хранения
├── DTO/             ArticleDTO, TagDTO — контракт формы
├── Models/          ViewModel для представлений
├── Controllers/     Home, Articles, Tags
├── Views/           Razor-страницы
├── Postgres.cs      маппинг композитных типов, регистрация транслятора имён
└── Program.cs       конфигурация DI, миграций, маршрутов
```

## Запуск

Нужны .NET SDK и PostgreSQL.

```bash
createdb car_news
dotnet run --project WebApplication1
```

Строка подключения задаётся в `appsettings.json` в секции `DalOptions`. Для локального
запуска подставьте свои учётные данные — в репозитории значений нет.
