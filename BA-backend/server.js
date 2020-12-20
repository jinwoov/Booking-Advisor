'use strict';

const express = require("express");
const app = express();
const PORT = 8080;
const cors = require("cors");
require('dotenv').config();
const twk = process.env.TWK;
const user = process.env.USERNAMES;
const pwd = process.env.PASSWORD;

app.use(cors());
app.use(express.json());
app.use(express.urlencoded({extended:true}));

app.post("/jwt", (req, res) => {
    try {
        const obj = {
            "username": user,
            "jwt": twk
        }
        let { username, password } = req.headers;
        if (username === user && password === pwd) {
            res.json(obj);
        }
        else{
            throw Error("Unauthorized access");
        }
    } catch {
        res.status(403).send();
    }
});

app.listen(PORT, () => {
    console.log(`Listening at ${PORT}`);
});