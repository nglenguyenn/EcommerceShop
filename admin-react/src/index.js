import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import "bootstrap/dist/css/bootstrap.min.css";
import AuthDataProvider from "./data/authData";
import ProductProdvider from "./data/productData";
import CategoryProdvider from "./data/categoryData";
import { BrowserRouter } from "react-router-dom";

ReactDOM.render(
  <BrowserRouter>
    <AuthDataProvider>
      <ProductProdvider>
        <CategoryProdvider>
          <App />
        </CategoryProdvider>
      </ProductProdvider>
    </AuthDataProvider>
  </BrowserRouter>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
