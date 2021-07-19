import React from 'react';
import { Jumbotron, Button } from 'reactstrap';

const Home = () => {
  return (
    <div>
      <Jumbotron style={{textAlignVertical: "center",textAlign: "center",}}>
        <h1 className="display-3">Welcome to Admin Page for Ecommerce Shop!</h1>
        <p className="lead pt-1">Assginment The Rookie</p>
        <hr className="my-2" />
        <p></p>
        <p className="lead">
          <Button color="primary">Go</Button>
        </p>
      </Jumbotron>
    </div>
  );
};

export default Home; 