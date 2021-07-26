import { useEffect , useContext} from "react";
import { useHistory } from "react-router-dom";
import { AuthData } from "../../data/authData";


const SignOutCallBack = () => {
    const { signoutRedirectCallback } = useContext(AuthData)
     const history = useHistory();

     useEffect(() => {
        signoutRedirectCallback();
        history.push("/");
    }, [history, signoutRedirectCallback]);

     return <div>Sign Out Redirecting...</div>;
 };
 
 export default SignOutCallBack; 