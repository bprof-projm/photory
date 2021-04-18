import React from 'react';
import {Switch, Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

import RegisterAndSignInPage from './pages/register-and-sign-in/register-and-sign-in.page.jsx';
import SignInPage from './pages/sign-in/sign-in.page.jsx';
import RegisterPage from './pages/register/register.page.jsx';
import GroupsPage from './pages/groups/groups.page.jsx';

import './App.scss';

class App extends React.Component {
  render(){
    return (    
      <Switch>
        <Route exact path='/' component={RegisterAndSignInPage}></Route>
        <Route exact path='/signin' render={() => this.props.currentUser ? (<Redirect to='/groups' />) : (<SignInPage />)} />
        <Route exact path='/register' component={RegisterPage} />
        <Route exact path='/groups' component={GroupsPage} />
      </Switch> 
    );
  }
}

const mapStateToProps = state => ({
  currentUser: state.user.currentUser
});

export default connect(mapStateToProps)(App);
