import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

//Pages
import Login from './pages/Login'
import Cadastro from './pages/Cadastro'

const routing = (
  <Router>
    <div className='router'>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route path="/cadastro" component={Cadastro} />
        <Redirect to='/'/>
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
