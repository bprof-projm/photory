import React from 'react';
import {Switch, Route} from 'react-router-dom';
import Register from './Components/Register/Register';
import Home from './Components/Home/Home';

function App() {
  return (
    <Switch>
      <Route exact path='/' component={Home}></Route>
      <Route exact path='/register' component={Register}></Route>
    </Switch> 
  );
}

export default App;
