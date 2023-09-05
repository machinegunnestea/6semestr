const request = require("supertest");
const assert = require("assert");
const app = require("../task1/app").app;

const movie3 ={
    movie:{
        id:3,
        name: "Gercules",
        price: 8,
        description: "greek mythology",
        genre: "cartoon"
    }
};
const movie3_upd ={
    movie:{
        id:3,
        name: "Cars",
        price: 8,
        description: "about race",
        genre: "cartoon"
    }
};

describe("Testing API with SQL queries", () => {
    describe("GET /movie", () => {
        it("Should return 200 \"OK\" with JSON", (done) => {
          request(app)
            .get("/movie")
            .expect("Content-Type", /json/)
            .expect(200)
            .end(done);
        });
    });

    describe("GET /movie?id=3 NON-EXISTENT", () => {
        it("Should return 404 \"Not Found\" with Text", (done) => {
            request(app)
              .get("/movie")
              .query({id: 0})
              .expect("Content-Type", /text/)
              .expect(404)
              .end(done);
          });
    });

    describe("POST /movie with id=3 NON-EXISTENT", () => {
        it("Should return 200 \"OK\" with Text", (done) => {
          request(app)
            .post("/movie")
            .send(movie3)
            .expect("Content-Type", /text/)
            .expect(200)
            .end(done);
        });
    });

    describe("GET /movie?id=3 ADDED", () => {
        it("Should return 200 \"OK\" with expected JSON", (done) => {
          request(app)
            .get("/movie")
            .query({id: 3})
            .expect("Content-Type", /json/)
            .expect(200)
            .expect((response) => {
                assert.deepStrictEqual(response.body, educator3);
            })
            .end(done);
        });
    });

    describe("POST /movie with id=3 EXISTENT", () => {
        it("Should return 400 \"Bad Request\" with Text", (done) => {
          request(app)
            .post("/movie")
            .send(movie3)
            .expect("Content-Type", /text/)
            .expect(400)
            .end(done);
        });
    });

    describe("PUT /movie with id=3 EXISTENT", () => {
        it("Should return 200 \"OK\" with Text", (done) => {
          request(app)
            .put("/movie")
            .send(movie3_upd)
            .expect("Content-Type", /text/)
            .expect(200)
            .end(done);
        });
    });

    describe("GET /movie?id=3 UPDATED", () => {
        it("Should return 200 \"OK\" with expected JSON", (done) => {
          request(app)
            .get("/movie")
            .query({id: 3})
            .expect("Content-Type", /json/)
            .expect(200)
            .expect((response) => {
                assert.deepStrictEqual(response.body, educator3_upd);
            })
            .end(done);
        });
    });

    describe("DELETE /educators with id=3 EXISTENT", () => {
        it("Should return 200 \"OK\" with Text", (done) => {
          request(app)
            .delete("/movie")
            .query({id: 3})
            .expect("Content-Type", /text/)
            .expect(200)
            .end(done);
        });
    });

    describe("GET /movie?id=3 DELETED", () => {
        it("Should return 404 \"Not Found\" with Text", (done) => {
            request(app)
              .get("/movie")
              .query({id: 0})
              .expect("Content-Type", /text/)
              .expect(404)
              .end(done);
          });
    });

    describe("PUT /movie with id=3 DELETED", () => {
        it("Should return 404 \"Not Found\" with Text", (done) => {
          request(app)
            .put("/movie")
            .send(movie3_upd)
            .expect("Content-Type", /text/)
            .expect(404)
            .end(done);
        });
    });

    describe("DELETE /movie with id=3 DELETED", () => {
        it("Should return 404 \"Not Found\" with Text", (done) => {
          request(app)
            .delete("/movie")
            .query({id: 3})
            .expect("Content-Type", /text/)
            .expect(404)
            .end(done);
        });
    });
});

