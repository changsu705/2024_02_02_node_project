const express = require('express');
const mysql = require('mysql2'); // 잘못된 모듈 이름 수정
const app = express();

app.use(express.json());

const pool = mysql.createPool({ // 'musql' 오타 수정
    host: 'localhost',
    user: 'root', // 'ShadowRoot'는 잘못된 사용자 이름일 가능성이 있음. 일반적으로 'root'를 사용하거나 실제 사용자 이름 사용.
    password: 'ckdtnckdtn1!',
    database: 'game_world' // 'datavase' 오타 수정
});

app.post('/login', async (req, res) => {
    const { username, password_hash } = req.body;

    try {
        const [players] = await pool.query( // pool에 .promise() 추가
            'SELECT * FROM players WHERE username = ? AND password_hash = ?',
            [username, password_hash]
        );

        if (players.length > 0) { // 'players.langth' 오타 수정
            await pool.query(
                'UPDATE players SET last_login = CURRENT_TIMESTAMP WHERE player_id = ?',
                [players[0].player_id]
            );
            res.json({ success: true, player: players[0] });
        } else {
            res.status(401).json({ success: false, message: '로그인 실패' });
        }
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

// 플레이어 인벤토리 조회
app.get('/inventory/:playerId', async (req, res) => {
    try {
        const [inventory] = await pool.query(
            'SELECT i.*, inv.quantity FROM inventories inv JOIN items i ON inv.item_id = i.item_id WHERE inv.player_id = ?',
            [req.params.playerId]
        );
        res.json(inventory);
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

app.get('/quests/:playerId', async (req, res) => { // 'plauerId' 오타 수정
    try {
        const [quests] = await pool.query(
            'SELECT q.*, pq.status FROM player_quests pq JOIN quests q ON pq.quest_id = q.quest_id WHERE pq.player_id = ?',
            [req.params.playerId]
        );
        res.json(quests);
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

app.post('/quests/status', async (req, res) => { // 경로 수정
    const { playerId, quest_id, status } = req.body;

    try {
        await pool.query(
            'UPDATE player_quests SET status = ?, complete_at = IF(? = "완료", CURRENT_TIMESTAMP, NULL) WHERE player_id = ? AND quest_id = ?',
            [status, status, playerId, quest_id]
        );
        res.json({ success: true });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

app.post('/inventory/add', async (req, res) => { // 경로 앞에 '/' 추가
    const { playerId, itemId, quantity } = req.body;

    try {
        const [existing] = await pool.query(
            'SELECT * FROM inventories WHERE player_id = ? AND item_id = ?',
            [playerId, itemId]
        );

        if (existing.length > 0) {
            await pool.query(
                'UPDATE inventories SET quantity = quantity + ? WHERE player_id = ? AND item_id = ?',
                [quantity, playerId, itemId]
            );
        } else {
            await pool.query(
                'INSERT INTO inventories (player_id, item_id, quantity) VALUES (?, ?, ?)', // 괄호 오류 수정
                [playerId, itemId, quantity]
            );
        }
        res.json({ success: true });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

const PORT = 3000;

app.listen(PORT, () => {
    console.log(`서버 실행 중: ${PORT}`);
});
