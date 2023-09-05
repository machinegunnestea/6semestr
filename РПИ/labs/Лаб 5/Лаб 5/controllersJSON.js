import fs from "fs";

let readFile = fs.readFileSync("./source/subjects.json", "utf8");
let subjects = JSON.parse(readFile);

readFile = fs.readFileSync("./source/students.json", "utf8");
let students = JSON.parse(readFile);

readFile = fs.readFileSync("./source/progress.json", "utf8");
let progress = JSON.parse(readFile);

readFile = fs.readFileSync("./source/semesters.json", "utf8");
let semesters = JSON.parse(readFile);

export default class {
  async getStudents() {
    return await students;
  }

  async getStudentsSemester4() {
    const semesterID = 2;
    let studentID = [];

    for (let i in progress) {
      if (progress[i].semesterID == semesterID) {
        studentID.push(progress[i].studentID);
      }
    }

    let newStudentID = [];
    studentID.forEach((element) => {
      if (!newStudentID.includes(element)) {
        newStudentID.push(element);
      }
    });

    let data = [];

    for (let i in students) {
      for (let j in newStudentID) {
        if (students[i].id == newStudentID[j]) {
          data.push(students[i]);
        }
      }
    }

    return await data;
  }

  async getStudentsAverage() {
    let data = [];
    for (let i in progress) {
      for (let j in students) {
        if (progress[i].studentID == students[j].id) {
          data.push(Object.assign({}, progress[i], students[j]));
        }
      }
    }

    let resultO = data.reduce((acc, item) => {
      let tmp = item.faculty;
      if (!acc[tmp]) {
        acc[tmp] = [];
      }
      acc[tmp].push(item);
      return acc;
    }, {});

    let sum = 0;

    let averageArr = [];
    for (let i = 0; i < resultO["ФАИС"].length; i += 1) {
      sum += resultO["ФАИС"][i].mark;
    }
    averageArr.push(sum / resultO["ФАИС"].length);
    sum = 0;

    for (let i = 0; i < resultO["ЭФ"].length; i += 1) {
      sum += resultO["ЭФ"][i].mark;
    }
    averageArr.push(sum / resultO["ЭФ"].length);
    sum = 0;

    for (let i = 0; i < resultO["ГЭФ"].length; i += 1) {
      sum += resultO["ГЭФ"][i].mark;
    }
    averageArr.push(sum / resultO["ГЭФ"].length);
    sum = 0;

    let obj = [{ maxAverageMark: Math.max(...averageArr) }];
    return await obj;
  }

  async createStudent(student) {
    students.push(student);
    fs.writeFileSync('./source/students.json', JSON.stringify(students));

    return await [200];
  }

  async deleteStudent(id) {
    students = students.filter((n) => {return n.id != id});
    fs.writeFileSync('./source/students.json', JSON.stringify(students));

    return await [200];
  }

  async editStudent(id, faculty) {
    for (let i in students) { 
      if (students[i].id == id) {
        students[i].faculty = faculty;
      }
    }

    fs.writeFileSync('./source/students.json', JSON.stringify(students));
    return await [200];
  }
}
