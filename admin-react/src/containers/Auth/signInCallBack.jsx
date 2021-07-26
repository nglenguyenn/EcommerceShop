import { useEffect, useContext } from "react";
import { AuthData } from "../../data/authData";
import { useHistory } from "react-router";

const SignInCallBack = () => {
    const { signInRedirectCallback } = useContext(AuthData)
 
     const history = useHistory();
 
     useEffect(() => {
        signInRedirectCallback();
        history.push("/");
    }, [history, signInRedirectCallback]);
 
     return <div>Sign In Redirecting...</div>;
 };
 
 export default SignInCallBack; 