import { useState } from "react";
import { Link } from "react-router-dom";

import authService from "../../services/authService";


const UserProfileMenu = () => {


  const [open, setOpen] = useState(false);



  const handleLogout = () => {

    authService.logout();

  };



  return (

    <div className="relative">


      <button

        onClick={() => setOpen(!open)}

        className="flex items-center gap-2 px-4 py-2 rounded-lg hover:bg-gray-100"

      >

        <div className="w-8 h-8 bg-blue-600 text-white rounded-full flex items-center justify-center">

          A

        </div>


        <span>

          Admin ▼

        </span>


      </button>





      {
        open && (

          <div className="absolute right-0 mt-2 w-48 bg-white shadow-lg rounded-lg border">


            <Link

              to="/profile"

              className="block px-4 py-3 hover:bg-gray-100"

            >

              Profile

            </Link>




            <Link

              to="/change-password"

              className="block px-4 py-3 hover:bg-gray-100"

            >

              Change Password

            </Link>





            <button

              onClick={handleLogout}

              className="w-full text-left px-4 py-3 hover:bg-gray-100 text-red-600"

            >

              Logout

            </button>



          </div>

        )

      }



    </div>

  );

};


export default UserProfileMenu;