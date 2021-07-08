import React from "react";
import "./Navbar.css";
import {
  AppBar,
  Toolbar,
  IconButton,
  
  Typography,
  Button,
} from "@material-ui/core";
import MenuIcon from './MenuIcon';
import { useHistory } from "react-router-dom";
import { useDispatch } from "react-redux";
import {setUserLogoutState } from "../features/userSlice";


function Navbar({ isNewGroupBtn}) {
  
  const history = useHistory();
  const dispatch = useDispatch();

  const logOutHandler = () => {
    dispatch(setUserLogoutState); 
    history.push('/home');
 }

 const goToMain = () => {
  history.push('/main');
 }

  const createGroupHandle = () => {

    history.push('/newGroup')

  }

  return (
    <AppBar   className='appBar'>
      <Toolbar className="navBar__toolbar" >
        <div className = "navBar__left">
        <IconButton
          onClick={goToMain}
          edge="start"
          className= "menuButton"
          color="inherit"
          aria-label="menu"
        >
         <MenuIcon/>
        </IconButton>
        <Typography variant="h6" className="title" >
           Photory
        </Typography>
        </div>
        {isNewGroupBtn && <div className = "navBar__mid">
        <Button  onClick={createGroupHandle} className = "newGroupBtn">Add new group</Button>
        </div>}
        
        <div className = "navBar__right">
        <Button color="inherit" onClick={logOutHandler} className = "logoutBtn">LogOut</Button>
        </div>
      </Toolbar>
    </AppBar>
  );
}

export default Navbar;
