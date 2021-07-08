import React, { useState, useEffect } from "react";
import "./Main.css";
import { TextField, Button, Date } from "@material-ui/core";
import { Link, Redirect, useHistory } from "react-router-dom";
import axios from "../../axios";
import { useDispatch, useSelector } from "react-redux";
import {
  setUserLogoutState,
  selectRole,
  selectId,
} from "../../features/userSlice";
import Group from "./Group";
import Navbar from "../Navbar";
import GroupAdminUi from "../GroupAdminUi";

function Main() {
  const [groups, setGroups] = useState([]);

  //const token = useSelector(selectToken);
  const token =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJIZWdlZHVzTWF0ZSIsImp0aSI6IjlkNmE4ZWU3LTlmMzgtNDYzZC1hYTA1LWRlMmFmMGY1YzU4OSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMDIxNzRjZjDigJM5NDEy4oCTNGNmZS1hZmJmLTU5ZjcwNmQ3MmNmNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjI1NzcyNzcyLCJpc3MiOiJodHRwOi8vd3d3LnNlY3VyaXR5Lm9yZyIsImF1ZCI6Imh0dHA6Ly93d3cuc2VjdXJpdHkub3JnIn0.MgceyFplTeBENWy65KI-kfVyzBIbnQvVo7SM5lv-ujg";
  const headers = {
    Authorization: "Bearer " + token,
  };

  const role = useSelector(selectRole);
  const id = useSelector(selectId);

  const deleteHandler = (groupName) => {
    axios
      .post(`Admin/DeleteGroup/${groupName}`, {}, { headers: headers })
      .then(axios.get("/GetAllGroup", { headers: headers }))
      .then((res) => {
        setGroups(res.data);
        console.log(res.data);
      })
      .catch((err) => console.log(err.message));
  };

  useEffect(() => {
    axios
      .get("/GetAllGroup", { headers: headers })
      .then((res) => {
        setGroups(res.data);
      })
      .catch((err) => {
        console.log(err.message);
      });
  }, []);

  return (
    <div className="main">
      <Navbar isNewGroupBtn={role === "Admin" ? true : false} />
      {role == 'GroupAdmin' ? 
      <GroupAdminUi/>  :
       <div className="main__groups">
        { groups && groups.map((group) => (
          <Group
            key={group.groupName}
            deleteHandler={deleteHandler}
            groupName={group.groupName}
            description={group.description}
            age={group.age}
          />
        ))}
      </div>}
    </div>
      
  );
}

export default Main;
