const express = require('express');

const ArticleController = require('./controllers/ArticleController');
const AuthController = require('./controllers/AuthController');

const routes = new express.Router();

routes.get('/article/get', ArticleController.get);

routes.get('/auth/pocket', AuthController.pocket);

module.exports = routes;