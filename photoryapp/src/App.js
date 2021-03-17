import React from 'react';
import {Switch, Route} from 'react-router-dom';
import Register from './Components/Register/Register';
import Home from './Components/Home/Home';
import Browser from './Components/Browser/Browser';

function App() {
  return (
    <Switch>
      <Route exact path='/' component={Home}></Route>
      <Route exact path='/register' component={Register}></Route>
      <Route exact path='/browser' component={Browser}></Route>
    </Switch> 
  );
}

export default App;
