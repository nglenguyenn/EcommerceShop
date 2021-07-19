import MenuTop from "../MenuTop";
import Home from "../../components/Home/Home";

function Layout({children}) {

     return (
         <>
           <MenuTop></MenuTop>
           <Home></Home>
           {children}
         </>
     );
   }
   
   export default Layout;