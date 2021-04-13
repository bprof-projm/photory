import React from 'react';
import {Switch, Route} from 'react-router-dom';

import RegisterAndSignInPage from './pages/register-and-sign-in/register-and-sign-in.page.jsx';
import SignInPage from './pages/sign-in/sign-in.page.jsx';

function App() {
  return (
    <Switch>
      <Route exact path='/' component={RegisterAndSignInPage}></Route>
      <Route exact path='/signin' component={SignInPage} />
    </Switch> 
  );
}

export default App;
