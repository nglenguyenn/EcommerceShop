import MenuTop from "../MenuTop/MenuTop";

function Layout({children}) {

     return (
         <>
           <MenuTop></MenuTop>
           {children}
         </>
     );
   }
   
   export default Layout;