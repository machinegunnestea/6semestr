import {Sequelize, DataTypes, QueryTypes} from "sequelize";

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
/*
const Semester = sequelize.define('semesters', {
    semesterNumber: DataTypes.INTEGER
}, {
    timestamps: false
});

const Subject = sequelize.define('subjects', {
    name: DataTypes.STRING,
    teacher: DataTypes.STRING,
}, {
    timestamps: false
});

const Progress = sequelize.define('progress', {
    studentID: DataTypes.INTEGER,
    semesterID: DataTypes.INTEGER,
    subjectID: DataTypes.INTEGER,
    mark: DataTypes.INTEGER
}, {
    timestamps: false
});
*/
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

    async getStudentsAverage() {
        return await sequelize.query('SELECT max(avgMark) AS maxAverageMark '+
        'FROM ( '+
          'SELECT students.faculty, avg(progress.mark) AS avgMark '+
          'FROM progress, students '+
          'WHERE students.id = progress.studentID '+
          'GROUP BY students.faculty)'
        , {type: QueryTypes.SELECT}, {raw: true});
    }

    async createStudent(student) {
        const {id, fullname, birthdate, groupName, faculty} = student;

        return await Student.create({
            id, fullname, birthdate, groupName, faculty
        }, {raw: true});
    }
    
    async deleteStudent(id) {
        return await Student.destroy({where: {id}}, {raw: true})
    }

    async editStudent(id, faculty) {
        return await Student.update({faculty}, {where: {id}});
    }
}