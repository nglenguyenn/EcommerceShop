import React, { createContext, useEffect, useState } from 'react';
import { GetCategories } from '../services/categoryAPI';


export const CategoryData = createContext({});

const CategoryDataProvider = ({ children }) => {
    const [categoryItems, setCategoryItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            setCategoryItems(await GetCategories());
        };

        fetchData();
    }, []);

    return (
        <CategoryData.Provider value={{
            categoryItems,
        }}>
            {children}
        </CategoryData.Provider>
    );
};

export default CategoryDataProvider