const express = require("express");
const exp = express();
const fs = require("fs");

const hostname = "localhost";
const port = 3000;

function logging(data) {
  fs.writeFile("server.log", data + "\n", { flag: "a" }, (err) => {
    if (err) console.log(err);
  });
}

exp.use(function (req, res, next) {
  let now = new Date();
  let data = `${now} ${req.url} ${req.method} ${req.get("user-agent")}`;
  logging(data);
  next();
});

exp.get("/", (req, res) => {
  res.sendFile(__dirname + "/extras/safety.html");
});

exp.get("/info", (req, res) => {
  res.sendFile(__dirname + "/extras/info.html");
});

exp.get("/contacts", (req, res) => {
  res.sendFile(__dirname + "/extras/contacts.html");
});

exp.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
});
