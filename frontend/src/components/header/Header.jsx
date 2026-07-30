import { Menu } from "lucide-react";

import UserProfileMenu from "../user/UserProfileMenu";


const Header = ({ setOpen }) => {


  return (

    <header className="h-16 bg-white shadow flex items-center justify-between px-6">


      {/* Mobile Menu Button */}

      <button
        className="md:hidden"
        onClick={() => setOpen && setOpen(true)}
      >

        <Menu size={24} />

      </button>




      {/* Page Title */}

      <h2 className="text-xl font-semibold">

        Dashboard

      </h2>




      {/* User Dropdown */}

      <UserProfileMenu />


    </header>

  );

};


export default Header;