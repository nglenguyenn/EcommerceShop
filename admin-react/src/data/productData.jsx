import React, { createContext, useEffect, useState } from "react";
import { GetProducts, PostProduct } from "../services/productAPI";
import { GetCategories } from "../services/categoryAPI";

export const ProductData = createContext({});

const ProductDataProvider = ({ children }) => {
  const [productItems, setProductItems] = useState([]);
  const [categoryItems, setCategoryItems] = useState([]);

  const postProduct = (formData) => {
    (async () => {
        await PostProduct(formData);
      setProductItems(await GetProducts());
    }
    )();
};

useEffect(() => {
    (async () => {
        setProductItems(await GetProducts());
        setCategoryItems(await GetCategories());
    }
    )();
  }, []);

  return (
    <ProductData.Provider
      value={{
        productItems,
        categoryItems,
        postProduct
      }}
    >
      {children}
    </ProductData.Provider>
  );
};
export default ProductDataProvider;
