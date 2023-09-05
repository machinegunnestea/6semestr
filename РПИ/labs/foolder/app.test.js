/*const request = require('supertest');
const app = require('./app');

describe('GET /students', () => {
  it('should return all students', done => {
    request(app)
      .get('/students')
      .expect(200)
      .expect('Content-Type', /json/)
      .end((err, res) => {
        if (err) return done(err);
        expect(res.body).toBeInstanceOf(Array);
        expect(res.body[0]).toHaveProperty('id');
        expect(res.body[0]).toHaveProperty('fullname');
        expect(res.body[0]).toHaveProperty('birthdate');
        expect(res.body[0]).toHaveProperty('groupName');
        expect(res.body[0]).toHaveProperty('faculty');
        done();
      });
  });
});*/
const request = require('supertest');
const app = require('./app'); // assuming the Express app is defined in app.js

describe('GET /students', () => {
  test('responds with json containing a list of all students', async () => {
    const response = await request(app).get('/students');
    expect(response.status).toBe(200);
    expect(response.body.length).toBeGreaterThan(0);
  });
});

describe('GET /students/semester4', () => {
  test('responds with json containing a list of students in semester 4', async () => {
    const response = await request(app).get('/students/semester4');
    expect(response.status).toBe(200);
    expect(response.body.length).toBeGreaterThan(0);
  });
});

describe('GET /students/average', () => {
  test('responds with json containing the faculty with the highest average mark', async () => {
    const response = await request(app).get('/students/average');
    expect(response.status).toBe(200);
    expect(response.body).toHaveProperty('faculty');
    expect(response.body).toHaveProperty('average_mark');
  });
});

describe('POST /students', () => {
  test('adds a new student and responds with json containing the new student data', async () => {
    const newStudent = {
      fullname: 'John Doe',
      birthdate: '1998-05-20',
      groupName: 'Group1',
      faculty: 'IT',
    };
    const response = await request(app).post('/students').send(newStudent);
    expect(response.status).toBe(200);
    expect(response.body).toHaveProperty('id');
    expect(response.body.fullname).toBe(newStudent.fullname);
    expect(response.body.birthdate).toBe(newStudent.birthdate);
    expect(response.body.groupName).toBe(newStudent.groupName);
    expect(response.body.faculty).toBe(newStudent.faculty);
  });
});

describe('PUT /students/:id', () => {
  test('updates the faculty of a student and responds with status 204', async () => {
    const studentId = 1; // assuming there is a student with id 1 in the database
    const updatedStudent = {
      faculty: 'Business',
    };
    const response = await request(app).put(`/students/${studentId}`).send(updatedStudent);
    expect(response.status).toBe(204);
  });
});

describe('DELETE /students/:id', () => {
  test('deletes a student and responds with status 204', async () => {
    const studentId = 1; // assuming there is a student with id 1 in the database
    const response = await request(app).delete(`/students/${studentId}`);
    expect(response.status).toBe(204);
  });
});