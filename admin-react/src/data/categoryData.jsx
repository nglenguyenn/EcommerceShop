import React, { createContext, useEffect, useState } from "react";
import {
  GetCategories,
  PostCategory,
  PutCategory,
  DeleteCategory,
} from "../services/categoryAPI";

export const CategoryData = createContext({});

const CategoryDataProvider = ({ children }) => {
  const [categoryItems, setCategoryItems] = useState([]);

  const postCategory = (formData) => {
    (async () => {
      await PostCategory(formData);
      setCategoryItems(await GetCategories());
    })();
  };

  const putCategory = (id, formData) => {
    (async () => {
      await PutCategory(id, formData);
      setCategoryItems(await GetCategories());
    })();
  };

  const deleteCategory = (id) => {
    (async () => {
      await DeleteCategory(id);
      setCategoryItems(await GetCategories());
    })();
  };

  useEffect(() => {
    (async () => {
      setCategoryItems(await GetCategories());
    })();
  }, []);

  return (
    <CategoryData.Provider
      value={{
        categoryItems,
        postCategory,
        putCategory,
        deleteCategory,
      }}
    >
      {children}
    </CategoryData.Provider>
  );
};

export default CategoryDataProvider;
