const express = requier('express');
const fs = require('fs');
const router = express.Router();

const initalResources = {
    metal : 500,
    crystal : 300,
    deuterirum : 100,
}


global.players = {};

module.exporets = router;