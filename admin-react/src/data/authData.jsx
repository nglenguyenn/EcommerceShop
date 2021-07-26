import React, { createContext, useState } from 'react';
import { signinRedirectCallback, signoutRedirectCallback } from '../services/auth-service';
import RequestService from "../services/request";

export const AuthData = createContext({});

const AuthDataProvider = ({ children }) => {
    const [isAuth, setAuth] = useState(false);
    const [isAuthor, setAuthor] = useState(false);
    const [user, setUser] = useState(null);


    const signInRedirectCallback = () => {
        signinRedirectCallback()
            .then(res => {
                if (res.profile.role === 'Admin') {
                    RequestService.setAuthentication(res.access_token);
                    setAuth(true);
                    setAuthor(true);
                    setUser(res);
                }
                else {
                    setAuth(true);
                    setAuthor(false);
                }
            })
            .catch(err => console.log(err));
    };
    const signOutRedirectCallback = () => {
        signoutRedirectCallback()
            .then(() => {
                setAuth(false);
                setAuthor(false);
                setUser(null);
            })
            .catch(err => console.log(err));
    };


    return (
        <AuthData.Provider value={{
            isAuth,
            user,
            isAuthor,
            signInRedirectCallback,
            signOutRedirectCallback
        }}>
            {children}
        </AuthData.Provider>
    );
};

export default AuthDataProvider; 