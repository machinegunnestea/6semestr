const http = require("http");
const fs = require("fs");

const hostname = "localhost";
const port = 3000;

const server = http.createServer((req, res) => {
  res.statusCode = 200;
  res.setHeader("Content-Type", "text/html");

  if (req.url == "/") {
    fs.createReadStream("extras/safety.html").pipe(res);
  } else if (req.url == "/info") {
    fs.createReadStream("extras/info.html").pipe(res);
  } else if (req.url == "/contacts") {
    fs.createReadStream("extras/contacts.html").pipe(res);
  }
});

server.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
});
