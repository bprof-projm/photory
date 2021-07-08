import axios from "../axios";
import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { selectId } from "../features/userSlice";

function GroupAdminUi() {
  //const token = useSelector(selectToken);
  const token =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJIZWdlZHVzTWF0ZSIsImp0aSI6IjlkNmE4ZWU3LTlmMzgtNDYzZC1hYTA1LWRlMmFmMGY1YzU4OSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMDIxNzRjZjDigJM5NDEy4oCTNGNmZS1hZmJmLTU5ZjcwNmQ3MmNmNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjI1NzcyNzcyLCJpc3MiOiJodHRwOi8vd3d3LnNlY3VyaXR5Lm9yZyIsImF1ZCI6Imh0dHA6Ly93d3cuc2VjdXJpdHkub3JnIn0.MgceyFplTeBENWy65KI-kfVyzBIbnQvVo7SM5lv-ujg";
  const headers = {
    Authorization: "Bearer " + token,
  };

  const [groups, setGroups] = useState([]);
  console.log(groups);

  const id = useSelector(selectId);


  useEffect(() => {
    axios
      .get("/GetAllGroup", { headers: headers })
      .then((res) => {
        console.log(res.data)
        setGroups(res.data);
      })
      .catch((err) => {
        console.log(err.message);
      });
  }, []);

  return (
    <div className="main__groupAdminUi">
      <h1>
        You are the Admin of :{" "}
        {groups.map((group) =>(
          group.groupAdminID === id ? group.groupName : ""
        ))}{" "}
      </h1>
    </div>
  );
}

export default GroupAdminUi;
