import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import './App.css';
import Home from './components/Home';
import Register from './components/Register';

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
        <Route path="/register" component={Register} >
            
        </Route>
        <Route path="/" component={Home} >

        </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
