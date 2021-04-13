import React from 'react';
import {Switch, Route} from 'react-router-dom';

import RegisterAndSignInPage from './pages/register-and-sign-in/register-and-sign-in.page.jsx';

function App() {
  return (
    <Switch>
      <Route exact path='/' component={RegisterAndSignInPage}></Route>
    </Switch> 
  );
}

export default App;
