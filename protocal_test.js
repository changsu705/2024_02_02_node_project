const express = require("express");
const app = express();

let users = [
    {id : 0 , data: "user 1 "}
];

app.use(express.json());

app.post('/userdata', (req, res) =>{

    const {id , data} = req.body;

    elt result = {
        cmd : -1,
        message : ''
    };

    let user = users.find(x=>x.id == id);

    if( user == undefined)
    {
        users.push({id,data});
        result.cmd = 1001;
        result.message = '유저 신규 등록.";
    }
    else
    {
        console.log(id, user.data);
        user.data = data;
        result.cmd = 1002;
        result.message = '데이터 갱신'
    }
    res.send(result);
})

app.get('/userdata/list',(req,res) =>{

    let result = users.sort(function (a,b) {
        return b.score - a.score;
    });

    result = result.slice(0, user.lenght);

    res.send({
        cmd : 1101,
        message:'',
        result
    })

})
app.listen(3000,function(){
    console.log("Example app listening on port 3000");
});