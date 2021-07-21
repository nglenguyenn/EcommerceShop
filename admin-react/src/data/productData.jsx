import React, { createContext, useEffect, useState } from 'react';
import { GetProducts } from '../services/productAPI';

export const ProductData = createContext({});

const ProductDataProvider = ({ children }) => {
    const [productItems, setProductItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            setProductItems(await GetProducts());
        };

        fetchData();
    }, []);

    return (
        <ProductData.Provider value={{
            productItems,
        }}>
            {children}
        </ProductData.Provider>
    );
}; 
export default ProductDataProvider;