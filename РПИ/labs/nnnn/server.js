// server.js

const express = require('express');
const mysql = require('mysql');
const bodyParser = require('body-parser');

const app = express();
const port = 3000;

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

const connection = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: 'password',
  database: 'Students'
});

connection.connect((err) => {
  if (err) {
    console.log('Ошибка подключения к базе данных: ' + err.stack);
    return;
  }
  console.log('Подключение к базе данных успешно установлено');
});

app.listen(port, () => {
  console.log(`Сервер запущен на порту ${port}`);
});


// создание таблиц
connection.query(
    'CREATE TABLE IF NOT EXISTS students (id INT AUTO_INCREMENT PRIMARY KEY, fullname VARCHAR(255), birthdate DATE, groupName VARCHAR(255), faculty VARCHAR(255))',
    (err, result) => {
      if (err) throw err;
      console.log('Таблица "students" создана');
    }
  );
  
  connection.query(
    'CREATE TABLE IF NOT EXISTS semesters (id INT AUTO_INCREMENT PRIMARY KEY, semesterNumber INT)',
    (err, result) => {
      if (err) throw err;
      console.log('Таблица "semesters" создана');
    }
  );
  
  connection.query(
    'CREATE TABLE IF NOT EXISTS subjects (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), teacher VARCHAR(255))',
    (err, result) => {
      if (err) throw err;
      console.log('Таблица "subjects" создана');
    }
  );
  
  connection.query(
    'CREATE TABLE IF NOT EXISTS progress (id INT AUTO_INCREMENT PRIMARY KEY, studentID INT, semesterID INT, subjectID INT, mark INT)',
    (err, result) => {
      if (err) throw err;
      console.log('Таблица "progress" создана');
    }
  );


// Получение всех студентов
app.get('/students', (req, res) => {
    connection.query('SELECT * FROM students', (err, result) => {
      if (err) throw err;
      res.send(result);
    });
  });
  
  // Получение студентов, обучавшихся на четвёртом семестре
  app.get('/students/semester4', (req, res) => {
    connection.query(`SELECT * FROM students s INNER JOIN progress p ON s.id=p.studentID INNER JOIN semesters sem ON p.semesterID=sem.id WHERE sem.semesterNumber=4`, (err, result) => {
      if (err) throw err;
      res.send(result);
    });
  });
  
  // Определение наибольшего среднего балла среди факультетов
  app.get('/students/average', (req, res) => {
    connection.query(`SELECT faculty, AVG(mark) as average FROM students s INNER JOIN progress p ON s.id=p.studentID GROUP BY faculty ORDER BY average DESC LIMIT 1`, (err, result) => {
      if (err) throw err;
      res.send(result);
    });
  });
  
  // Добавление студента
  app.post('/students', (req, res) => {
    const { fullname, birthdate, groupName, faculty } = req.body;
    connection.query(`INSERT INTO students (fullname, birthdate, groupName, faculty) VALUES ('${fullname}', '${birthdate}', '${groupName}', '${faculty}')`, (err, result) => {
      if (err) throw err;
      res.send(`Студент ${fullname} успешно добавлен`);
    });
  });
  
  // Изменение факультета у студента
  app.put('/students/:id', (req, res) => {
    const id = req.params.id;
    connection.query(`UPDATE students SET faculty='МТФ' WHERE id=${id}`, (err, result) => {
      if (err) throw err;
      res.send(`Изменения для студента с ID ${id} сохранены`);
    });
  });
  
  // Удаление студента
  app.delete('/students/:id', (req, res) => {
    const id = req.params.id;
    connection.query(`DELETE FROM students WHERE id=${id}`, (err, result) => {
      if (err) throw err;
      res.send(`Студент с ID ${id} успешно удалён`);
    });
  });

  