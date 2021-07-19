import MenuTop from "../MenuTop";

function Layout({children}) {

     return (
         <>
           <MenuTop></MenuTop>
           {children}
         </>
     );
   }
   
   export default Layout;