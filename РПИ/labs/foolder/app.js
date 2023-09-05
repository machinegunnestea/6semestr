const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');

const app = express();
const port = 3000;
const db = new sqlite3.Database('./Students.db');

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

// GET /students
app.get('/students', (req, res) => {
  db.all('SELECT * FROM students', (err, students) => {
    if (err) {
      console.error(err);
      res.status(500).send('Internal server error');
    } else {
      res.json(students);
    }
  });
});

// GET /students/semester4
app.get('/students/semester4', (req, res) => {
  db.all('SELECT * FROM students WHERE id IN (SELECT studentID FROM progress WHERE semesterID = 4)', (err, students) => {
    if (err) {
      console.error(err);
      res.status(500).send('Internal server error');
    } else {
      res.json(students);
    }
  });
});

// GET /students/average
app.get('/students/average', (req, res) => {
  db.all('SELECT faculty, AVG(mark) AS average_mark FROM students JOIN progress ON students.id = progress.studentID GROUP BY faculty ORDER BY average_mark DESC LIMIT 1', (err, result) => {
    if (err) {
      console.error(err);
      res.status(500).send('Internal server error');
    } else {
      res.json(result[0]);
    }
  });
});

// POST /students
app.post('/students', (req, res) => {
  const { fullname, birthdate, groupName, faculty } = req.body;
  db.run('INSERT INTO students (fullname, birthdate, groupName, faculty) VALUES (?, ?, ?, ?)', [fullname, birthdate, groupName, faculty], function(err) {
    if (err) {
      console.error(err);
      res.status(500).send('Internal server error');
    } else {
      const studentID = this.lastID;
      res.json({ id: studentID, fullname, birthdate, groupName, faculty });
    }
  });
});

// PUT /students/100
app.put('/students/:id', (req, res) => {
  const { id } = req.params;
  const { faculty } = req.body;
  db.run('UPDATE students SET faculty = ? WHERE id = ?', [faculty, id], err => {
    if (err) {
      console.error(err);
      res.status(500).send('Internal server error');
    } else {
      res.sendStatus(204);
    }
  });
});

// DELETE /students/100
app.delete('/students/:id', (req, res) => {
  const { id } = req.params;
  db.run('DELETE FROM students WHERE id = ?', id, err => {
    if (err) {
      console.error(err);
      res.status(500).send('Internal server error');
    } else {
      res.sendStatus(204);
    }
  });
});

// Start the server
let server = app.listen(port, () => {
  console.log(`Server is listening on port ${port}`);
});
module.exports = server