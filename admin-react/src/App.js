import Layout from "./containers/Layout";
import Home from "./containers/Home";
import { BrowserRouter, Route } from "react-router-dom";
import Product from "./containers/Product";
import Category from "./containers/Category";
import User from "./containers/User";
import ProductForm from "./containers/Product/productform";
import CategoryForm from "./containers/Category/categoryform";
import ProductProdvider from './data/productData';
import CategoryProdvider from './data/categoryData';

import "./App.css";

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Route path="/" exact>
          <Home />
        </Route>
        <ProductProdvider>
          <Route path="/product" >
            <Product />
          </Route>
          <Route path="/productform" component={ProductForm}>
          </Route>
        </ProductProdvider>

        <CategoryProdvider>
          <Route path="/category" >
            <Category />
          </Route>
          <Route path="/categoryform" component={CategoryForm}>
          </Route>
        </CategoryProdvider>
        <Route path="/user" >
          <User />
        </Route>
      </Layout>
    </BrowserRouter>
  );
}
export default App;
