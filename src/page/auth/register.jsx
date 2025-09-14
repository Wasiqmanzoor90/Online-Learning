import axios from 'axios';
import { useState } from 'react';


function Register() {
    const[username, setUsername]=useState("");
    const[email, setEmail]=useState("");
    const[password, setPassword]=useState("");

    const handleRegister=async()=>
        {
            const data = {
                username,
                email,
                password

            }
            try {
                const res = await axios.post('http://localhost:5025/api/User/register', data)
                if(res)
                {
                    window.location('/')
                }

            } catch (error) {
                console.log(error);
            }
        }
  return (
    <div>
      <input type="text" placeholder='Enter username' onChange={(e)=>setUsername(e.target.value)} value={username} />
      <input type="text" placeholder='enter email' onChange={(e)=>setEmail(e.target.value)} value={email} />
      <input type="text" placeholder='Enter password' onChange={(e)=>setPassword(e.target.value)} value={password} />
      <button onClick={handleRegister}>submit</button>
      <p>Already account</p>
      <a href="/">Singn in</a>
    </div>
  )
}

export default Register
