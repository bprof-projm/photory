import React, { useState, useEffect } from "react";
import "./Register.css";
import Szívem from "../assets/Szívem.png";
import { TextField, Button, Date } from "@material-ui/core";
import { Link, Redirect, useHistory } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import axios from "../axios";

function Register() {
  const [email, setEmail] = useState("");
  const [userName, setUserName] = useState("");
  const [birthDate, setBirthDate] = useState();
  const [fullName, setFullName] = useState("");
  const history = useHistory();

  useEffect(() => {
    console.log(birthDate);
  }, [birthDate]);

  const registerHandler = () => {
    const data = {
      email: email,
      userName: userName,
      fullName: fullName,
      birthDate: birthDate,
    };

    console.log(data);

    axios
      .post("/Auth/Register", data)
      .then((res) => {
        console.log(res.data.user);
        alert("Succesful registration , your password is : \n" + res.data.user[2]);
        history.push("/");

      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  return (
    <div className="register">
      <div className="register_left">
        <img loading="lazy" src={Szívem} />
      </div>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
      <div className="register_right">
        <TextField
          label="Email"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
        <TextField
          label="User Name"
          value={userName}
          onChange={(e) => {
            setUserName(e.target.value);
          }}
        />
        <TextField
          label="Full Name"
          value={fullName}
          onChange={(e) => {
            setFullName(e.target.value);
          }}
        />
        <TextField
          label="Birthday"
          type="date"
          defaultValue="2021-01-01"
          InputLabelProps={{ shrink: true }}
          value={birthDate}
          onChange={(e) => {
            setBirthDate(e.target.value);
          }}
        />

        <Button onClick={registerHandler}>Create An Account</Button>
      </div>
    </div>
  );
}

export default Register;
