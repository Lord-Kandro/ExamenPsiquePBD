

const cors = require('cors')
const app= express()
app.use(cors());


fetch('http://localhost:60909/api/user')
.then(response => response.json())
.then(data =>{
    debugger
})
