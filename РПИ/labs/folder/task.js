import {Sequelize, DataTypes, QueryTypes} from "sequelize";
const sqlite3 = require("sqlite3");

const sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: './students.db'
});

const Student = sequelize.define('students', {
    fullname: DataTypes.STRING,
    birthdate: DataTypes.STRING,
    groupName: DataTypes.STRING,
    faculty: DataTypes.STRING
}, {
    timestamps: false
});

export default class {
    async getStudents() {
        return await Student.findAll({raw: true});
    }

    async getStudentId(id) {
        return await Student.findAll({where: {id}}, {raw: true})
    }

    async getStudentsSemester4() {
        return await sequelize.query('SELECT students.id, students.fullname, students.birthdate, students.groupName, students.faculty '+
        'FROM students, semesters, progress WHERE students.id = progress.studentID AND semesters.id = progress.semesterID '+
        'AND semesters.semesterNumber = 4', {
            type: QueryTypes.SELECT,
          },
          {raw: true})
    }
}