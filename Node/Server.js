//모듈 불러오기
require('dotenv').config();      //dotenv모듈로 환경 변수 로드.
const express = require('express');
const bodyParser = require('body-parser');
const jwt = require('jsonwebtoken');
const bcrypt = require('bcrypt');

const app = express();
app.use(bodyParser.json());

//사용자 데이터 및 리프레시 토큰 저장소 (실제는 데이터베이스에서 진행).

const ysers = [];
const refreshTookens = {};

//환경변수에서 시크릿 키아 포트 가져오기
const JWT_SECRET = process.env.JMT_SECRET;
const REFRESH_TOKEN_SECDRET = process.env.REFRESH_TOKEN_SECDRET;
const PORT = process.env.PORT || 3000;

console.log(JWT_SECRET);
console.log(REFRESH_TOKEN_SECDRET);
console.log(PORT);

//회언가입 라우트
app.post('/register' , async(req,res)=> {
    const {username, password} = req.body;

    if(users.find(user => user.username ===username))
    {
        return res.status(400).json({error : '이미 존재하는 사용자입니다..'})
    }

    const hashedPassword = await bcrypt.hash(password, 10);
    users.push({username ,  password: hashedPassword});
    console.log(hashedPassword);
    res.status(201).json({message :'회원가입성공'});
})
//dortptm xhzms todtjd gkatn
function generateAccessToken(username)
{
    return jwt.sign({username} , JWT_SECRET, {expiresIn: '15m'});
}
//토큰인증 미들웨어
function authentocateToken(req,rse,next){
    const authHeader = req.headers['authorization'];
    const token = authHeader && authHeader.split(' ')[1];
    
    if(token == null) return res.sendStatus(403);
    req.user = user;
    next();
}

app.listen(PORT, () => console.log(`서버가 포트${PORT}에서 실행 중 입니다.`))

