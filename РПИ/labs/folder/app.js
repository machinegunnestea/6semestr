import express from "express";
import {Sequelize, DataTypes, QueryTypes} from "sequelize";
import Task from "./task.js";

const Tasks = new Task();

const app = express();
app.use(express.json());

app.get("/students", async (request,response) => {
    const data = await Tasks.getStudents();
    response.send(data);
  });

app.get("students/semester4", async (request,response) => {
    const data = await Tasks.getStudentsSemester4();
    response.send(data);
});

export default app;

app.listen(3000, () => console.log("Server is listening on port 3000"));