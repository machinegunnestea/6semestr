import express from "express";
import Controller from "./controllers.js";
//import Controller from "./controllersJSON.js"

const Controllers = new Controller();

const app = express();

app.use(express.json());

app.get("/students", async (req, res) => {
  const data = await Controllers.getStudents();
  res.send(data);
});

app.get("/students/semester4", async (req, res) => {
  const data = await Controllers.getStudentsSemester4();
  res.send(data);
});


app.get("/students/average", async (req, res) => {
  const data = await Controllers.getStudentsAverage();
  res.json(data);
});

app.post("/students", async (req, res) => {
  const studentdata = {
    id: 100,
    fullname: "Полотенце П. П.",
    birthdate: "01.01.1970",
    groupName: "ИП-00",
    faculty: "ФАИС",
  };
  const student = await Controllers.createStudent(studentdata);
  res.send(student);
});

app.put("/students/100", async (req, res) => {
    let student = await Controllers.editStudent(100, "МТФ");
    if (student) return res.sendStatus(200);
})

app.delete("/students/100", async (req, res) => {
  let deleted = await Controllers.deleteStudent(100);
  if (deleted) return res.sendStatus(200);
});

export default app;
