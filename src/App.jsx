import React from 'react'
import {BrowserRouter, Route, Routes} from 'react-router-dom'
import Login from './page/auth/login'
import Register from './page/auth/register'

function App() {
  return (
   <>
   <BrowserRouter>
   <Routes>
    <Route path='/' element={<Login/>}/>
    <Route path='/register' element={<Register/>}/>
   </Routes>
   </BrowserRouter>
   </>
  )
}

export default App
