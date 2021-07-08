import React from "react";
import Navbar from "./Navbar";
import {
  Input,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Button,
} from "@material-ui/core";
import { useEffect, useState } from "react";
import "./NewGroup.css";
import axios from "../axios";
import {useHistory} from "react-router-dom";

function NewGroup() {
  const token =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJIZWdlZHVzTWF0ZSIsImp0aSI6IjlkNmE4ZWU3LTlmMzgtNDYzZC1hYTA1LWRlMmFmMGY1YzU4OSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMDIxNzRjZjDigJM5NDEy4oCTNGNmZS1hZmJmLTU5ZjcwNmQ3MmNmNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjI1NzcyNzcyLCJpc3MiOiJodHRwOi8vd3d3LnNlY3VyaXR5Lm9yZyIsImF1ZCI6Imh0dHA6Ly93d3cuc2VjdXJpdHkub3JnIn0.MgceyFplTeBENWy65KI-kfVyzBIbnQvVo7SM5lv-ujg";
  const headers = {
    Authorization: "Bearer " + token,
  };

  const [users, setUsers] = useState([]);
  const [groupName, setGroupName] = useState("");
  const [description, setDescription] = useState("");
  const [age, setAge] = useState(0);
  const [groupAdminId, setGroupAdminId] = useState("");

  const history = useHistory();

  useEffect(() => {
    axios
      .get("/Content/GetAllUser", { headers: headers })
      .then((res) => {
        setUsers(res.data);
      })
      .catch((err) => console.log(err.message));
  }, []);

  const registerGroupHandler = () => {
    axios
      .post(
        "/CreateGroup",
        {
          groupName: groupName,
          groupAdminID: groupAdminId,
          description: description,
          age: age,
        },
        { headers: headers }
      )
      .then((res) => history.push('/main'))
      .catch((err) => console.log(err.message));
  };

  const goToMain = () => {
    history.push('/main');
   }

  return (
    <div className='newGroup__register'>
      <Navbar />
      <form>
        <div className="newGroup__form">
          <Input
            placeholder="Group's Name"
            value={groupName}
            onChange={(e) => setGroupName(e.target.value)}
            inputProps={{ "aria-label": "description" }}
          />
          <Input
            placeholder="Desciption"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            inputProps={{ "aria-label": "description" }}
          />
          <Input
            placeholder="Age"
            value={age}
            onChange={(e) => setAge(e.target.value)}
            inputProps={{ "aria-label": "description" }}
          />

          <FormControl>
            <InputLabel></InputLabel>
            <Select
              value={groupAdminId}
              onChange={(e) => {
                setGroupAdminId(e.target.value);
              }}
            >
              {users.map((user) => (
                <MenuItem value={user.userId}> {user.userName} </MenuItem>
              ))}
            </Select>
          </FormControl>

          <Button onClick={registerGroupHandler}>Register new group </Button>
        </div>
      </form>
      <Button onClick={goToMain}>
        Go back
      </Button>
    </div>
  );
}

export default NewGroup;
