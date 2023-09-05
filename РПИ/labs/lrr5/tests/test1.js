const request = require(`supertest`);
const assert = require(`assert`);
const appSql = require(`../task1/app`).app;
const appORM = require(`../task2/app`).app;

// SQL tests
describe(`GET /api/movie`, () => {
    it(`Необходимо получить все Фильмы(SQL запрос)`, function (done) {
        request(appSql)
            .get(`/api/movie`)
            .expect(200)
            .expect(`Content-Type`, /json/)
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

const getById = 1
describe(`GET api/movie/id`, () => {
    it(`Необходимо получить один фильм c id ${getById}(SQL запрос)`, (done) => {
        request(appSql)
            .get(`/api/movie/${getById}`)
            .expect(200)
            .expect(`Content-Type`, /json/)
            .expect( function(response) {
                assert.deepStrictEqual(response.body, {
                    "Id": getById,
                    "Name": "Gercules",
                    "Price": "8",
                    "Description": "greek mythology",
                    "Genre": "cartoon"
                });
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

describe(`POST api/movie`, () => {
    it(`Необходимо добавить запись фильма(SQL)`, (done) => {
        request(appSql)
            .post(`/api/movie`)
            .send( {
                name: "test",
                price: "test",
                description: "test",
                genre: "test",
            })
            .expect(`Content-Type`, /json/)
            .expect(200)
            .expect( function(response) {
                assert.deepStrictEqual(response.body.addMovie, {
                    "name": "test",
                    "price": "test",
                    "description": "test",
                    "genre": "test"
                });
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

const deleteID = 36
describe(`DELETE api/movie/${deleteID}`, () => {
    it("Необходимо удалить фильм с id(SQL)", (done) => {
        request(appSql)
            .delete(`/api/movie/${deleteID}`)
            .expect(`Content-Type`, /json/)
            .expect(200)
            .expect( function(response) {
                assert.deepStrictEqual(response.body, {
                    "id": `${deleteID}`,
                    "deleted": 1
                });
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

const negDeleteID = 100000
describe(`DELETE api/movie/${negDeleteID}`, () => {
    it("Необходимо удалить фильм с несуществующим id(SQL)", (done) => {
        request(appSql)
            .delete(`/api/movie/${negDeleteID}`)
            .expect(`Content-Type`, /json/)
            .expect( function(response) {
                assert.deepStrictEqual(response.body.deleted, 0);
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

const updatedId = 4;
describe("PUT api/movie/", () => {
    it("Необходимо обновить информацию об одном фильме(SQL)", (done) => {
        request(appSql)
            .put(`/api/movie/`)
            .send({
                id: updatedId,
                name: "444",
                price: "444",
                description: "444",
                genre: "444"
            })
            .expect(200)
            .expect( function(response) {
                assert.deepStrictEqual(response.body.updatedMovie, {
                    id: updatedId,
                    name: "444",
                    price: "444",
                    description: "444",
                    genre: "444"
                });
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

//ORM tests
describe(`GET /api/movie`, () => {
    it(`Необходимо получить все фильмы(ORM)`, function (done) {
        request(appORM)
            .get(`/api/movie`)
            .expect(200)
            .expect(`Content-Type`, /json/)
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

describe("GET api/movie/:id", () => {
    it(`Необходимо получить один фильм c id 1(ORM)`, (done) => {
        request(appORM)
            .get(`/api/movie/1`)
            .expect(200)
            .expect(`Content-Type`, /json/)
            .expect( function(response) {
                assert.deepStrictEqual(response.body, {
                    "Id": 1,
                    "Name": "Gercules",
                    "Price": "8",
                    "Description": "greek mythology",
                    "Genre": "cartoon"
                });
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

const postId = 39;
describe(`POST api/movie`, () => {
    it(`Необходимо добавить запись фильма(ORM)`, (done) => {
        request(appORM)
            .post(`/api/movie`)
            .send( {
                name: "test",
                price: "test",
                description: "test",
                genre: "test",
            })
            .expect(`Content-Type`, /json/)
            .expect(200)
            .expect( function(response) {
                assert.deepStrictEqual(response.body, {
                    "Id": postId,
                    "Name": "test",
                    "Price": "test",
                    "Description": "test",
                    "Genre": "test"
                });
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

describe(`DELETE api/movie/${deleteID}`, () => {
    it("Необходимо удалить фильм с id(ORM)", (done) => {
        request(appORM)
            .delete(`/api/movie/${deleteID}`)
            .expect(`Content-Type`, /json/)
            .expect(200)
            .expect( function(response) {
                assert.deepStrictEqual(response.body, 1);
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

describe(`DELETE api/movie/${negDeleteID}`, () => {
    it("Необходимо удалить фильм с несуществующим id(ORM)", (done) => {
        request(appORM)
            .delete(`/api/movie/${negDeleteID}`)
            .expect(`Content-Type`, /json/)
            .expect( function(response) {
                assert.deepStrictEqual(response.body, 0);
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});

describe("PUT api/movie/", () => {
    it("Необходимо обновить информацию об одном фильму(ORM)", (done) => {
        request(appORM)
            .put(`/api/movie/`)
            .send({
                id: updatedId,
                name: "444",
                price: "444",
                description: "444",
                genre: "444"
            })
            .expect(200)
            .expect( function(response) {
                assert.deepStrictEqual(JSON.parse(response.body), 1);
            })
            .end((err, res) => {
                if (err) {
                    return done(err);
                }
                done();
            });
    });
});
