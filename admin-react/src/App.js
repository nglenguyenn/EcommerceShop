import MenuTop from "./components/MenuTop/MenuTop";
import Home from "./containers/Home";

import Product from "./containers/Product";
import Category from "./containers/Category";
import User from "./containers/User";

import ProductForm from "./containers/Product/productform";
import CategoryForm from "./containers/Category/categoryform";

import SignInCallBack from "./containers/Auth/signInCallBack";
import SignOutCallBack from "./containers/Auth/signOutCallBack";

import { Route, Switch } from 'react-router-dom';
import { PrivateRoute } from './utils/route';

import Login from "./containers/Auth/login";
import Logout from "./containers/Auth/logout";

import "./App.css";

function App() {
  return (
    <div>
      <MenuTop/>
      <Switch>
        <Route path="/" exact component={Home}></Route>

          <PrivateRoute
            exact
            path="/product"
            component={Product}
          ></PrivateRoute>
          <PrivateRoute
            path="/productform"
            component={ProductForm}
          ></PrivateRoute>

          <PrivateRoute path="/category">
            <Category />
          </PrivateRoute>
          <PrivateRoute
            path="/categoryform"
            component={CategoryForm}
          ></PrivateRoute>

        <PrivateRoute path="/user" component={User}>
          <User />
        </PrivateRoute>

        <Route exact path="/login" component={Login}>
        </Route>
        <Route exact path="/logout" component={Logout}>
        </Route>


        <Route path="/signin-callback" component={SignInCallBack}></Route>

        <Route path="/signout-callback" component={SignOutCallBack}></Route>
        </Switch>
      </div>
  );
}
export default App;
