import { useState } from "react";


const ChangePassword = () => {


  const [formData, setFormData] = useState({

    currentPassword: "",

    newPassword: "",

    confirmPassword: ""

  });



  const [message, setMessage] = useState("");



  const handleChange = (e) => {


    setFormData({

      ...formData,

      [e.target.name]: e.target.value

    });


  };



  const handleSubmit = (e) => {


    e.preventDefault();



    if(formData.newPassword !== formData.confirmPassword){


      setMessage("New password and confirm password do not match");

      return;


    }



    setMessage("Password updated successfully");



    console.log(formData);


  };



  return (

    <div className="bg-white p-6 rounded-xl shadow max-w-md">


      <h1 className="text-2xl font-bold mb-6">

        Change Password

      </h1>




      {
        message && (

          <div className="bg-blue-100 text-blue-600 p-3 rounded mb-4">

            {message}

          </div>

        )
      }





      <form onSubmit={handleSubmit}>


        <input

          type="password"

          name="currentPassword"

          placeholder="Current Password"

          value={formData.currentPassword}

          onChange={handleChange}

          className="w-full border rounded-lg px-4 py-2 mb-4"

          required

        />




        <input

          type="password"

          name="newPassword"

          placeholder="New Password"

          value={formData.newPassword}

          onChange={handleChange}

          className="w-full border rounded-lg px-4 py-2 mb-4"

          required

        />




        <input

          type="password"

          name="confirmPassword"

          placeholder="Confirm Password"

          value={formData.confirmPassword}

          onChange={handleChange}

          className="w-full border rounded-lg px-4 py-2 mb-4"

          required

        />





        <button

          type="submit"

          className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700"

        >

          Update Password

        </button>



      </form>


    </div>

  );

};


export default ChangePassword;