// server.test.js

const request = require('supertest');
const app = require('../server');

describe('Test API', () => {
  it('Получение всех студентов', async () => {
    const res = await request(app).get('/students');
    expect(res.statusCode).toEqual(200);
    expect(res.body).toBeInstanceOf(Array);
    expect(res.body[0]).toHaveProperty('id');
    expect(res.body[0]).toHaveProperty('fullname');
    expect(res.body[0]).toHaveProperty('birthdate');
    expect(res.body[0]).toHaveProperty('groupName');
    expect(res.body[0]).toHaveProperty('faculty');
  });

  it('Получение студентов, обучавшихся на четвёртом семестре', async () => {
    const res = await request(app).get('/students/semester4');
    expect(res.statusCode).toEqual(200);
    expect(res.body).toBeInstanceOf(Array);
    expect(res.body[0]).toHaveProperty('id');
    expect(res.body[0]).toHaveProperty('fullname');
    expect(res.body[0]).toHaveProperty('birthdate');
    expect(res.body[0]).toHaveProperty('groupName');
    expect(res.body[0]).toHaveProperty('faculty');
  });

  it('Определение наибольшего среднего балла среди факультетов', async () => {
    const res = await request(app).get('/students/average');
    expect(res.statusCode).toEqual(200);
    expect(res.body).toBeInstanceOf(Array);
    expect(res.body[0]).toHaveProperty('faculty');
    expect(res.body[0]).toHaveProperty('average');
  });

  it('Добавление студента', async () => {
    const res = await request(app)
      .post('/students')
      .send({ fullname: 'Иванов Иван Иванович', birthdate: '1998-05-15', groupName: 'ИС-101', faculty: 'ФАИС' });
    expect(res.statusCode).toEqual(200);
  });

  it('Изменение факультета у студента', async () => {
    const res = await request(app).put('/students/1');
    expect(res.statusCode).toEqual(200);
  });

  it('Удаление студента', async () => {
    const res = await request(app).delete('/students/1');
    expect(res.statusCode).toEqual(200);
  });
});