const express = require("express");
const fs = require("fs");

const exp = express();
const jsonParser = express.json();

const filePath = "cinemas.json";
const hostname = "localhost";
const port = 3000;

exp.get("/cinemas", function (req, res) {
  const data = fs.readFileSync(filePath, "utf8");
  const cinemas = JSON.parse(data);
  res.send(cinemas);
});

exp.put("/cinemas/:id", jsonParser, function (req, res) {
  const cinemaID = req.params.id;
  const cinemaName = "New";
  const cinemaLocation = "Могилев";
  const cinemaCost = "7р";

  let cinemas = JSON.parse(fs.readFileSync(filePath, "utf8"));

  let cinema = cinemas.find((el) => el.id == cinemaID);

  if (cinema) {
    cinema.name = cinemaName;
    cinema.location = cinemaLocation;
    cinema.cost = cinemaCost;

    fs.writeFileSync(filePath, JSON.stringify(cinemas, null, 2), "utf-8");
    res.send(cinema);
  } else {
    res.status(404).send();
  }
});

exp.post("/cinemas", jsonParser, function (req, res) {
  const cinemaName = "Красный октябрь";
  const cinemaLocation = "Минск";
  const cinemaCost = "10р";

  let cinema = {
    name: cinemaName,
    location: cinemaLocation,
    cost: cinemaCost,
  };

  let cinemas = JSON.parse(fs.readFileSync(filePath, "utf8"));
  const id = Math.max(
    ...cinemas.map(function (cin) {
      return cin.id;
    })
  );

  cinema.id = id + 1;
  cinemas.push(cinema);

  fs.writeFileSync(filePath, JSON.stringify(cinemas, null, 2), "utf-8");
  res.send(cinema);
});

exp.delete("/cinemas/:id", function (req, res) {
  const id = req.params.id;
  let cinemas = JSON.parse(fs.readFileSync(filePath, "utf8"));

  let index = cinemas.find((el) => el.id == id).id;

  if (index > -1) {
    const cinema = cinemas.splice(index, 1)[0];
    fs.writeFileSync(filePath, JSON.stringify(cinemas, null, 2), "utf-8");
    res.send(cinema);
  } else {
    res.status(404).send();
  }
});

exp.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
});
