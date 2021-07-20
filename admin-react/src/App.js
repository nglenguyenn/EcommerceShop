import Layout from './containers/Layout';
import Home from './components/Home';
import { BrowserRouter, Route } from 'react-router-dom';
import Product from './containers/Product';
import Category from './containers/Category';
import ProductForm from './containers/Product/productform';
import CategoryForm from './containers/Category/categoryform';


import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Layout>
        
        <Route path="/" exact><Home /></Route>
        <Route path="/products" ><Product /></Route>
        <Route path="/productform" ><ProductForm /></Route>
        <Route path="/categories" ><Category /></Route>
        <Route path="/categoryform" ><CategoryForm /></Route>

      </Layout>
    </BrowserRouter>
  );
}
export default App;