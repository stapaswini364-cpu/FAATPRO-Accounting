import { useState } from "react";


const Profile = () => {


  const [user] = useState({

    name: "Admin",

    email: "admin@faatpro.com",

    role: "Super Admin"

  });



  return (

    <div className="bg-white p-6 rounded-xl shadow">


      <h1 className="text-2xl font-bold mb-6">
        My Profile
      </h1>



      <div className="space-y-5">


        <div>

          <h3 className="font-semibold">
            Name
          </h3>

          <p className="text-gray-600">
            {user.name}
          </p>

        </div>



        <div>

          <h3 className="font-semibold">
            Email
          </h3>

          <p className="text-gray-600">
            {user.email}
          </p>

        </div>



        <div>

          <h3 className="font-semibold">
            Role
          </h3>

          <p className="text-gray-600">
            {user.role}
          </p>

        </div>



      </div>


    </div>

  );

};


export default Profile;