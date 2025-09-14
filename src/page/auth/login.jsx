import axios from 'axios'
import React, { useState } from 'react'

function Login() {
const[email, setEmail]=useState("");
const[password, setPassword]=useState("");
const handleLogin=async()=>
  {
    const data ={
      email,
      password
    }
    try {
      const res = await axios.post("http://localhost:5025/api/User/login", data)
      if(res)
      {
        window.location.href="/"
        localStorage.setItem("token", res.data.token);
        localStorage.setItem("Role", res.data.role);
      }

    } catch (error) {
      console.log(error);
    }
  }

  return (
    <div>
      <input type="text" placeholder='Enter username' onChange={(e)=> setEmail(e.target.value)}  value={email}/>
      <input type="text" placeholder='Enter username' onChange={(e)=> setPassword(e.target.value)} value={password}/>
      <button onClick={handleLogin}>submit</button>
      <p>Don't have an account?</p>
      <a href="/register">sign up</a>
    </div>
  )
}

export default Login
