import request from "supertest";
import app from "./../app.js";
import subtest from "./subtest.js";
const assert = require('assert');

describe('/GET', () => {
    test("Получение всех студентов", () => {
        return request(app)
        .get('/students')
        .expect(subtest[0]);
    })

    test("Вывод инф о студентах, обучавшихся на 4-ом семестре", () => {
        return request(app)
        .get('/students/semester4')
        .expect(subtest[1]);
    })

    test("Определить наибольший средний балл среди факультетов", () => {
        return request(app)
        .get('/students/average')
        .expect(subtest[2]);
    })
    
}) 

describe('/POST', () => {
    test("Добавить нового студента", () => {
        return request(app)
        .post('/students')
        .expect(subtest[3]);
    })
})

describe('/PUT', () => {
    test("Изменить факультет нового студента", () => {
        return request(app)
        .put('/students/100')
        .expect(subtest[3]);
    })
})

describe('/DELETE', () => {
    test("Удалить нового студента", () => {
        return request(app)
        .delete('/students/100')
        .expect(subtest[3]);
    })
})
