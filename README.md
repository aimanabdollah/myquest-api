# MyQuest API

This repository contains the backend code for the MyQuest application, which is built using ASP.NET Core Web API 6.0. The MyQuest application is a quiz platform that allows users to test their knowledge of Malaysia's culture, history and facts at <a href="https://myquest-khaki.vercel.app/welcome">here.

## API Endpoints
The MyQuest API provides the following endpoints:

### MyQuest

| Endpoint                | Description                                                  |
|-------------------------|--------------------------------------------------------------|
| GET /api/MyQuest        | Retrieves all questions with their associated options.       |
| GET /api/MyQuest/{id}   | Retrieves a specific question with its associated options.   |
| POST /api/MyQuest       | Creates a new question ith its associated options.           |

### Questions

| Endpoint                         | Description                                           |
|----------------------------------|-------------------------------------------------------|
| GET /api/Questions               | Retrieves a list of all questions.                    |
| GET /api/Questions/{id}          | Retrieves a specific question based on the ID.        |
| GET /api/Questions/{id}/Options  | Retrieves all options for a specific question.        |
| POST /api/Questions              | Creates a new question.                               |
| PUT /api/Questions/{id}          | Updates an existing question with the provided ID.    |
| DELETE /api/Questions/{id}       | Deletes a question with the provided ID.              |

### Options

| Endpoint                     | Description                                         |
|------------------------------|-----------------------------------------------------|
| GET /api/Options             | Retrieves a list of all options.                    |
| GET /api/Options/{id}        | Retrieves a specific option based on the ID.        |
| POST /api/Options/{id}       | Creates a new option for a specific question.       |
| PUT /api/Options/{id}        | Updates an existing option with the provided ID.    |
| DELETE /api/Options/{id}     | Deletes an option with the provided ID.             |


## Entity Attribute Description
This section provides an overview of the attributes for the `Question` and `Option` entities in the database. The tables below outline the attributes, data types, nullability and descriptions for each entity.

### Question Table

Attribute | Type    | Nullable | Description
--------- | ------- | -------- | -----------
id        | integer | No       | Unique identifier for the question
image     | string  | Yes      | Image associated with the question
questionText | string | Yes   | The text of the question

### Option Table

Attribute   | Type    | Nullable | Description
----------- | ------- | -------- | -----------
id          | integer | No       | Unique identifier for the option
questionId  | integer | No       | Identifier of the question the option belongs to
image       | string  | Yes      | Image associated with the option
text        | string  | Yes      | The text of the option
correct     | boolean | No       | Indicates if the option is correct or not
