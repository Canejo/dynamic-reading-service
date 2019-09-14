const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
require('dotenv').config();

const app = express();

const server = require('http').Server(app);

server.setTimeout(500000);
app.use(cors());
app.use(bodyParser.json({
  limit: '50mb',
}));
app.use(bodyParser.urlencoded({
  limit: '50mb',
  extended: true,
}));

app.use(require('./routes'));

const serverPort = process.env.PORT || 3333;
server.listen(serverPort);