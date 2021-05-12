import React, { useState } from "react";
import "./Home.css";
import Szívem from "../assets/Szívem.png";
import { TextField, Button  } from "@material-ui/core";
import { Link , useHistory } from "react-router-dom";
import axios from "../axios";
import ReactDOM from "react-dom";
import FacebookLogin from "react-facebook-login";

function Home() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const history = useHistory();

  const loginHandler = () => {
    const data = {
      validationName: email,
      password: password,
    };

    axios
      .put("/Auth/Login", data)
      .then((res) => {
        history.push('/main');
        console.log(res);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  const componentClicked = () =>{
      console.log();
  }

  const responseFacebook = (response) => {
    // console.log(response);
    // console.log(response.accessToken);
    const data = {
       accessToken: response.accessToken
    }
    axios.post("/ExternalAuth", data).then((res)=>{
      history.push('/main');
    }).catch((err)=>{
      console.log(err.message);
    });

  };

  return (
    <div className="home">
      <div className="home_left">
        <img loading="lazy" src={Szívem} />
      </div>
      <div className="home_right">
        <TextField
          label="Email/User Name"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
        <TextField
          label="Password"
          value={password}
          onChange={(e) => {
            setPassword(e.target.value);
          }}
        />
        <Button onClick={loginHandler}>Login</Button>

        <p>
          If you dont have an account , please{" "}
          <Link to="/register" style={{ color: "black" }}>
            register
          </Link>
        </p>

        <FacebookLogin
          appId="287947399346523"
          autoLoad={false}
          fields="name,email,picture"
          onClick={componentClicked}
          callback={responseFacebook}
        />
      </div>
    </div>
  );
}

export default Home;
