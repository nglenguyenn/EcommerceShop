import React, { useContext } from "react";
import { Route } from "react-router-dom";
import Login from "../containers/Auth/login";
import { AuthData } from "../data/authData";
import UnAuthorization from "../containers/Auth/unAuthorization";

export const PrivateRoute = ({ component: Component, ...rest }) => {
    const { isAuth, isAuthor } = useContext(AuthData);

    if (!isAuth) return <Login />
    if (isAuth && !isAuthor) return <UnAuthorization />
     return (
     <Route {...rest} render={props => (
        isAuth && isAuthor ?
              <Component {...props} />
              : <Login />
      )} />
  );
};