import request from "supertest";
const assert = require("assert");
import app from "./../app.js";

let subtest = [];

subtest[0] = [
  {
    id: 1,
    fullname: "Иванов И. И.",
    birthdate: "05.01.2003",
    groupName: "ИП-21",
    faculty: "ФАИС",
  },
  {
    id: 2,
    fullname: "Петров П. П.",
    birthdate: "07.10.2001",
    groupName: "ИТП-41",
    faculty: "ФАИС",
  },
  {
    id: 3,
    fullname: "Сидоров С. С.",
    birthdate: "23.05.2002",
    groupName: "УП-31",
    faculty: "ГЭФ",
  },
  {
    id: 4,
    fullname: "Козлов К. К.",
    birthdate: "17.08.2000",
    groupName: "ЭП-51",
    faculty: "ЭФ",
  },
];

subtest[1] = [
  {
    id: 1,
    fullname: "Иванов И. И.",
    birthdate: "05.01.2003",
    groupName: "ИП-21",
    faculty: "ФАИС",
  },
  {
    id: 3,
    fullname: "Сидоров С. С.",
    birthdate: "23.05.2002",
    groupName: "УП-31",
    faculty: "ГЭФ",
  },
  {
    id: 4,
    fullname: "Козлов К. К.",
    birthdate: "17.08.2000",
    groupName: "ЭП-51",
    faculty: "ЭФ",
  },
];

subtest[2] = [
  {
    maxAverageMark: 5.5
  }
];

subtest[3] = [200];




/*
describe("Testing API with SQL queries", () => {

  test("Вывод инф о студентах, обучавшихся на 4-ом семестре", () => {
    return request(app)
    .get('/students/semester4')
    .expect(subtest[1]);
})
})
*/
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
 
}) 

