import React, { useState ,useEffect} from "react";
import axios from "../../axios";
import './Group.css'
import {
  CardMedia,
  Card,
  CardActionArea,
  CardContent,
  Typography,
  CardActions,
  Button,
} from "@material-ui/core";
import { selectRole , selectToken } from "../../features/userSlice";
import { useSelector } from "react-redux";

function Group({ groupName, description, age , deleteHandler}) {
  
  const role = useSelector(selectRole);



 
  return (
    <div className="singleGroup">
      <Card className="root">
        <CardActionArea>
          <CardMedia
            className="media "
            image="/static/images/cards/contemplative-reptile.jpg"
            title="Contemplative Reptile"
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="h2">
              {groupName}
            </Typography>
            <Typography variant="body2" color="textSecondary" component="p">
              {description}
            </Typography>
          </CardContent>
          <CardActions>
          {role !== "Admin" ? (
            <Button size="small" color="primary">
              Join
            </Button>
          ) : (
            <Button  size="small" color="primary" onClick = {() => {deleteHandler(groupName)}}>
              Delete
            </Button>
          )
          }

          <Button size="small" color="primary">
            Learn More
          </Button>
        </CardActions>
        </CardActionArea>
       
      </Card>
    </div>
  );
}

export default Group;
